using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRepository.Repositories
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext
    {
        private C _context;

        protected GenericRepository(C context)
        {
            _context = context;
        }

        public async Task Add(T item)
        {
            _context.Set<T>().Add(item);
            await Save();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = _context.Set<T>();
            return await list.ToListAsync();
        }

        public async Task Remove(T item)
        {
            _context.Set<T>().Remove(item);
            await Save();
        }

        public async Task<object> Update(T item)
        {
            var i = _context.Set<T>().Update(item);
            await Save();
            return i;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
