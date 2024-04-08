using Microsoft.AspNetCore.Mvc;
using DataBaseManager;
using DataBaseManager.DataBaseManager;
using RedMine_backend.Core.Services;
using System.Text.Json;

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

        [HttpGet("loadinitial")] // Route template for LoadData action
        public async Task<IActionResult> LoadInitialData()
        {
            /*
            DataBaseOperations result = new DataBaseOperations();
            return Ok(result.DtoToJSON(result.QueryByProject()));
            */
            var test = new
            {
                adat1 = "Adatok a loadinitial vegpontrol",
                adat2 = "Az egy adat a szerverrol",
                adat3 = "Masik adat a szerverrõl",
                adat4 = new 
                { 
                    adat5 = "meg egy adat"
                }
            };
            return Ok(test);
        }

        
        [HttpPost("filter")]
        public async Task<IActionResult> Filter() 
        {
            var test = new
            {
                adat1 = "Adatok a filter vegpontrol",
                adat2 = "Az egy adat a szerverrol",
                adat3 = "Masik adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };
            return Ok(test);
        }
        

        
        [HttpPost("assignedtasks")]
        //public async Task<IActionResult> AssignedTasks(string Project)
        public async Task<IActionResult> AssignedTasks()
        {
            /*
            DataBaseOperations result = new DataBaseOperations();
            return Ok(JsonSerializer.Serialize((result.QueryByAssigned(Project))));
            */

            var test = new
            {
                adat1 = "Adatok a assignedtasks vegpontrol",
                adat2 = "Az egy adat a szerverrol",
                adat3 = "Masik adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };

            return Ok(test);
        }
        
        
        [HttpPost("addproject")]
        public async Task<IActionResult> addproject()
        {
            var test = new
            {
                adat1 = "Adatok a addproject vegpontrol",
                adat2 = "Az egy adat a szerverrol",
                adat3 = "Masik adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };

            return Ok(test);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            var test = new
            {
                adat1 = "Adatok a login vegpontrol",
                adat2 = "Az egy adat a szerverrol",
                adat3 = "Masik adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };
            return Ok(test);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            var test = new
            {
                adat1 = "Adatok a register vegpontrol",
                adat2 = "Az egy adat a szerverrol",
                adat3 = "Masik adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };
            return Ok(test);
        }
    }
}
