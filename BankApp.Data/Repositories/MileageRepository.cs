using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class MileageRepository : Repository<Mileage>, IMileageRepository
    {
        public MileageRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Mileage>> GetWithDapper()
        {
            var sql = @"SELECT * FROM Mileages";
            var items = await _connection.QueryAsync<Mileage>(sql);
            return items;
        }
    }
}
