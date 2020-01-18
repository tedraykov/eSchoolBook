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
using SchoolBook.DataAccessLayer.Entities.SchoolUserEntities;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook.DataAccessLayer
{
    public class DatabaseInitializer : ISeeder
    {
        private readonly SchoolBookContext _ctx;
        private readonly IWebHostEnvironment _webHost;
        private readonly ILogger<DatabaseInitializer> _logger;
        private readonly IRepositories _repositories;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;

        public DatabaseInitializer(
            SchoolBookContext ctx,
            IWebHostEnvironment webHost,
            ILogger<DatabaseInitializer> logger,
            IRepositories repositories,
            RoleManager<IdentityRole> roleManager,
            IAccountService accountService,
            IConfiguration configuration
        )
        {
            _ctx = ctx;
            _webHost = webHost;
            _logger = logger;
            _repositories = repositories;
            _roleManager = roleManager;
            _accountService = accountService;
            _configuration = configuration;
        }

        public async Task Seed()
        {
            await SeedRoles();
            await SeedUserAdmin();
            SeedGrades();
            SeedSchool();
            SeedClass();
            await SeedSchoolUsers();
            _repositories.SaveChanges();
        }

        private async Task SeedSchoolUsers()
        {
            _logger.LogDebug("Start Seeding Student...");
            if (_ctx.Students.FirstOrDefault() == null)
            {
                var student = new Student
                {
                    FirstName = "Sladi",
                    SecondName = "Sladkov",
                    LastName = "Sladkov",
                    Pin = "0510043827",
                    Address = "Някъде от София",
                    Town = "София",
                    StartYear = 2018,
                    School = _ctx.Schools.FirstOrDefault(),
                    Class = _ctx.Classes.FirstOrDefault()
                };
                var account = await CreateAspUser(student, RoleTypes.Student);
                if (account != null)
                {
                    student.User = account;
                    student.Id = account.Id;
                    _ctx.Students.Add(student);
                    await _ctx.SaveChangesAsync();
                }
            }

            _logger.LogDebug("Student Seeded");


            _logger.LogDebug("Start Seeding Teacher...");
            if (_ctx.Teachers.FirstOrDefault() == null)
            {
                var teacher = new Teacher
                {
                    FirstName = "Dimitar",
                    SecondName = "Gospodinov",
                    LastName = "Prepodavatelov",
                    Pin = "124304932",
                    Address = "Shishman 52",
                    Town = "Sofia",
                    School = _ctx.Schools.FirstOrDefault()
                };


                var account = await CreateAspUser(teacher, RoleTypes.Teacher);
                var someClass = _ctx.Classes.FirstOrDefault();

                if (someClass != null && account != null)
                {
                    someClass.ClassTeacher = teacher;
                    teacher.User = account;
                    teacher.Id = account.Id;
                    _ctx.Teachers.Add(teacher);
                }
            }

            _logger.LogDebug("Teacher Seeded");

            _logger.LogDebug("Start Seeding Parent...");
            if (_ctx.Parents.FirstOrDefault() == null)
            {
                var parent = new Parent
                {
                    FirstName = "Bashatata",
                    SecondName = "Na",
                    LastName = "Sladi",
                    Pin = "412412e2d324",
                    Address = "Някъде от София",
                    Town = "София",
                    School = _ctx.Schools.FirstOrDefault()
                };

                var student = _ctx.Students.FirstOrDefault();
                var account = await CreateAspUser(parent, RoleTypes.Parent);
                if (parent.Children != null && account != null)
                {
                    parent.User = account;
                    parent.Children.Add(student);
                    _logger.LogInformation(parent.ToString());
                    _ctx.Parents.Add(parent);
                }
            }

            _logger.LogDebug("Parent Seeded");
            
            _logger.LogDebug("Start Seeding Principal...");
            if (_ctx.Principals.FirstOrDefault() == null)
            {
                var principal = new Principal
                {
                    FirstName = "Principal",
                    SecondName = "Of",
                    LastName = "School",
                    Pin = "1243049888",
                    Address = "Street 52",
                    Town = "Sofia",
                    School = _ctx.Schools.FirstOrDefault()
                };


                var account = await CreateAspUser(principal, RoleTypes.Principal);

                if (account != null)
                {
                    principal.User = account;
                    principal.Id = account.Id;
                    _ctx.Principals.Add(principal);
                }
            }

            _logger.LogDebug("Principal Seeded");
            
            _logger.LogDebug("Start Seeding School Admin...");
            if (_ctx.SchoolUsers.FirstOrDefault(x => 
                    x.Role == RoleTypes.SchoolAdmin) == null)
            {
                var schoolAdmin = new SchoolAdmin
                {
                    FirstName = "School",
                    SecondName = "Admin",
                    LastName = "Test",
                    Pin = "1243049999",
                    Address = "45 Admin str.",
                    Town = "Sofia",
                    School = _ctx.Schools.FirstOrDefault()
                };


                var account = await CreateAspUser(schoolAdmin, RoleTypes.SchoolAdmin);

                if (account != null)
                {
                    schoolAdmin.User = account;
                    schoolAdmin.Id = account.Id;
                    _ctx.SchoolUsers.Add(schoolAdmin);
                }
            }

            _logger.LogDebug("School Admin Seeded");

            _ctx.SaveChanges();
        }

        private async Task SeedRoles()
        {
            _logger.LogInformation("Start Seeding Roles...");

            var roleNames = Enum.GetNames(typeof(RoleTypes));

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            _logger.LogInformation("End Seeding Roles...");
        }

        private async Task SeedUserAdmin()
        {
            _logger.LogInformation("Start Seeding Admin...");

            var userSettingsSection = _configuration.GetSection("UserSettings");

            var adminModel = new RegisterInputModel
            {
                Email = userSettingsSection["Email"],
                Password = userSettingsSection["Password"]
            };

            await _accountService.SeedAdmin(adminModel);
            _logger.LogInformation("End Seeding Admin...");
        }

        private void SeedGrades()
        {
            if (_ctx.Grades.FirstOrDefault() != null)
            {
                return;
            }

            _logger.LogInformation("Grades definition filepath ");

            var filepath = Path.Combine(_webHost.ContentRootPath,
                "DataAccessLayer/grades-bg.json");
            var gradesJson = File.ReadAllText(filepath);

            var grades =
                JsonConvert.DeserializeObject<ICollection<Grade>>(gradesJson);

            foreach (var grade in grades)
            {
                _repositories.Grades.Create(grade);
            }

            _logger.LogInformation("End Seeding Grades...");
        }

        private void SeedSchool()
        {
            if (_ctx.Schools.FirstOrDefault() != null)
            {
                return;
            }

            var defaultSchool = new School
            {
                Name = "Test School",
                Number = 0,
                Address = "Somewhere in Sofia"
            };
            _ctx.Schools.Add(defaultSchool);
            _ctx.SaveChanges();
        }

        private void SeedClass()
        {
            if (_ctx.Classes.FirstOrDefault() != null)
            {
                return;
            }

            var school = _ctx.Schools.FirstOrDefault();
            var defaultClass = new Class
            {
                StartYear = 2019,
                Grade = 1,
                GradeLetter = 'A',
            };
            if (school == null) return;
            defaultClass.School = school;
            _ctx.Classes.Add(defaultClass);
            _ctx.SaveChanges();
        }

        private async Task<User> CreateAspUser(SchoolUser schoolUser, RoleTypes role)
        {
            var accountRegister = new FullRegisterInputModel
            {
                Pin = schoolUser.Pin,
                FirstName = schoolUser.FirstName,
                LastName = schoolUser.LastName,
                RoleName = role.ToString()
            };
            return await _accountService.Register(accountRegister);
        }
    }
}