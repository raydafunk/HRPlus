using HRPlus.Application.Contracts.Presistence;
using HRPlus.Domain.Common;
using HRPlus.Presistance.DatabaaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRPlus.Presistance.Repositories
{
    public class GenericRespostiory<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected  readonly HRPlusDbContext _context;

        public GenericRespostiory(HRPlusDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(T entity)
        {
           _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
           return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id== id);
        }   

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
