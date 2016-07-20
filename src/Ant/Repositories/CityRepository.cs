using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Ant.IRepositories;
using Ant.Models;

namespace Ant.Repositories
{
    public class CityRepository : ICityRepository
    {
        private AntDBContext _context;

        public CityRepository(AntDBContext context)
        {
            _context = context;
        }

        public void Add(City item)
        {
            item.Id = _context.Cities.ToList().Max(p => p.Id) + 1;
            _context.Cities.Add(item);
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Cities;
        }

        public City Get(int id)
        {
            
            return _context.Cities.ToList().FirstOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            var p = _context.Cities.ToList().FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                _context.Cities.Remove(p);
            }
        }

        public City Update(City item)
        {
            var p = _context.Cities.ToList().FirstOrDefault(x => x.Id == item.Id);
            if (p != null)
            {
                p.Name = item.Name;
                p.Latitude = item.Latitude;
                p.Longitude = item.Longitude;
            }
            return p;
        }
    }
}
