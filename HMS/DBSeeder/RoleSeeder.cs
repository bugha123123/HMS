using HMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public class RoleSeeder
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        string[] roleNames = { "Admin", "Patient", "Doctor", "Nurse" };

        // Create roles if they don't exist
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Ensure there is always one Admin user
        var adminUser = await userManager.FindByEmailAsync("admin@example.com");

        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = "irakliberdzena333@gmail.com",
                Email = "irakliberdzena333@gmail.com",  // Make sure to update this email with the actual admin email you want
                PhoneNumber = "123-456-7890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            // Set a password for the Admin user
            var passwordHash = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHash.HashPassword(adminUser, "Admin12345");

            // Create the Admin user in the database
            await userManager.CreateAsync(adminUser);

            // Assign the Admin role
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}
