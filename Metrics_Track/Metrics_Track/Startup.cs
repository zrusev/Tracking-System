namespace Metrics_Track
{
    using Metrics_Track.Data.Models;
    using Metrics_Track.Services.Implementations;
    using Metrics_Track.Services.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TrackerDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options =>  
                     {options.Password.RequireUppercase = false;
                      options.Password.RequireDigit = false;
                      options.Password.RequireNonAlphanumeric = false;
                      options.Password.RequireUppercase = false;})
                .AddEntityFrameworkStores<TrackerDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ICountry, Country>();
            services.AddTransient<IMining, Mining>();
            services.AddTransient<ITransaction, Transaction>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
