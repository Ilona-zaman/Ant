using Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;

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
            return  await _context.Cities.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
