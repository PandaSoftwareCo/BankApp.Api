using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Dapper;

namespace BankApp.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(BankContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Vehicle>> GetWithDapper()
        {
            var sql = @"SELECT * FROM Vehicles";
            var items = await _connection.QueryAsync<Vehicle>(sql);
            return items;
        }
    }
}
