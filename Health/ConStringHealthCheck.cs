using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data.SqlClient;

namespace LR6.Health
{
    public class ConStringHealthCheck:IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public ConStringHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            string conLine = _configuration.GetConnectionString("DatabaseCon").ToString();
            if (string.IsNullOrEmpty(conLine))
            { 
                return HealthCheckResult.Unhealthy();
            }
            else
                return HealthCheckResult.Healthy();
        }
    }
}
