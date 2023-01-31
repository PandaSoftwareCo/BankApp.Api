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
    public class BankTransactionsController : ControllerBase
    {
        private readonly IBankTransactionRepository _bankTransactionRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<BankTransactionsController> _logger;

        public BankTransactionsController(IBankTransactionRepository bankTransactionRepository, IMapper mapper, IConfiguration configuration, IAppSettings appSettings, ILogger<BankTransactionsController> logger)
        {
            _bankTransactionRepository = bankTransactionRepository ?? throw new ArgumentNullException(nameof(bankTransactionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<BankTransactionsController>
        [HttpGet]
        public IAsyncEnumerable<BankTransaction> Get([FromQuery] string term)
        {
            return _bankTransactionRepository.Get();
        }

        // GET: api/<BankTransactionsController>/GetWithDapper
        [HttpGet("[action]")]
        public async Task<IEnumerable<BankTransaction>> GetWithDapper()
        {
            return await _bankTransactionRepository.GetWithDapper();
        }

        // GET api/<BankTransactionsController>/5
        [HttpGet("{id}")]
        public async Task<BankTransaction?> Get(int id)
        {
            return await _bankTransactionRepository.FindAsync(id);
        }

        // POST api/<BankTransactionsController>
        [HttpPost]
        public async Task<ActionResult<BankTransaction>> Post([FromBody] BankTransaction value)
        {
            _bankTransactionRepository.Add(value);
            await _bankTransactionRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetBankTransaction", new { id = value.BankTransactionId }, value);
        }

        // PUT api/<BankTransactionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BankTransaction value)
        {
            if (id != value.AccountId)
            {
                return BadRequest();
            }

            _bankTransactionRepository.Update(value);

            try
            {
                await _bankTransactionRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _bankTransactionRepository.FindAsync(id);
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

        // DELETE api/<BankTransactionsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _bankTransactionRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _bankTransactionRepository.Delete(item);
            await _bankTransactionRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
