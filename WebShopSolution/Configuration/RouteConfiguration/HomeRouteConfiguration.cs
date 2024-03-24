namespace WebShop.UI.Configuration.RouteConfiguration
{
    public static class HomeRouteConfiguration
    {
        public const string Index = "Index";
        public const string Privacy = "Privacy";

        public static void ConfigureRoutes(IEndpointRouteBuilder endpointRoute)
        {

            // Default index page for home
            endpointRoute.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

            endpointRoute.MapControllerRoute(
                name: Index,
                pattern: "home/index",
                defaults: new { Controller = "Home", Action = "SortPerson" }
                );






        }

    }
}
