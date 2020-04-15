using System;
using System.IO;
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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Interfaces.SchoolUserServices;
using SchoolBook.BusinessLogicLayer.Services;
using SchoolBook.BusinessLogicLayer.Services.SchoolUserServices;
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(x =>
                    x.SerializerSettings.ReferenceLoopHandling =
                        ReferenceLoopHandling.Ignore);
            
            //Database connection
            services.AddDbContext<SchoolBookContext>(cfg =>
            {
                cfg.UseNpgsql(Environment.GetEnvironmentVariable("ESCHOOLBOOK_ENV_CONNECTION_STRING"));
            });
            
            //Automapper
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddControllersWithViews(options =>
                options.Filters.Add(typeof(CustomExceptionFilter)));
            
            //Configure IdentityUser
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SchoolBookContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            });

            services.AddScoped<IRepositories, Repositories>();

            services.AddTransient<ISeeder, DatabaseInitializer>();

            //configure DI for services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<ISubjectService, SubjectService>();
            
            services.AddTransient<ISchoolUserService, SchoolUserService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IPrincipalService, PrincipalService>();
            services.AddTransient<IParentService, ParentService>();
            services.AddTransient<ISchoolAdminService, SchoolAdminService>();

            services.AddTransient<ISchoolService, SchoolService>();
            services.AddTransient<ICurriculumService, CurriculumService>();
            services.AddTransient<IStatisticalService, StatisticalService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IParentService, ParentService>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes((jwtSettingsSection["Secret"].ToString()));
            
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
                
                app.UseDeveloperExceptionPage();
                app.UseCors("AllowAll");
            }
            
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
//                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
