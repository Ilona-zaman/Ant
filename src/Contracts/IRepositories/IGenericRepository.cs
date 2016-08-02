using System.Collections.Generic;

namespace Contracts.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        void Remove(T item);
        object Update(T item);
        void Save();
    }
}
