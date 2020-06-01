using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Services;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using PhotOn.Core.Repositories.Base;
using PhotOn.Infrastructure.Data;
using PhotOn.Infrastructure.Repository;
using PhotOn.Infrastructure.Repository.Base;
using PhotOn.Web.Service;

namespace PhotOn.Web
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

            ConfigurePhotOnServices(services);

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
        }

        private void ConfigurePhotOnServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IEditRepository<>), typeof(EditRepository<>));
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Application Layer
            services.AddScoped<IPublicationService, PublicationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IFileStorageServcie, AzureStorageService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IUtilService, UtilService>();
            services.AddScoped<IEventService, EventService>();

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup));
        }

        public void ConfigureDatabases(IServiceCollection services)
        {

            services.AddDbContext<PhotOnContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("PhotOnDbConnection"));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PhotOnContext>()
                .AddDefaultTokenProviders();

            var issuer = Configuration["Tokens:Issuer"];
            var audience = Configuration["Tokens:Audience"];
            var key = Configuration["Tokens:Key"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    };
                });


            services.AddAuthentication()
                .AddFacebook(options =>
            {
                options.AppId = Configuration["FacebookAppId"];
                options.AppSecret = Configuration["FacebookAppSecret"];
            })
                .AddGoogle(options =>
                { 
                    options.ClientId = Configuration["GoogleClientId"];
                    options.ClientSecret = Configuration["GoogleClientSecret"];
                }); 

            services.Configure<SmtpOptions>(Configuration.GetSection("Smtp"));

            services.AddScoped<IEmailSender, SmptEmailSender>();

            services.Configure<IdentityOptions>(options => {

                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            });
        }
    }
}
