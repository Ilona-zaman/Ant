using Model;

namespace Contracts.IRepositories
{
    public interface ICityRepository: IGenericRepository<City>
    {
        City Get(int id);
    }
}
