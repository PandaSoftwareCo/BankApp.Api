using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;

namespace BankApp.Data.Repositories
{
    public class BalanceRepository : Repository<Balance>, IBalanceRepository
    {
        public BalanceRepository(BankContext context) : base(context)
        {
        }
    }
}
