using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebShop.UI.Configuration.HealthCheckConfiguration
{
    public class InMemoryStoreHealthCheck : IHealthCheck
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryStoreHealthCheck(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // Perform a simple read and write operation to check if the in-memory store is working
                var key = "healthcheck_test_key";
                _memoryCache.Set(key, DateTime.UtcNow, TimeSpan.FromSeconds(1));

                if (_memoryCache.TryGetValue(key, out _))
                {
                    return Task.FromResult(HealthCheckResult.Healthy("In-memory store is healthy."));
                }
                else
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy("In-memory store is not functioning properly."));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy($"Error checking in-memory store health: {ex.Message}"));
            }
        }
    }
}
