using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;

namespace BankApp.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(BankContext context) : base(context)
        {
        }
    }
}
