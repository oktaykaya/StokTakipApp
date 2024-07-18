using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EticaretAPIDbContext _context;

        public ReadRepository(EticaretAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;
        public Task<T> GetByIdAsync(string id)
        => Table.FirstOrDefaultAsync(p => p.Id == int.Parse(id));

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);
    }
}
