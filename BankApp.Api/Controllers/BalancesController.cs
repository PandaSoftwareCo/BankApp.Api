using AutoMapper;
using BankApp.Application.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<BalancesController> _logger;

        public BalancesController(IBalanceRepository balanceRepository, IMapper mapper, IConfiguration configuration, IAppSettings appSettings, ILogger<BalancesController> logger)
        {
            _balanceRepository = balanceRepository ?? throw new ArgumentNullException(nameof(balanceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<BalancesController>
        [HttpGet]
        public IAsyncEnumerable<Balance> Get()
        {
            return _balanceRepository.Get();
        }

        // GET: api/<BalancesController>/GetWithDapper
        [HttpGet("[action]")]
        public async Task<IEnumerable<Balance>> GetWithDapper()
        {
            return await _balanceRepository.GetWithDapper();
        }

        // GET api/<BalancesController>/5
        [HttpGet("{id}")]
        public async Task<Balance?> Get(int id)
        {
            return await _balanceRepository.FindAsync(id);
        }

        // POST api/<BalancesController>
        [HttpPost]
        public async Task<ActionResult<Balance>> Post([FromBody] Balance value)
        {
            _balanceRepository.Add(value);
            await _balanceRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBalance", new { id = value.BalanceId }, value);
        }

        // PUT api/<BalancesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Balance value)
        {
            if (id != value.AccountId)
            {
                return BadRequest();
            }

            _balanceRepository.Update(value);

            try
            {
                await _balanceRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _balanceRepository.FindAsync(id);
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

        // DELETE api/<BalancesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _balanceRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _balanceRepository.Delete(item);
            await _balanceRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
