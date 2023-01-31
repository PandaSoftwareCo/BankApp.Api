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
using Polly.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using Polly.Registry;
using BankApp.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

namespace BankApp.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));
            builder.Services.AddSingleton<IAppSettings>(sp => sp.GetRequiredService<IOptions<AppSettings>>().Value);

            //IPolicyRegistry<string> registry = builder.Services.AddPolicyRegistry();
            //IAsyncPolicy<HttpResponseMessage> httpRetryPolicy =
            //    Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            //        .RetryAsync(3);
            //registry.Add("SimpleHttpRetryPolicy", httpRetryPolicy);

            //IAsyncPolicy<HttpResponseMessage> httpWaitAndpRetryPolicy =
            //    Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            //        .OrTransientHttpStatusCode()
            //        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            //registry.Add("SimpleWaitAndRetryPolicy", httpWaitAndpRetryPolicy);

            //IAsyncPolicy<HttpResponseMessage> httpCircuitBreakerPolicy = 
            //    Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            //        .OrTransientHttpStatusCode()
            //        .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
            //registry.Add("CircuitBreakerPolicy", httpCircuitBreakerPolicy);

            //IAsyncPolicy<HttpResponseMessage> noOpPolicy = Policy.NoOpAsync()
            //    .AsAsyncPolicy<HttpResponseMessage>();
            //registry.Add("NoOpPolicy", noOpPolicy);

            //builder.Services.AddHttpClient().AddHttpLogging(options =>
            //{
            //    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            //}).AddPolicyRegistry(registry);//.AddPolicyHandlerFromRegistry(PolicySelector);

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddScoped<IValidator<Account>, AccountValidator>();
            builder.Services.AddScoped<IValidator<Balance>, BalanceValidator>();
            builder.Services.AddScoped<IValidator<BankTransaction>, BankTransactionValidator>();
            builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();

            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<IBalanceRepository, BalanceRepository>();
            builder.Services.AddScoped<IBankTransactionRepository, BankTransactionRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IMileageRepository, MileageRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]))
                };
            });
            //builder.Services.AddAuthentication("Basic")
            //    .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("Basic", null);

            //IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            //builder.Services.AddSingleton(mapper);
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.Configure<JsonOptions>(options =>
            {
                //Microsoft.AspNetCore.Mvc
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });

            /*
            var httpRetryPolicy1 = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(50, retryAttempt => TimeSpan.FromSeconds(retryAttempt * 5));
            var httpRetryPolicy2 = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(50, TimeSpan.FromSeconds(30));
            //var authorisationEnsuringPolicy = Policy
            //    .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.Unauthorized)
            //    .RetryAsync(
            //       retryCount: 3, // Consider how many retries. If auth lapses and you have valid credentials, one should be enough; too many tries can cause some auth systems to block or throttle the caller. 
            //       onRetryAsync: async (outcome, retryNumber, context) => FooRefreshAuthorizationAsync(context),
            //      );
            builder.Services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(httpRetryPolicy1);
            */
            builder.Services.AddHttpContextAccessor();
        }

        //static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        //{
        //    return HttpPolicyExtensions
        //        .HandleTransientHttpError()
        //        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        //        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        //}

        //private static IAsyncPolicy<HttpResponseMessage> PolicySelector(IReadOnlyPolicyRegistry<string> policyRegistry, HttpRequestMessage httpRequestMessage)
        //{
        //    if (httpRequestMessage.Method == HttpMethod.Get)
        //    {
        //        return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("SimpleHttpRetryPolicy");
        //    }
        //    else if (httpRequestMessage.Method == HttpMethod.Post)
        //    {
        //        return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("NoOpPolicy");
        //    }
        //    else
        //    {
        //        return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("SimpleWaitAndRetryPolicy");
        //    }
        //}
    }
}
