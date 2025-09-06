using ApiGateway.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "admin" && password == "admin")
            {
                var token = TokenService.GenerateToken(new Models.AuthModel());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
