using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        Task<IEnumerable<Balance>> GetWithDapper();
    }
}
