using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface IBankTransactionRepository : IRepository<BankTransaction>
    {
        Task<IEnumerable<BankTransaction>> GetWithDapper();
    }
}
