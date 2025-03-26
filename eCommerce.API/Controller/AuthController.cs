using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Register")] // api/Auth/Register
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                if (request == null) { return BadRequest("Invalid Register data"); }

                AuthenticationResponse response = await userService.Register(request);

                if (response == null || response.Success == false) { return BadRequest(response); }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost("Login")]  // api/Auth/Login
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                if (request == null) { return BadRequest("Invalid login data"); }

                AuthenticationResponse response = await userService.Login(request);

                if (response == null || response.Success == false) { return BadRequest(response); }

                return StatusCode(200, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
