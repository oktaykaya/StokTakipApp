using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EticaretAPI.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EticaretAPIDbContext>
    {
        public EticaretAPIDbContext CreateDbContext(string[] args)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<EticaretAPIDbContext>();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new EticaretAPIDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
