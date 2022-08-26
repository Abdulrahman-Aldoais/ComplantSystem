using ComplantSystem.Const;
using ComplantSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace ComplantSystem.Configuration
{
    public class UsersConfiguration
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string IdentityAdmin = "000243124111";

                var adminUser = await userManager.FindByEmailAsync(IdentityAdmin);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "علي سرحان الدعيس عبدالرحمن",
                        IdentityNumber = IdentityAdmin,
                        Email = IdentityAdmin,
                        UserName = IdentityAdmin,
                        PhoneNumber = "775115810",
                        GovernorateId = 2,
                        DirectorateId = 1,
                        SubDirectorateId = 1,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.AdminGeneralFederation);
                }


                string IdentityUser = "000243124222";

                var appUser = await userManager.FindByEmailAsync(IdentityUser);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = " سعيد علي احمد",
                        Email = IdentityUser,
                        UserName = IdentityUser,
                        IdentityNumber = IdentityUser,
                        PhoneNumber = "773453534",
                        GovernorateId = 1,
                        DirectorateId = 1,
                        SubDirectorateId = 3,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "B@ww11");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Beneficiarie);
                }


            }
        }

    }
}
