using LR6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0",Deprecated = true)]
    public class LR9Controller : ControllerBase
    {
        private readonly LR9Service _lr9;

        public LR9Controller(LR9Service lr9)
        {
            _lr9 = lr9;
        }

        [HttpGet]
        public Task<int> Get()
        {
            return _lr9.GetInt();
        }
    }
}
