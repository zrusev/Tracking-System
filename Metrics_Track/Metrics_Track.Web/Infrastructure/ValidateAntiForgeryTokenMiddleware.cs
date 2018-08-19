namespace Metrics_Track.Web.Infrastructure
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Antiforgery;
    using Microsoft.AspNetCore.Http;

    public class ValidateAntiForgeryTokenMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IAntiforgery antiforgery;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            this.next = next;
            this.antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            if (HttpMethods.IsPost(context.Request.Method))
            {
                await this.antiforgery.ValidateRequestAsync(context);
            }

            await this.next(context);
        }
    }
}
