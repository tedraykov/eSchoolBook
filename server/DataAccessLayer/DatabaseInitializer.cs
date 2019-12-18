using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolBook.BusinessLogicLayer.DTOs.Enums;
using SchoolBook.BusinessLogicLayer.DTOs.InputModels;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.DataAccessLayer
{
    public class DatabaseInitializer
    {
        public async Task Seed(IServiceProvider provider, IConfiguration configuration)
        {
            var logger = provider.GetService<ILogger<IDatabaseInitializer>>();
            var repositories = provider.GetService<IRepositories>();
            var webHost = provider.GetService<IWebHostEnvironment>();
            var context = provider.GetService<SchoolBookContext>();

            await this.SeedRoles(provider.GetService<RoleManager<IdentityRole>>(), logger);

            await this.SeedUserAdmin(provider.GetService<IAccountService>(), configuration, logger);

            await this.SeedGrades(webHost, logger, repositories, context);
            
            await repositories.SaveChanges();
        }

        private async Task SeedRoles(RoleManager<IdentityRole> roleManager, ILogger<IDatabaseInitializer> logger)
        {
            logger.LogInformation("Start Seeding Roles...");
            
            var roleNames = Enum.GetNames(typeof(RoleTypes));

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            logger.LogInformation("End Seeding Roles...");
        }
        
        private async Task SeedUserAdmin(IAccountService accountService, IConfiguration configuration, ILogger<IDatabaseInitializer> logger)
        {
            
            logger.LogInformation("Start Seeding Admin...");

            var userSettingsSection = configuration.GetSection("UserSettings");

            var adminModel = new RegisterInputModel
            {
                Email = userSettingsSection["Email"],
                FirstName = userSettingsSection["FirstName"],
                SecondName = userSettingsSection["SecondName"],
                LastName = userSettingsSection["LastName"],
                Password = userSettingsSection["Password"]
            };

            await accountService.SeedAdmin(adminModel);
            logger.LogInformation("End Seeding Admin...");
        }
        private async Task SeedGrades(IWebHostEnvironment webHost, ILogger<IDatabaseInitializer> logger, 
            IRepositories repositories, SchoolBookContext context)
        {
            if(context.Grades.Any()){ return; }
            
            logger.LogInformation("Grades definition filepath ");
            
            var filepath = Path.Combine(webHost.ContentRootPath,
                "DataAccessLayer/grades-bg.json");
            var gradesJson = File.ReadAllText(filepath);

            var grades = JsonConvert.DeserializeObject<ICollection<Grade>>(gradesJson);
            
            foreach (var grade in grades)
            {
                await repositories.Grades.Create(grade);
            }
            logger.LogInformation("End Seeding Grades...");
        }
    }
}