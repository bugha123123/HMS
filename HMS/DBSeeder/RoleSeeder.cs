﻿
using Microsoft.AspNetCore.Identity;

public  class RoleSeeder
{
    public static async Task SeedRolesAsync(IServiceProvider serviceProvider, RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "Patient", "Doctor", "Nurse" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
