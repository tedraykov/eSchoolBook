using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolBook.DataAccessLayer;
using SchoolBook.DataAccessLayer.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Services;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.Helpers;
using SchoolBook.Helpers.Exceptions;

namespace SchoolBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(x =>
                    x.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<SchoolBookContext>(cfg =>
            {
                cfg.UseNpgsql(
                    Configuration.GetConnectionString(
                        "SchoolBookConnectionString"));
            });
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddControllersWithViews(options =>
                options.Filters.Add(typeof(CustomExceptionFilter)));


            //configure DI for services
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SchoolBookContext>();

            services.AddScoped<IRepositories, Repositories>();

            services.AddTransient<ISeeder, DatabaseInitializer>();

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IClassService, ClassService>();

            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettingsSection["Secret"]);

            services.Configure<JwtSettings>(jwtSettingsSection);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme =
                        JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/error-local-dev");
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
