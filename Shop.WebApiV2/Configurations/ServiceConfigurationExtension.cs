using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shop.Caching;
using Shop.Core.Caching;
using Shop.Core.Handlers.Request;
using Shop.Core.Providers;
using Shop.Core.Repositories;
using Shop.Core.Repository.Repositories;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier2;
using Shop.Infrastructure.Providers;
using Shop.Infrastructure.Repositories;

namespace Shop.WebApiV2.Configurations
{
    public static class ServiceConfigurationExtension
    {
        public static void ConfigureInfrastructureModule(this IServiceCollection services, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var supplier1Logger = loggerFactory.CreateLogger<Supplier1ApiClient>();
            var supplier2Logger = loggerFactory.CreateLogger<Supplier2ApiClient>();

            services.AddScoped<ISupplier1ApiClient>(client => new Supplier1ApiClient(configuration.GetValue<string>("Suppliers:Supplier1Url"), supplier1Logger));
            services.AddScoped<ISupplier2ApiClient>(client => new Supplier2ApiClient(configuration.GetValue<string>("Suppliers:Supplier2Url"), supplier2Logger));
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
    }
}
