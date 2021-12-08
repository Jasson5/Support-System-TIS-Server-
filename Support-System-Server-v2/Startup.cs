using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Entities.Exceptions;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Authentication.Entities;
using Authentication.DataAccess.Context;
using DataAccess.Context;
using DataAccess.Interfaces;
using Services.Interfaces;
using Services;
using DataAccess.Repositories;

namespace Support_System_Server_v2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "MyPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterTypes(services);

            Authentication.StartupHelper.RegisterTypes(services);
            Reports.StartupHelper.RegisterTypes(services);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<SupportSystemContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SupportSystemTISDatabase"), b => b.MigrationsAssembly("Support-System-Server-v2"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<SupportSystemContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Convert.ToDouble(Configuration["DefaultLockoutTimeSpan"]));
                options.Lockout.MaxFailedAccessAttempts = Int32.Parse(Configuration["MaxFailedAccessAttempts"]);
                options.Lockout.AllowedForNewUsers = true;
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ContextInitializer.SeedData(userManager, roleManager, Configuration);
            app.UseMiddleware<ExceptionHandler>();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("BlackBox 2021.");
                });
            });
        }

        public static void RegisterTypes(IServiceCollection services)
        {
            //Context
            services.AddTransient<IdentityDbContext, SupportSystemContext>();

            //Announcement
            services.AddTransient<IRepository<Announcement>, AnnouncementRepository>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();

            //Attendance
            services.AddTransient<IRepository<Attendance>, AttendanceRepository>();
            services.AddTransient<IAttendanceService, AttendanceService>();

            //Calendar
            services.AddTransient<IRepository<Calendar>, CalendarRepository>();
            services.AddTransient<ICalendarService, CalendarService>();

            //Company
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICompanyService, CompanyService>();

            //Homework
            services.AddTransient<IRepository<Homework>, HomeworkRepository>();
            services.AddTransient<IHomeworkService, HomeworkService>();

            //Offer
            services.AddTransient<IRepository<Offer>, OfferRepository>();
            services.AddTransient<IOfferService, OfferService>();

            //Semester
            services.AddTransient<ISemesterRepository, SemesterRepository>();
            services.AddTransient<ISemesterService, SemesterService>();
        }
    }
}
