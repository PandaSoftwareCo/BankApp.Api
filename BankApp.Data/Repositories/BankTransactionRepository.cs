using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;

namespace BankApp.Data.Repositories
{
    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(BankContext context) : base(context)
        {
        }
    }
}
