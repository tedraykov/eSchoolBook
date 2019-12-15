using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolBook.DataAccessLayer;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SchoolBook.BusinessLogicLayer.DTOs;
using SchoolBook.BusinessLogicLayer.Interfaces;
using SchoolBook.BusinessLogicLayer.Services;
using SchoolBook.DataAccessLayer.Entities;
using SchoolBook.DataAccessLayer.Interfaces;
using SchoolBook.Helpers;

namespace SchoolBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            
            services.AddAutoMapper(typeof(Startup));
            
            services.AddDbContext<SchoolBookContext>(cfg =>
            {
                cfg.UseNpgsql(Configuration.GetConnectionString("SchoolBookConnectionString"));
            });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SchoolBookContext>();

            //configure DI for services
            services.AddScoped<IRepositories, Repositories>();
            
            services.AddTransient<IAccountService, AccountService>();


            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettingsSection["Secret"]);
            
            services.Configure<JwtSettings>(jwtSettingsSection);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
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

        // This method gets called by the runtime. Use this method to add services to the container.

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*app.UseHttpsRedirection();*/
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                new DatabaseInitializer()
                    .Seed(serviceScope.ServiceProvider, this.Configuration)
                    .Wait();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
