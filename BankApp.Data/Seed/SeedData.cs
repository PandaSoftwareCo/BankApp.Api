using BankApp.Application.Interfaces;
using BankApp.Data.Context;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Data.Seed
{
    public static class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            IServiceScope scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BankContext>();
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }

            //if (!context.Accounts.Any())
            //{
            //    var accountString = await File.ReadAllTextAsync("accounts.json");
            //    var accounts = System.Text.Json.JsonSerializer.Deserialize<Account[]>(accountString);
            //}

            if (!context.Users.Any())
            {
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var user = new User
                {
                    Username = "007",
                    //FirstName = "James",
                    //LastName = "Bond",
                    Role = Domain.Enums.Role.User
                };
                userService.AddUser(user, "test");
            }
        }
    }
}
