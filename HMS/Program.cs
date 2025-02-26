using HMS.DB;
using HMS.Interface;
using HMS.Model;
using HMS.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContextion>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HSMCS")), ServiceLifetime.Scoped);

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IChatService, ChatService>();
// Register services

//host services

builder.Services.AddHostedService<AppointmentCleanupService>();

builder.Services.AddHostedService<ChatMonitoringService>();
//host services

// Configure Identity
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 1;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<AppDbContextion>()
.AddDefaultTokenProviders();

builder.Services.AddHttpClient();
builder.Services.AddScoped<RoleSeeder>();

var app = builder.Build();

// Middleware to handle user redirection based on roles
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/", async (HttpContext context, UserManager<User> userManager) =>
{
    var loggedInUser = await userManager.GetUserAsync(context.User);

    if (loggedInUser is null)
    {
        context.Response.Redirect("/Auth/signin");
        return;
    }

    if (await userManager.IsInRoleAsync(loggedInUser, "PATIENT"))
    {
        context.Response.Redirect("/Home/Index");
        return;
    }

    if (await userManager.IsInRoleAsync(loggedInUser, "ADMIN"))
    {
        context.Response.Redirect("/Admin/dashboard");
        return;
    }

    if (await userManager.IsInRoleAsync(loggedInUser, "DOCTOR"))
    {
        context.Response.Redirect("/Doctor/Index");
        return;
    }

    context.Response.Redirect("/Auth/signup");
});

app.MapGet("/Admin/", async (HttpContext context, UserManager<User> userManager) =>
{
    var loggedInUser = await userManager.GetUserAsync(context.User);

    if (loggedInUser is null)
    {
        context.Response.Redirect("/Auth/signin");
        return;
    }

    if (!await userManager.IsInRoleAsync(loggedInUser, "ADMIN"))
    {
        context.Response.Redirect("/Auth/signup");
        return;
    }

    context.Response.Redirect("/Admin/dashboard");
});

// Restrict Access to Chat (Only Doctors & Patients)
app.MapGet("/Chat/", async (HttpContext context, UserManager<User> userManager) =>
{
    var loggedInUser = await userManager.GetUserAsync(context.User);

    if (loggedInUser is null)
    {
        context.Response.Redirect("/Auth/signin");
        return;
    }

    // Allow access only if the user is a Doctor or Patient
    bool isDoctor = await userManager.IsInRoleAsync(loggedInUser, "DOCTOR");
    bool isPatient = await userManager.IsInRoleAsync(loggedInUser, "PATIENT");

    if (!isDoctor && !isPatient)
    {
        // If user is not a doctor or patient, redirect them out
        context.Response.Redirect("/Auth/signup");
        return;
    }

    // If the user is authorized, allow them to access the chat
    await context.Response.WriteAsync("Welcome to the chat!");
});






using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Get the RoleManager and UserManager for role and user management
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

    // Seed the roles and admin user
    await RoleSeeder.SeedRolesAsync(serviceProvider, roleManager, userManager);

}

app.Run();
