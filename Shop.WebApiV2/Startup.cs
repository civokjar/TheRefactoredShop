using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shop.Caching;
using Shop.Core.Caching;
using Shop.Core.Handlers.Request;
using Shop.Core.Providers;
using Shop.Core.Repositories;
using Shop.Core.Repository.Repositories;
using Shop.Infrastructure.ApiClients.Supplier1;
using Shop.Infrastructure.ApiClients.Supplier2;
using Shop.Infrastructure.Providers;


namespace Shop.WebApiV2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shop.WebApiV2", Version = "v1" });
            });
            services.AddMediatR(typeof(GetArticleQueryResult).Assembly);
            services.AddSingleton<ICacheService<GetArticleQueryResult>, CacheService<GetArticleQueryResult>>();
            services.AddScoped<IArticleWarehouseRepository, ArticleWarehouseRepository>();
            var suppliersUrl = Configuration.GetSection("Suppliers");
            services.AddScoped<ISupplier1ApiClient>(implementation => new Supplier1ApiClient(Configuration.GetValue<string>("Suppliers:Supplier1Url")));
            services.AddScoped<ISupplier2ApiClient>(implementation => new Supplier2ApiClient(Configuration.GetValue<string>("Suppliers:Supplier2Url")));
            services.AddScoped<IArticleProvider, ArticleProvider>();


            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(GetArticleQueryResult));
            services.AddAutoMapper(typeof(Supplier2ApiClient));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shop.WebApiV2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
