using BankApp.Application.Interfaces;
using BankApp.Data.Configurations;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Data.Context
{
    public class BankContext : DbContext, IUnitOfWork
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Mileage> Mileage { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }

        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Account>(new AccountConfiguration());
            modelBuilder.ApplyConfiguration<Balance>(new BalanceConfiguration());
            modelBuilder.ApplyConfiguration<BankTransaction>(new BankTransactionConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Mileage>(new MileageConfiguration());
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Vehicle>(new VehicleConfiguration());
        }
    }
}
