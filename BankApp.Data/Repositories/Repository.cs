using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BankContext _context;
        protected readonly DbConnection _connection;

        public IUnitOfWork UnitOfWork => _context;

        public Repository(BankContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _connection = context.Database.GetDbConnection();
        }

        public IAsyncEnumerable<T> Get()
        {
            return _context.Set<T>().AsAsyncEnumerable();
        }

        public async Task<T?> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Add(T item)
        {
            return _context.Set<T>().Add(item).Entity;
        }

        public void AddRange(IEnumerable<T> items)
        {
            _context.Set<T>().AddRange(items);
        }

        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await _context.Set<T>().AddRangeAsync(items);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }
    }
}
