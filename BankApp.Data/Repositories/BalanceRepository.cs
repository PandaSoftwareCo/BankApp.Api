using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class BalanceRepository : Repository<Balance>, IBalanceRepository
    {
        public BalanceRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Balance>> GetWithDapper()
        {
            var sql = @"SELECT * FROM Balances";
            var items = await _connection.QueryAsync<Balance>(sql);
            return items;
        }
    }
}
