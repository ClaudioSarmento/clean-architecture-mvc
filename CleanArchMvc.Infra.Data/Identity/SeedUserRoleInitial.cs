using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task SeedUsersAsync()
    {
        if (await _userManager.FindByEmailAsync("usuario@localhost") == null)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = "usuario@localhost",
                Email = "usuario@localhost",
                NormalizedUserName = "USUARIO@LOCALHOST",
                NormalizedEmail = "USUARIO@LOCALHOST",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(user, "Numsey#2026");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        if (await _userManager.FindByEmailAsync("admin@localhost") == null)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin@localhost",
                Email = "admin@localhost",
                NormalizedUserName = "ADMIN@LOCALHOST",
                NormalizedEmail = "ADMIN@LOCALHOST",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = await _userManager.CreateAsync(user, "Numsey#2026");

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }

    public async Task SeedRolesAsync()
    {
        if (!await _roleManager.RoleExistsAsync("User"))
        {
            IdentityRole role = new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER"
            };
            IdentityResult result = await _roleManager.CreateAsync(role); // Adeus .Result!
        }

        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            IdentityRole role = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            IdentityResult result = await _roleManager.CreateAsync(role);
        }
    }


}
