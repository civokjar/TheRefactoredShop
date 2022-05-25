using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Shop.Caching;
using Shop.Core.Caching;
using Shop.Core.Handlers.Request;
using Shop.Core.Providers;
using Shop.Core.Repositories;
using Shop.Core.Repository.Repositories;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier2;
using Shop.Infrastructure.Interfaces;
using Shop.Infrastructure.Providers;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Services;
using System;
using System.Net.Http;

namespace Shop.WebApiV2.Configurations
{
    public static class ServiceConfigurationExtension
    {
        public static void ConfigureInfrastructureModule(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var supplier1Logger = loggerFactory.CreateLogger<Supplier1ApiClient>();
            var supplier2Logger = loggerFactory.CreateLogger<Supplier2ApiClient>();

            services.AddScoped<IArticleRetriever, ArticleWarehouseService>();
       
            services.AddHttpClient<IArticleRetriever, Supplier1ApiClient>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("Suppliers:Supplier1Url"));
            }).AddPolicyHandler(GetRetryPolicy(configuration));

            services.AddHttpClient<IArticleRetriever, Supplier2ApiClient>(client =>
            {
                client.BaseAddress = new Uri(configuration.GetValue<string>("Suppliers:Supplier2Url"));
            }).AddPolicyHandler(GetRetryPolicy(configuration));

            services.AddScoped<IArticleWarehouseRepository, ArticleWarehouseRepository>();
            
            services.AddScoped<IArticleProvider, ArticleProvider>();
            services.AddAutoMapper(typeof(Supplier2ApiClient));


        }
        public static void ConfigureCoreModule(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            services.AddMediatR(typeof(GetArticleQueryResult).Assembly);
            services.AddSingleton<ICacheService<GetArticleQueryResult>, CacheService<GetArticleQueryResult>>();

            services.AddScoped<IArticlePurchaseRepository, ArticlePurchaseRepository>();

            services.AddAutoMapper(typeof(GetArticleQueryResult));


        }
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(IConfiguration configuration)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                .WaitAndRetryAsync(configuration.GetValue<int>("Suppliers:MaxRetryCount"), retryAttempt => TimeSpan.FromSeconds(Math.Pow(configuration.GetValue<int>("Suppliers:RetryDelayInSeconds"), retryAttempt)));
        }
    }
}
