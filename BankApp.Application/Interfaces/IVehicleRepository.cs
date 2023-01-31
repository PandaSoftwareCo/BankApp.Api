using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IEnumerable<Vehicle>> GetWithDapper();
    }
}
