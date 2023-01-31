using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface IMileageRepository : IRepository<Mileage>
    {
        Task<IEnumerable<Mileage>> GetWithDapper();
    }
}
