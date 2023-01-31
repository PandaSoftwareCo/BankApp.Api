using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Data.Configurations
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles");

            builder.HasKey(i => i.VehicleId);
            builder.Property(i => i.VehicleId).IsRequired().UseIdentityColumn();

            builder.HasData(new[]
            {
                new Vehicle 
                { 
                    VehicleId = 1, 
                    Make = "Honda", 
                    Model = "Civic",
                    Year = 2018
                },
                new Vehicle 
                { 
                    VehicleId = 2,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2022
                }
            });
        }
    }
}
