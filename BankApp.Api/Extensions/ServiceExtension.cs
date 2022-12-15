using BankApp.Api.Validation;
using BankApp.Application.Interfaces;
using BankApp.Data.Repositories;
using BankApp.Domain.Entities;
using BankApp.Services.Settings;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using Polly;

namespace BankApp.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
            builder.Services.AddSingleton<IAppSettings>(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);

            builder.Services.AddHttpClient().AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            });

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddScoped<IValidator<Account>, AccountValidator>();
            builder.Services.AddScoped<IValidator<Balance>, BalanceValidator>();
            builder.Services.AddScoped<IValidator<BankTransaction>, BankTransactionValidator>();
            builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();
            builder.Services.AddScoped<IBankTransactionRepository, BankTransactionRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.Configure<JsonOptions>(options =>
            {
                //Microsoft.AspNetCore.Mvc
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            });

            var httpRetryPolicy = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            var httpRetryPolicy2 = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
            builder.Services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(httpRetryPolicy);
        }
    }
}
