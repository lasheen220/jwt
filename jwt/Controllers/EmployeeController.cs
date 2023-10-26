using jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Authorize]
      [HttpGet]
        [Route("GetData")]
      public string Get()
        {
            return "Authinticated done";
        }
     
        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authinticated done";
        }

        [Authorize]
        [HttpPost]
       
        public string AddUser(Users user)
        {
            return "user added with username:"+user.UserName;
        }
    }
}
