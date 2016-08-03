using System.Threading.Tasks;
using Model;

namespace Contracts.IRepositories
{
    public interface ICityRepository: IGenericRepository<City>
    {
        Task<City> Get(int id);
    }
}
