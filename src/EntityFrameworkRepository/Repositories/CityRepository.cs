using System.Linq;
using System.Threading.Tasks;
using Contracts.IRepositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace EntityFrameworkRepository.Repositories
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
            return await _context.Cities.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
