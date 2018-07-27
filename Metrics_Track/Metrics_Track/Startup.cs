namespace Metrics_Track
{
    using Metrics_Track.Data.Models;
    using Metrics_Track.Infrastructure.Extensions;
    using Metrics_Track.Infrastructure.Mapping;
    using Metrics_Track.Services.Admin.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration[Configuration.GetConnectionString("Connection")];

            services.AddDbContext<TrackerDbContext>(options =>
                options.UseSqlServer(connectionString,
                    x => x.MigrationsHistoryTable("__EFMigrationsHistory", "CPS")));

            services.AddIdentity<User, IdentityRole>(options =>  
                     {options.Password.RequireUppercase = false;
                      options.Password.RequireNonAlphanumeric = false;
                      options.Password.RequireDigit = false;

                      options.User.RequireUniqueEmail = true;
                     })
                .AddEntityFrameworkStores<TrackerDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            { 
                options.Cookie.Name = ".MetricsTrack.Identity.Application";
                options.ExpireTimeSpan = TimeSpan.FromHours(9);
                options.SlidingExpiration = false;
            });
            
            AutoMapperConfiguration.Configure();

            services.AddDomainServices();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDistributedMemoryCache();

            services.AddSession(options => {
                options.Cookie.Name = ".MetricsTrack.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.Configure<EmailConfigModel>(Configuration.GetSection("Email"));            
            services.Configure<EmailConfigModel>(options => options.UserPassword = Configuration["EmailPassword"]);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAntiforgeryTokens();            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "dashboard",
                 template: "{id}",
                 defaults: new { controller = "Dashboard", action = "Index" });

                routes.MapRoute(
                  name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
