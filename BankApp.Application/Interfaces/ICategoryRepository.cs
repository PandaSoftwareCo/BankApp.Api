using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetWithDapper();
    }
}
