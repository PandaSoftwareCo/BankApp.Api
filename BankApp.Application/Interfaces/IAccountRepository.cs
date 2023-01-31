using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<IEnumerable<Account>> GetWithDapper();
    }
}
