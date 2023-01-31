using BankApp.Api.Extensions;
using BankApp.Api.Middleware;
using BankApp.Data.HealthChecks;
using BankApp.Data.Seed;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;

namespace BankApp.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.AddLogging();
            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddRetryPolicy();
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

            app.UseSerilogRequestLogging();
            //app.UseW3CLogging();

            app.UseExceptionMiddleware();
            app.UsePerformanceMiddleware();
            app.UseLoggingMiddleware();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseSwaggerUI(options =>
                {
                    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                    foreach(var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.MapHealthChecks("/health");

            await SeedData.EnsurePopulated(app);

            app.Run();
        }
    }
}