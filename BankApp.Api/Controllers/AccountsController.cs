using AutoMapper;
using BankApp.Application.DTOs;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<AccountsController> _logger;

        public AccountsController(IAccountRepository accountRepository, IMapper mapper, IConfiguration configuration, IAppSettings appSettings, ILogger<AccountsController> logger)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<AccountsController>
        [HttpGet]
        [Swashbuckle.AspNetCore.Annotations.SwaggerOperation("Retrieves all accounts")]
        public async IAsyncEnumerable<Account> Get()
        {
            await foreach(var item in _accountRepository.Get())
            {
                yield return item;
            }
            //return _accountRepository.Get();
        }

        // GET: api/<AccountsController>/GetWithDapper
        [HttpGet("[action]")]
        public async Task<IEnumerable<Account>> GetWithDapper()
        {
            return await _accountRepository.GetWithDapper();
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<AccountDto?> Get(int id)
        {
            return _mapper.Map<AccountDto>(await _accountRepository.FindAsync(id));
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<ActionResult<AccountDto>> Post([FromBody] AccountDto value)
        {
            _accountRepository.Add(_mapper.Map<Account>(value));
            await _accountRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = value.AccountId }, value);
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Account value)
        {
            if (id != value.AccountId)
            {
                return BadRequest();
            }

            _accountRepository.Update(value);

            try
            {
                await _accountRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _accountRepository.FindAsync(id);
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

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _accountRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _accountRepository.Delete(item);
            await _accountRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
