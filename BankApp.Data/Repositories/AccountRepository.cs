using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Account>> GetWithDapper()
        {
            var sql = @"SELECT * FROM Accounts";
            var accounts = await _connection.QueryAsync<Account>(sql);
            return accounts;
        }
    }
}
