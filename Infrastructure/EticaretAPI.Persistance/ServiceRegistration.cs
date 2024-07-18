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
                options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Singleton);

            services.AddSingleton<ICategoryReadRepository, CategoryReadRepository>();
            services.AddSingleton<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
            services.AddSingleton<IOrderProductReadRepository, OrderProductReadRepository>();
            services.AddSingleton<IOrderProductWriteRepository, OrderProductWriteRepository>();
            services.AddSingleton<IShopAssistantReadRepository, ShopAssistantReadRepository>();
            services.AddSingleton<IShopAssistantWriteRepository, ShopAssistantWriteRepository>();
        }
    }
}
