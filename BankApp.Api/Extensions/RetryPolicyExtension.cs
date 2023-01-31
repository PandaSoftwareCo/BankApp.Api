using Polly.Registry;
using Polly;
using Polly.Extensions.Http;

namespace BankApp.Api.Extensions
{
    public static class RetryPolicyExtension
    {
        public static void AddRetryPolicy(this IServiceCollection services)
        {
            IPolicyRegistry<string> registry = services.AddPolicyRegistry();
            IAsyncPolicy<HttpResponseMessage> httpRetryPolicy =
                Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .RetryAsync(3);
            registry.Add("SimpleHttpRetryPolicy", httpRetryPolicy);

            IAsyncPolicy<HttpResponseMessage> httpWaitAndpRetryPolicy =
                Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .OrTransientHttpStatusCode()
                    .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));
            registry.Add("SimpleWaitAndRetryPolicy", httpWaitAndpRetryPolicy);

            IAsyncPolicy<HttpResponseMessage> httpCircuitBreakerPolicy =
                Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .OrTransientHttpStatusCode()
                    .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30));
            registry.Add("CircuitBreakerPolicy", httpCircuitBreakerPolicy);

            IAsyncPolicy<HttpResponseMessage> noOpPolicy = Policy.NoOpAsync()
                .AsAsyncPolicy<HttpResponseMessage>();
            registry.Add("NoOpPolicy", noOpPolicy);

            services.AddHttpClient().AddHttpLogging(options =>
            {
                options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
            }).AddPolicyRegistry(registry);//.AddPolicyHandlerFromRegistry(PolicySelector);


            var httpRetryPolicy1 = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(50, retryAttempt => TimeSpan.FromSeconds(retryAttempt * 5));
            var httpRetryPolicy2 = Policy.HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .CircuitBreakerAsync(50, TimeSpan.FromSeconds(30));
            //var authorisationEnsuringPolicy = Policy
            //    .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.Unauthorized)
            //    .RetryAsync(
            //       retryCount: 3, // Consider how many retries. If auth lapses and you have valid credentials, one should be enough; too many tries can cause some auth systems to block or throttle the caller. 
            //       onRetryAsync: async (outcome, retryNumber, context) => FooRefreshAuthorizationAsync(context),
            //      /* more configuration */);
            services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(httpRetryPolicy1);

        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        private static IAsyncPolicy<HttpResponseMessage> PolicySelector(IReadOnlyPolicyRegistry<string> policyRegistry, HttpRequestMessage httpRequestMessage)
        {
            if (httpRequestMessage.Method == HttpMethod.Get)
            {
                return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("SimpleHttpRetryPolicy");
            }
            else if (httpRequestMessage.Method == HttpMethod.Post)
            {
                return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("NoOpPolicy");
            }
            else
            {
                return policyRegistry.Get<IAsyncPolicy<HttpResponseMessage>>("SimpleWaitAndRetryPolicy");
            }
        }
    }
}
