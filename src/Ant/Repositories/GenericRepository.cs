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

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
            Save();
        }

        public object Update(T item)
        {
            var i = _context.Set<T>().Update(item);
            _context.SaveChanges();
            return i;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
