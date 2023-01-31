using BankApp.Application.Interfaces;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(i => i.UserId);
            builder.Property(i => i.UserId).IsRequired().UseIdentityColumn();

            builder.Property(i => i.Username).IsRequired().HasMaxLength(100);

            builder.HasIndex(i => i.Username).IsUnique();

//            builder.HasData(new[]
//{
//                new User
//                {
//                    UserId = 1,
//                    Username = "007",
//                    PasswordHash = "Civic",
//                    Year = 2018
//                },
//                new User
//                {
//                    UserId = 2,
//                    Username = "Honda",
//                    PasswordHash = "Civic",
//                    Year = 2022
//                }
//            });
        }
    }
}
