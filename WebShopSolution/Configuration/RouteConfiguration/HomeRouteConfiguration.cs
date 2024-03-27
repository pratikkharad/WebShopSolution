using WebShop.Core.DTO;

namespace WebShop.UI.Configuration.RouteConfiguration
{
    public static class HomeRouteConfiguration
    {
        public const string Index = "Index";
        public const string Login = "Login";

        public static void ConfigureRoutes(IEndpointRouteBuilder endpointRoute)
        {

            // Default index page for home
            endpointRoute.MapControllerRoute(
               name: "default",
               pattern: "{controller=Login}/{action=Index}/{id?}");

            endpointRoute.MapControllerRoute(
                name: Index,
                pattern: "home/index",
                defaults: new { Controller = "Home", Action = "SortPerson" }
                );

            endpointRoute.MapControllerRoute(
                name: "Home",
                pattern: "home/index"                
                );





        }

    }
}
