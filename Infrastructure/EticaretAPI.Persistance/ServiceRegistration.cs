using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace EticaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<EticaretAPIDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
