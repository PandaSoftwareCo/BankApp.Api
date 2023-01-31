﻿using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    public class MileageConfiguration : IEntityTypeConfiguration<Mileage>
    {
        public void Configure(EntityTypeBuilder<Mileage> builder)
        {
            builder.ToTable("Mileage");

            builder.HasKey(i => i.MileageId);
            builder.Property(i => i.MileageId).IsRequired().UseIdentityColumn();
        }
    }
}
