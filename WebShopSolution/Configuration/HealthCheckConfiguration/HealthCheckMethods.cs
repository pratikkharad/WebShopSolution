//using Microsoft.Extensions.Diagnostics.HealthChecks;

//namespace WebShop.UI.Configuration.HealthCheckConfiguration
//{
//    public static class HealthCheckMethods
//    {
//        public static HealthCheckResult CheckFileSystem(string path)
//        {
//            try
//            {
//                // Check if the specified directory exists and has sufficient disk space
//                // Replace this with the actual file system health check logic
//                var isFileSystemHealthy = FileSystemChecker.CheckHealth(path);

//                return isFileSystemHealthy
//                    ? HealthCheckResult.Healthy("File system is healthy")
//                    : HealthCheckResult.Unhealthy("File system is not in a healthy state");
//            }
//            catch (Exception ex)
//            {
//                return HealthCheckResult.Unhealthy($"File system check failed: {ex.Message}");
//            }
//        }

//        public static HealthCheckResult CheckBackgroundJobs()
//        {
//            try
//            {
//                // Check the status of background jobs (e.g., verify if scheduled tasks are running)
//                // Replace this with the actual background jobs health check logic
//                var areJobsRunning = BackgroundJobChecker.CheckStatus();

//                return areJobsRunning
//                    ? HealthCheckResult.Healthy("Background jobs are running")
//                    : HealthCheckResult.Unhealthy("Background jobs are not running");
//            }
//            catch (Exception ex)
//            {
//                return HealthCheckResult.Unhealthy($"Background jobs check failed: {ex.Message}");
//            }
//        }


//        public static HealthCheckResult CheckThirdPartyService(string serviceEndpoint)
//        {
//            try
//            {
//                // Check the availability of a third-party service (e.g., make a request to the service)
//                // Replace this with the actual third-party service health check logic
//                var isServiceHealthy = ThirdPartyServiceChecker.CheckHealth(serviceEndpoint);

//                return isServiceHealthy
//                    ? HealthCheckResult.Healthy("Third-party service is healthy")
//                    : HealthCheckResult.Unhealthy("Third-party service is not responding as expected");
//            }
//            catch (Exception ex)
//            {
//                return HealthCheckResult.Unhealthy($"Third-party service check failed: {ex.Message}");
//            }
//        }

//        public static HealthCheckResult CheckExternalService(string serviceName, Uri serviceUri)
//        {
//            try
//            {
//                // Perform a health check on the external service (e.g., make a request to the service)
//                // Replace this with the actual health check logic
//                var isServiceHealthy = ExternalServiceChecker.CheckHealth(serviceUri);

//                return isServiceHealthy
//                    ? HealthCheckResult.Healthy($"{serviceName} is healthy")
//                    : HealthCheckResult.Unhealthy($"{serviceName} is not responding as expected");
//            }
//            catch (Exception ex)
//            {
//                return HealthCheckResult.Unhealthy($"{serviceName} check failed: {ex.Message}");
//            }
//        }

//        public static HealthCheckResult CheckMessagingQueue(string connectionString)
//        {
//            try
//            {
//                // Check the availability of the messaging queue (e.g., connect to the queue)
//                // Replace this with the actual messaging queue health check logic
//                var isQueueHealthy = MessagingQueueChecker.CheckHealth(connectionString);

//                return isQueueHealthy
//                    ? HealthCheckResult.Healthy("Messaging queue is healthy")
//                    : HealthCheckResult.Unhealthy("Messaging queue is not accessible");
//            }
//            catch (Exception ex)
//            {
//                return HealthCheckResult.Unhealthy($"Messaging queue check failed: {ex.Message}");
//            }
//        }
//    }
//}
