using AutoMapper;
using BankApp.Application.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IVehicleRepository vehicleRepository, IMapper mapper, IConfiguration configuration, IAppSettings appSettings, ILogger<VehicleController> logger)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<VehicleController>
        [HttpGet]
        public async IAsyncEnumerable<Vehicle> Get()
        {
            //var name = this.User.Claims;
            await foreach (var item in _vehicleRepository.Get())
            {
                yield return item;
            }
            //return _accountRepository.Get();
        }

        // GET: api/<VehicleController>/GetWithDapper
        [HttpGet("[action]")]
        public async Task<IEnumerable<Vehicle>> GetWithDapper()
        {
            return await _vehicleRepository.GetWithDapper();
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<Vehicle?> Get(int id)
        {
            return await _vehicleRepository.FindAsync(id);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task<ActionResult<Vehicle>> Post([FromBody] Vehicle value)
        {
            _vehicleRepository.Add(value);
            await _vehicleRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetVehicle", new { id = value.VehicleId }, value);
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vehicle value)
        {
            if (id != value.VehicleId)
            {
                return BadRequest();
            }

            _vehicleRepository.Update(value);

            try
            {
                await _vehicleRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _vehicleRepository.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _vehicleRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _vehicleRepository.Delete(item);
            await _vehicleRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
