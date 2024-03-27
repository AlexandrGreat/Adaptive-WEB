using LR6.Health;
using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace LR6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DatabaseController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseService _databaseService;

        public DatabaseController(IConfiguration configuration,DatabaseService databaseService)
        {
            _configuration = configuration;
            _databaseService = databaseService;
        }

        [HttpGet("data")]
        public Task<JsonResult> Get()
        {
            string conLine = _configuration.GetConnectionString("DatabaseCon").ToString();
            return _databaseService.Get(conLine);
        }
    }
}
