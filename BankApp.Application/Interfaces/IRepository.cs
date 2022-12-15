namespace BankApp.Application.Interfaces
{
    public interface IRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
        IAsyncEnumerable<T> Get();
        Task<T?> FindAsync(int id);
        T Add(T item);
        void AddRange(IEnumerable<T> items);
        Task AddRangeAsync(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
    }
}
