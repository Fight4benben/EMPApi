using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMSApi.Entity.PlainClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EMSApi.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {

        [HttpPost]
        public IActionResult Token([FromBody] LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (!(viewModel.User == "admin" && viewModel.Password == "123456"))
                {
                    return BadRequest();
                }

                var claim = new Claim[] {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Role,"admin")
                };

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your secret goes here"));

                var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


                var token = new JwtSecurityToken("The name of the issuser", "The name of the audience", claim, DateTime.Now, DateTime.Now.AddMinutes(50), creds);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }
    }

}