using LR6.Models;
using LR6.Services;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SerilogDemoController:ControllerBase
    {
        private readonly SerilogDemoService _serilogService;

        public SerilogDemoController(SerilogDemoService serilogDemoService)
        {
            _serilogService = serilogDemoService;
        }

        [HttpGet]
        public Task<string> Get()
        {
            return _serilogService.Get();
        }
    }
}
