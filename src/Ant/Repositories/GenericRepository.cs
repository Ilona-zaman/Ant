using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ant.Repositories
{
    public abstract class GenericRepository<C, T> :
        IGenericRepository<T> where T : class where C : DbContext
    {
        private C _context;

        public GenericRepository(C context)
        {
            _context = context;
        }

        public async Task Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task Remove(T item)
        {
            _context.Set<T>().Remove(item);
            Save();
        }

        public async Task<object> Update(T item)
        {
            var i = _context.Set<T>().Update(item);
            _context.SaveChanges();
            return i;
        }

        public async Task Save()
        {
            _context.SaveChanges();
        }
    }
}
