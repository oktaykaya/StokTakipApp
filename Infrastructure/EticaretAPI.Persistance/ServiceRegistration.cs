using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EticaretAPI.Application.Repositories;
using EticaretAPI.Persistance.Repositories;

namespace EticaretAPI.Persistance

{
    
    public static class ServiceRegistration

    {
        
        public static void AddPersistenceServices(this IServiceCollection services)


        {

            services.AddDbContext<EticaretAPIDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderProductReadRepository, OrderProductReadRepository>();
            services.AddScoped<IOrderProductWriteRepository, OrderProductWriteRepository>();
            services.AddScoped<IShopAssistantReadRepository, ShopAssistantReadRepository>();
            services.AddScoped<IShopAssistantWriteRepository, ShopAssistantWriteRepository>();

        }
    }
}
