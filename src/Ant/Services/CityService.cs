using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ant.Repositories;
using Contracts.IRepositories;
using Contracts.IServices;
using Model;

namespace Ant.Services
{
    public class CityService: ICityService
    {
        private ICityRepository _cityRepository;
        
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public async Task AddCity(City item)
        {
            await _cityRepository.Add(item);
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _cityRepository.GetAll();
        }

        public async Task RemoveCity(City item)
        {
            await _cityRepository.Remove(item);
        }

        public async Task<object> UpdateCity(City item)
        {
            return await _cityRepository.Update(item);
        }

        public async Task<City> GetCityById(int id)
        {
            return await _cityRepository.Get(id);
        }
    }
}
