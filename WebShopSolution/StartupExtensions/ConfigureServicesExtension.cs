using WebShop.Core.ServiceContracts;
using WebShop.Core.Services;
using WebShop.Domain.RepositoryContract;
using WebShop.Infrastructure.Repositorie;
using WebShop.UI.Configuration.HealthCheckConfiguration;




namespace WebShop.UI.StartupExtensions
{
    public static class ConfigureServicesExtension
    {

        public static IConfiguration Configuration { get; private set; }

        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Anti-CSRF Protection
            services.AddAntiforgery(options => 
            {
                options.HeaderName = "X-CSRF-TOKEN";// Custom header name
            }); 

            services.AddScoped<IBreadcrumbService, BreadcrumbService>();

            // check the inmemorystore heath 
            services.AddHealthChecks()
               .AddCheck<InMemoryStoreHealthCheck>("in_memory_store");

            services.AddHealthChecksUI()
            .AddInMemoryStorage();// Use in-memory storage for simplicity; you may use a database for production


            services.AddScoped<IPersonGetterContracts, PersonGetterService>();
            services.AddScoped<IPersonGetterRepoContract, PersonRepository>();








            return services;
        }

        
    }
}
