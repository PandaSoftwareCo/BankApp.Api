using BankApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BankApp.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<BankContext>(optionsAction: options =>
            {
                //options.UseInMemoryDatabase("BankApp");
                //options.UseSqlite("DataSource=:memory:", options =>
                //{
                //    options.MigrationsAssembly("BankApp.Data");
                //});
                //options.UseSqlite("Data Source=BankApp.sqlite3", options =>
                //{
                //    options.MigrationsAssembly("BankApp.Data");
                //});

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly("BankApp.Data");
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    sqlOptions.CommandTimeout((int)TimeSpan.FromSeconds(30).TotalSeconds);
                });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
                options.LogTo(message => Debug.Write(message));
            });
        }
    }
}
