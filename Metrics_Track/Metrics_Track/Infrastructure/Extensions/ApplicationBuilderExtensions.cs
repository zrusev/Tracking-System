namespace Metrics_Track.Infrastructure.Extensions
{
    using Metrics_Track.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAntiforgeryTokens(this IApplicationBuilder app)
            => app.UseMiddleware<ValidateAntiForgeryTokenMiddleware>();        

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<TrackerDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
