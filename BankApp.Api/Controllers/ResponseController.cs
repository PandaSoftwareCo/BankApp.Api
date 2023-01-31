using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly ILogger<ResponseController> _logger;

        public ResponseController(ILogger<ResponseController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("[action]/{id:int}")]
        public ActionResult GetResponse(int id)
        {
            Random random = new Random();
            int randomInt = random.Next(1, 101);
            if(randomInt >= id)
            {
                _logger.LogInformation("FAIL");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _logger.LogInformation("SUCCESS");
            return Ok();
        }
    }
}
