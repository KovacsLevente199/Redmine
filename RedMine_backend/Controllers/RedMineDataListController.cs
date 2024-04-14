using Microsoft.AspNetCore.Mvc;
using DataBaseManager;
using DataBaseManager.DataBaseManager;
using RedMine_backend.Core.Services;
using System.Text.Json;
using RedMine_backend.Core.DataBase;
using System.Security.Cryptography;

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

        [HttpGet("loadinitial")]
        public async Task<IActionResult> LoadInitialData()
        {    
            DataBaseOperations result = new DataBaseOperations();
            return Ok(await result.QueryInitialProject());
        }


        [HttpPost("filter")]
        public async Task<IActionResult> Filter(ProjectType Tid) 
        {
            DataBaseOperations result = new DataBaseOperations();
            return Ok(await result.FilterByType(Tid.TypeOfProject));
        }



        [HttpPost("assignedtasks")]
        public async Task<IActionResult> AssignedTasks(ProjectNameDto Pid)
        {
            DataBaseOperations result = new DataBaseOperations();
            return Ok(await result.QueryByAssigned(Pid.ProjectID));
        }
        
        
        [HttpPost("addproject")]
        public async Task<IActionResult> addproject(ProjectParametesDto ProjectData)
        {
            DataBaseOperations result = new DataBaseOperations();
            return Ok(await result.AddToDatabase(ProjectData));
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDataDto UserInfo)
        {
            DataBaseOperations result = new DataBaseOperations();
            return Ok(await result.IsLoginValid(UserInfo));
        }

        /*
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDataDto UserInfo)
        {
            var test = new
            {
                adat1 = "Felhasználó név: "+ UserInfo.UserName,
                adat2 = "Jelszó: " + UserInfo.Password,
                adat3 = "Masik adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };
            return Ok(test);
        }
        */
    }
}
