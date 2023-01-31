using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetWithDapper()
        {
            var sql = @"SELECT * FROM Categories";
            var items = await _connection.QueryAsync<Category>(sql);
            return items;
        }
    }
}
