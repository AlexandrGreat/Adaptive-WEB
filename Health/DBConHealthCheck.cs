using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using LR6.Models;
using LR6.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.Json;

namespace LR6.Health
{
    public partial class DBConHealthCheck:IHealthCheck
    {
        private readonly IConfiguration _configuration;

        public DBConHealthCheck(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            try
            {
                string conLine = _configuration.GetConnectionString("DatabaseCon").ToString();
                SqlConnection con = new SqlConnection(conLine);
                SqlDataAdapter da = new SqlDataAdapter("Select * from ProductsLR6", con);
                Console.WriteLine(da);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0) throw new Exception("Connection Error");
                return HealthCheckResult.Healthy();
            }
            catch(Exception ex)
            {
                return HealthCheckResult.Unhealthy(exception:ex);
            }
        }
    }
}
