using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;

namespace BankApp.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BankContext context) : base(context)
        {
        }
    }
}
