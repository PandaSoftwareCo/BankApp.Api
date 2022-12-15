using BankApp.Application.Interfaces;
using BankApp.Data.Configurations;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Context
{
    public class BankContext : DbContext, IUnitOfWork
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Category> Categories { get; set; }

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
        }
    }
}
