using BankApp.Api.Extensions;
using BankApp.Api.Middleware;
using BankApp.Data.HealthChecks;
using BankApp.Data.Seed;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BankApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddLogging();
            builder.AddDatabase();
            builder.ConfigureServices();

            builder.Services.AddCors();

            builder.Services.AddControllers();

            builder.AddVersioning();

            builder.AddSwagger();

            // Registers required services for health checks
            builder.Services.AddHealthChecks()
                // Add a health check for a SQL Server database
                .AddCheck(
                    "BankDB-check",
                    new SqlConnectionHealthCheck(builder.Configuration["ConnectionStrings:DefaultConnection"]),
                    HealthStatus.Unhealthy,
                    new string[] { "bankdb" });

            var app = builder.Build();

            app.UseExceptionMiddleware();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.MapHealthChecks("/health");

            SeedData.EnsurePopulated(app).Wait();

            app.Run();
        }
    }
}