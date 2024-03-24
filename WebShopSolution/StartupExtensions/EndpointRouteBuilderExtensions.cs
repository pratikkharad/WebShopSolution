using WebShop.UI.Configuration.RouteConfiguration;

namespace WebShop.UI.StartupExtensions
{
    public static class EndpointRouteBuilderExtensions
    {
        /// <summary>
        /// This method is responsible for the create route 
        /// </summary>
        /// <param name="endpointRoute"></param>
        public static void ConfigureEndpoints(this IEndpointRouteBuilder endpointRoute)
        {
            endpointRoute.MapHealthChecks("/health");
            endpointRoute.MapHealthChecksUI(options =>
            {
                options.UIPath = "/healthchecks-ui";
            });
            

            HomeRouteConfiguration.ConfigureRoutes(endpointRoute);
        }
    }
}
