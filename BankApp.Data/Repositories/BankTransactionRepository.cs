using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class BankTransactionRepository : Repository<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BankTransaction>> GetWithDapper()
        {
            var sql = @"SELECT T.*, C.Name 
                FROM BankTransactions T INNER JOIN Categories C ON C.CategoryId = T.CategoryId";
            var items = await _connection.QueryAsync<BankTransaction, Category, BankTransaction>(sql, (transaction, category) =>
            {
                transaction.Category = category;
                return transaction;
            }, splitOn: "CategoryId");
            return items;
        }
    }
}
