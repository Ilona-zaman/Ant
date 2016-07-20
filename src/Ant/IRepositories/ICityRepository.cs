using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ant.Models;

namespace Ant.IRepositories
{
    public interface ICityRepository
    {
        void Add(City item);
        IEnumerable<City> GetAll();
        City Get(int id);
        void Remove(int id);
        City Update(City item);
    }
}
