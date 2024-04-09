using Microsoft.AspNetCore.Mvc;
using DataBaseManager;
using DataBaseManager.DataBaseManager;
using RedMine_backend.Core.Services;
using System.Text.Json;
using RedMine_backend.Core.DataBase;

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
        public async Task<IActionResult> Filter(ProjectType Tid) 
        {
            var test = new
            {
                adat1 = "A típusID: " + Tid.TypeID,
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
        public async Task<IActionResult> AssignedTasks(ProjectIDDto Pid)
        {
            /*
            DataBaseOperations result = new DataBaseOperations();
            return Ok(JsonSerializer.Serialize((result.QueryByAssigned(Project))));
            */

            var test = new
            {
                adat1 = "ProjektID: "+Pid.ProjectID,
                adat2 = "Feladat1",
                adat3 = "Feladat2",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };

            return Ok(test);
        }
        
        
        [HttpPost("addproject")]
        public async Task<IActionResult> addproject(ProjectsDto ProjectData)
        {
            var test = new
            {
                adat1 = "Projekt neve: " + ProjectData.Name,
                adat2 = "Projekt id: "+ ProjectData.ID,
                adat3 = "Projekt leírása: " + ProjectData.Description,
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };

            return Ok(test);
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login(UserDataDto UserInfo)
        {

            var test = new
            {
                adat1 = "A klienstõl kapott adatokat és a szerver adatait is tartalmazza a válasz",
                adat2 = UserInfo.UserName + " "+UserInfo.Password,
                adat3 = "adat a szerverrõl",
                adat4 = new
                {
                    adat5 = "meg egy adat"
                }
            };
            return Ok(test);
        }


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
    }
}
