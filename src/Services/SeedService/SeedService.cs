using Data;
using Models;
using Models.Enums;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.SeedService
{
    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext db;
        private readonly IServiceProvider serviceProvider;

        public SeedService(ApplicationDbContext db, IServiceProvider serviceProvider)
        {
            this.db = db;
            this.serviceProvider = serviceProvider;
        }
        public async Task AddUserAndRoleAsync()
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleName = "Admin";
            await roleManager.CreateAsync(new ApplicationRole(roleName));

            if (!userManager.Users.Any(x => x.UserName == "nikolayski@abv.bg"))
            {
                var user = new ApplicationUser
                {
                    UserName = "nikolayski@abv.bg",
                    Email = "nikolayski@abv.bg",
                    EmailConfirmed = false
                };
                userManager.CreateAsync(user, "Dadada1122_").GetAwaiter().GetResult();
                await userManager.AddToRoleAsync(user, roleName);
                await this.db.SaveChangesAsync();
            }
        }

        
    }
}
