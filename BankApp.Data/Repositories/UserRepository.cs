using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetWithDapper()
        {
            var sql = @"SELECT * FROM Users";
            var items = await _connection.QueryAsync<User>(sql);
            return items;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var sql = @$"SELECT * FROM Users WHERE Username = {username}";
            var item = await _connection.QuerySingleOrDefaultAsync<User>(sql);
            return item;
        }
    }
}
