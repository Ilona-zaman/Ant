using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task Remove(T item);
        Task<object> Update(T item);
        Task Save();
    }
}
