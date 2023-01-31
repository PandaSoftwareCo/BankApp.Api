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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAppSettings _appSettings;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper, IConfiguration configuration, IAppSettings appSettings, ILogger<CategoriesController> logger)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _appSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IAsyncEnumerable<Category> Get()
        {
            return _categoryRepository.Get();
        }

        // GET: api/<CategoriesController>/GetWithDapper
        [HttpGet("[action]")]
        public async Task<IEnumerable<Category>> GetWithDapper()
        {
            return await _categoryRepository.GetWithDapper();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Category?> Get(int id)
        {
            return await _categoryRepository.FindAsync(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category value)
        {
            _categoryRepository.Add(value);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = value.CategoryId }, value);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category value)
        {
            if (id != value.CategoryId)
            {
                return BadRequest();
            }

            _categoryRepository.Update(value);

            try
            {
                await _categoryRepository.UnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var item = await _categoryRepository.FindAsync(id);
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

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _categoryRepository.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _categoryRepository.Delete(item);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
