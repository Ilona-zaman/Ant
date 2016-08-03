using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Contracts.IRepositories;

namespace Ant.Repositories
{
    public class CityRepository : GenericRepository<CityDBContext, City>, ICityRepository
    {
        private CityDBContext _context;

        public CityRepository(CityDBContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<City> Get(int id)
        {
            return  _context.Cities.FirstOrDefault(p => p.Id == id);
        }
    }
}
