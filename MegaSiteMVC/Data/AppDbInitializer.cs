using MegaSiteMVC.Data.Static;
using MegaSiteMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace MegaSiteMVC.Data
{
	public class AppDbInitializer
	{
		public static void Seed(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

				context.Database.EnsureCreated();

				//Products not found then add standart products
				if (!context.Products.Any())
				{
					context.Products.AddRange(new List<Product>()
					{
						new Product
						{
							ImageURL = "/images/Axe.png",
							Name = "EMI Axe",
							Description = "Best weapon against robots",

                            Price = 800
						},
                        new Product
                        {
                            ImageURL = "/images/EMI_grenade.png",
                            Name = "EMI grenade",
                            Description = "If you have a robot in front of you and you haven't got a gun or other weapon, this grenade will help you.",
                            Price = 500
                        },
                        new Product
                        {
                            ImageURL = "/images/Crusher.png",
                            Name = "Crusher",
                            Description = "Legendary gun and the best weapon",
                            Price = 1000
                        },
                        new Product
                        {
                            ImageURL = "/images/Wife2.png",
                            Name = "Wife",
                            Description = "Wife of main hero",
                            Price = 500
                        },
                        new Product
                        {
                            ImageURL = "/images/Cleaner.png",
                            Name = "Cleaner",
                            Description = "Tipical enamy",
                            Price = 600
                        },
                        new Product
                        {
                            ImageURL = "/images/Icarus.png",
                            Name = "Icarus",
                            Description = "Main hero",
                            Price = 500
                        },
                        new Product
                        {
                            ImageURL = "/images/AP-050.png",
                            Name = "AP-050",
                            Description = "Robot",
                            Price = 800
                        },
                        new Product
                        {
                            ImageURL = "/images/Frenk.png",
                            Name = "Frenk",
                            Description = "Freind of main hero",
                            Price = 500
                        }
                    });
					context.SaveChanges();
				}
			}
		}

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@sozdavatel.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(newAdminUser, "Admin@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@sozdavatel.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "John Doe",
                        UserName = "thebest",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(newAppUser, "SuPeRPaSsWoRd5!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
