using BankApp.Application.DTOs.User;
using BankApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // POST api/<AuthController>
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticateResponse>> Login([FromBody] AuthenticateRequest value)
        {
            return _userService.Authenticate(value);
        }
    }
}
