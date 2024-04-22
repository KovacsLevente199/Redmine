using Microsoft.AspNetCore.Mvc;
using DataBaseManager;
using DataBaseManager.DataBaseManager;
using RedMine_backend.Core.Services;
using System.Text.Json;
using RedMine_backend.Core.DataBase;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RedMine_backend.Core.Services.Authentication;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> LoadInitialData()
        {    
            DataBaseOperations result = new DataBaseOperations();
            return Ok(await result.QueryInitialProject());
        }


        [HttpPost("filter")]
        [Authorize]
        public async Task<IActionResult> Filter(ProjectType Tid) 
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();
                var filteredData = await result.FilterByType(Tid.TypeOfProject);
                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }



        [HttpPost("assignedtasks")]
        [Authorize]
        public async Task<IActionResult> AssignedTasks(ProjectNameDto Pid)
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();
                return Ok(await result.QueryByAssigned(Pid.ProjectID));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }
        
        
        [HttpPost("addtask")]
        [Authorize]
        public async Task<IActionResult> addtask(ProjectParametersDto ProjectData)
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();
                return Ok(await result.AddToDatabase(ProjectData));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }

        [HttpPost("tasksbymanager")]
        [Authorize]
        public async Task<IActionResult> TasksByManager(TasksParamDto taskobj)
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();
                return Ok(await result.CreatedByManager(taskobj.UserID));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }

        [HttpPost("taskdeadline")]
        [Authorize]
        public async Task<IActionResult> TaskDeadLine(TasksParamDto taskobj)
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();
                return Ok(await result.GetDeadLine(taskobj.UserID));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }

        [HttpPost("listdevelopers")]
        [Authorize]
        public async Task<IActionResult> ListDevelopers()
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();
                return Ok(await result.QueryDevelopers());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserDataDto UserInfo)
        {
            try
            {
                DataBaseOperations result = new DataBaseOperations();

                if(await result.IsLoginValid(UserInfo))
                {
                    var token = AuthenticationServices.GenerateJwtToken(UserInfo.UserName);
                    HttpContext.Response.Headers.Authorization = token;
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error" + ex.ToString());
            }
        }
    }
}
