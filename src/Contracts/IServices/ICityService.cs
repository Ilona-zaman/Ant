using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Contracts.IServices
{
    public interface ICityService
    {
        Task AddCity(City item);
        Task<IEnumerable<City>> GetAllCities();
        Task RemoveCity(City item);
        Task<object> UpdateCity(City item);
        Task<City> GetCityById(int id);
    }
}
