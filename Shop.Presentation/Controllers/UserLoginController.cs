using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Domains;
using Shop.Application.Interfaces;

namespace Shop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : Controller
    {
        private IConfiguration _config;
        private readonly IUserService _service;
        private readonly ILogger<CustomersManagementController> _logger;

       

        public UserManagementController(IConfiguration config, IUserService service, ILogger<CustomersManagementController> logger)
        {
            _config = config;
            _service = service ?? throw new NullReferenceException(nameof(service));
            _logger = logger ?? throw new NullReferenceException(nameof(logger));
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel entity)
        {
            _logger.LogDebug("UserManagementController: Register() called");
            return Ok(_service.Add<UserModel>(entity));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("USers");
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                              };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.UserName == "Jignesh")
            {
                user = new UserModel { UserName = "Jignesh Trivedi", Email = "test.btest@gmail.com" };
            }
            return user;
        }
    }
}
