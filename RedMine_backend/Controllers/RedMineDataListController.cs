using Microsoft.AspNetCore.Mvc;
using DataBaseManager;
using DataBaseManager.DataBaseManager;
using System.IO;

namespace RedMine_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedMineDataList : ControllerBase
    {
        private readonly ILogger<RedMineDataList> _logger;

        public RedMineDataList(ILogger<RedMineDataList> logger)
        {
            _logger = logger;
        }

        [HttpGet] // Route template for LoadData action
        public async Task<IActionResult> LoadInitialData()
        {
            return Ok(x);
        }

        /*
        [HttpPost("filter")]
        public async Task<IActionResult> Filter 
        { 
         
        }
        */

        /*
        [HttpPost("project")]
        public async Task<IActionResult> Project()
        { 
        
        }
        */
        /*
        [HttpPost("addproject")]
        public async Task<IActionResult> addproject()
        { 
        
        }
        */

        /*
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        */

        /*
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        */
    }
}
