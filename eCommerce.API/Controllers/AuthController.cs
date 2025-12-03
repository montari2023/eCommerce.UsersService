using eCommerce.Core.DTO;
using eCommerce.Core.SeriviceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
           _usersService = usersService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request )
        {
            if( request is null)
            {
                return BadRequest("Invalid Registration Data");
            }
            AuthenticationResponse? response =await _usersService.RegisterRequest(request);

            if (response is null || response.Sucess == false)
            {
                return BadRequest(response);
            }
            return Ok(response);

        }
        [HttpGet("login")]
        public async Task<IActionResult> login([FromBody] LoginRequest request)
        {
            if (request is null)
            {
                return BadRequest("Invalid Login Data");
            }
            AuthenticationResponse? response = await _usersService.LoginRequest(request);
            if (response is null || response.Sucess == false)
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }

    }
}
