using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;
using Backend.Domain.ValueObjects;
using Identity.Services;
using Microsoft.AspNetCore.Identity;

namespace Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var administratorRole = new IdentityRole("Administrator");

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Administrator1!");
            await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }
    }

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {

        if (!context.Oems.Any())
        {
            context.Oems.Add(new Oem
            {
                Name = "VW",
                Status = Status.Active
            });
            context.Oems.Add(new Oem
            {
                Name = "FORD",
                Status = Status.Active
            }); 
            context.Oems.Add(new Oem
            {
                Name = "JLR",
                Status = Status.Active
            });
            context.Oems.Add(new Oem
            {
                Name = "GENERAL",
                Status = Status.Active
            });


            await context.SaveChangesAsync();
        }


        if (!context.Categories.Any())
        {
            context.Categories.Add(new Category
            {
                Name = "Center Contact",
                Status = Status.Active
            });
            
            context.Categories.Add(new Category
            {
                Name = "KIT SubAssembly",
                Status = Status.Active
            });
            
            context.Categories.Add(new Category
            {
                Name = "Connector",
                Status = Status.Active
            });
            
            context.Categories.Add(new Category
            {
                Name = "Ferrule",
                Status = Status.Active
            });
            
            context.Categories.Add(new Category
            {
                Name = "SubAssembly Front 90",
                Status = Status.Active
            });
                
            context.Categories.Add(new Category
            {
                Name = "SubAssembly Rear 90",
                Status = Status.Active
            });
            context.Categories.Add(new Category
            {
                Name = "SubAssembly 180",
                Status = Status.Active
            });

            context.Categories.Add(new Category
            {
                Name = "Seal",
                Status = Status.Active
            });
            context.Categories.Add(new Category
            {
                Name = "Cap",
                Status = Status.Active
            });
            


            await context.SaveChangesAsync();
        }
    }
}

