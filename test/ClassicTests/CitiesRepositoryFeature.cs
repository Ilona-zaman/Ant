using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Xbehave;
using Xunit;

namespace Tests
{
    public class CitiesRepositoryFeature
    {
        [Scenario]
        public async Task CityAddition(City city, CityDBContext context, CityRepository repository)
        {
            "Given city".x(() => city = new City
            {
                Latitude = 100,
                Longitude = 200,
                Name = "Grodno"
            });

            "And given CityDBContext".x(() => context = new CityDBContext(new DbContextOptions<CityDBContext>()));

            "And given City repository".x(() => repository = new CityRepository(context));

            "When I save city".x(() => repository.Add(city));

            "Then the city should exist in database".x(() => Assert.Equal(1, context.Cities.Count()));
        }
    }
}