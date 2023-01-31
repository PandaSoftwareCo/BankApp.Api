using BankApp.Domain.Entities;
using BankApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Configurations
{
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(i => i.AccountId);
            builder.Property(i => i.AccountId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.AccountName).IsRequired().HasMaxLength(100);

            builder.HasIndex(i => i.AccountName).IsUnique();

            builder.HasData(new[]
            {
                new Account { AccountId = 1, AccountName = "Personal", AccountType = AccountType.Debit },
                new Account { AccountId = 2, AccountName = "Visa", AccountType = AccountType.Credit },
                new Account { AccountId = 3, AccountName = "MasterCard", AccountType = AccountType.Credit },
                new Account { AccountId = 4, AccountName = "Corporate", AccountType = AccountType.Debit },
                new Account { AccountId = 5, AccountName = "Corporate MasterCard", AccountType = AccountType.Credit }
            });
        }
    }
}
