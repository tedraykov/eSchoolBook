using System.Collections;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SchoolBook.DataAccessLayer.Entities;

namespace SchoolBook.DataAccessLayer
{
    public class SchoolBookSeeder
    {
        private readonly SchoolBookContext _ctx;
        private readonly IWebHostEnvironment _webHost;
        private readonly ILogger<SchoolBookSeeder> _logger;

        public SchoolBookSeeder(SchoolBookContext ctx, IWebHostEnvironment webHost, ILogger<SchoolBookSeeder> logger)
        {
            _ctx = ctx;
            _webHost = webHost;
            _logger = logger;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();
            _logger.LogInformation("Database is created");
            if (_ctx.Grades.Any())
            {
                _logger.LogDebug("There are existing entries in Grades table");
                return;
            }

            _logger.LogInformation("Grades definition filepath ");
            var filepath = Path.Combine(_webHost.ContentRootPath,
                "DataAccessLayer/grades-bg.json");
            var gradesJson = File.ReadAllText(filepath);

            var grades = JsonConvert.DeserializeObject<ICollection<Grade>>(gradesJson);
            _logger.LogInformation(grades.ToString());
            _ctx.Grades.AddRange(grades);

            _ctx.SaveChanges();
        }
    }
}
