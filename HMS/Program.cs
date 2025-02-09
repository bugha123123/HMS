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
    options.UseSqlServer(builder.Configuration.GetConnectionString("HSMCS")));

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

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
    // Check if user is signed in
    var loggedInUser = await userManager.GetUserAsync(context.User);

    if (loggedInUser is null)
    {
        // If user is not logged in, redirect to signin page
        context.Response.Redirect("/Auth/signin");
        return;
    }

    // Redirect based on the user's role
    if (await userManager.IsInRoleAsync(loggedInUser, "PATIENT"))
    {
        // Redirect to Patient Index page
        context.Response.Redirect("/Home/Index");
        return;
    }

    if (await userManager.IsInRoleAsync(loggedInUser, "ADMIN"))
    {
        // Redirect to Admin Dashboard
        context.Response.Redirect("/Admin/dashboard");
        return;
    }

    if (await userManager.IsInRoleAsync(loggedInUser, "DOCTOR"))
    {
        // Redirect to Doctor Index page
        context.Response.Redirect("/Doctor/Index");
        return;
    }

    // Default redirection if no role matched
    context.Response.Redirect("/Auth/signup");
});

app.MapGet("/Admin/", async (HttpContext context, UserManager<User> userManager) =>
{
    // Check if user is signed in
    var loggedInUser = await userManager.GetUserAsync(context.User);

    if (loggedInUser is null)
    {
        // If user is not logged in, redirect to signin page
        context.Response.Redirect("/Auth/signin");
        return;
    }

    // Check if the logged-in user has 'ADMIN' role
    if (!await userManager.IsInRoleAsync(loggedInUser, "ADMIN"))
    {
        // Redirect to a non-admin path or signup
        context.Response.Redirect("/Auth/signup");
        return;
    }

    // Redirect to the admin dashboard
    context.Response.Redirect("/Admin/dashboard");
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
