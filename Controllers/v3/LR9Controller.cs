using LR6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LR6.Controllers.V3
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("3.0")]
    public class LR9Controller : ControllerBase
    {
        private readonly LR9Service _lr9;

        public LR9Controller(LR9Service lr9)
        {
            _lr9 = lr9;
        }

        [HttpGet]
        public Task<FileStreamResult> Get()
        {
            return _lr9.GetExcel();
        }
    }
}
