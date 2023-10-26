using jwt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
namespace jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        private Users AuthinticationUser(Users user)
        {
            Users _user = null;
            if (user.UserName == "admin" && user.Password == "123")
            {
                _user = new Users { UserName = "aau" };
            }
            return _user;

        }
        private string Generation(Users user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));
            var credintial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credintial);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login(Users user)
        {
            IActionResult response = Unauthorized();
            var user_=AuthinticationUser(user);
            if (user_!=null)
            {
                var token=Generation(user_);
                response=Ok(new { token = token });
            }
            return response;
        }
    }
}
