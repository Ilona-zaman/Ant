using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        [Scenario]
        public async Task CityUpdating(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(new DbContextOptions<CityDBContext>()));

            "And given City repository".x(() => repository = new CityRepository(context));

            "And given city".x(() => city = repository.GetAll().Result.FirstOrDefault());

            "And change city".x(() => city = new City()
            {
                Id = city.Id,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                Name = "Grodno"
            }); 

            "When I update city".x(() => repository.Update(city));

            "Then the city should have new Name".x(() => Assert.Equal("Brest", repository.Get(city.Id).Result.Name));
        }

        [Scenario]
        public async Task CityDeleting(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(new DbContextOptions<CityDBContext>()));

            "And given City repository".x(() => repository = new CityRepository(context));

            "And given city".x(() => city = repository.GetAll().Result.FirstOrDefault());

            "When I delete city".x(() => repository.Remove(city));

            "Then the city shouldn't exist in database".x(() => Assert.Equal(0, context.Cities.Count()));
        }

        [Scenario]
        public async Task CityGetAll(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(new DbContextOptions<CityDBContext>()));

            "And given City repository".x(() => repository = new CityRepository(context));

            "And given city".x(() => city = new City
            {
                Latitude = 100,
                Longitude = 200,
                Name = "Grodno"
            });

            "And add city".x(() => repository.Add(city));

            "And given one more city".x(() => city = new City
            {
                Latitude = 150,
                Longitude = 200,
                Name = "Brest"
            });

            "And add one more city".x(() => repository.Add(city));

            "When I get all cities".x(() => repository.GetAll());

            "Then the list shouldn't be null".x(() => Assert.NotNull(context.Cities.Count()));
        }

        public async Task CityGetById(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(new DbContextOptions<CityDBContext>()));

            "And given City repository".x(() => repository = new CityRepository(context));

            "And given city".x(() => city = new City
            {
                Latitude = 100,
                Longitude = 200,
                Name = "Grodno"
            });

            "And add city".x(() => repository.Add(city));

            "And given one more city".x(() => city = new City
            {
                Latitude = 150,
                Longitude = 200,
                Name = "Brest"
            });

            "And add one more city".x(() => repository.Add(city));

            City gettingCity = null;

            "When I get city by Id".x(() => gettingCity = repository.Get(city.Id).Result);

            "Then the city should exist in database".x(() => Assert.Equal(city, gettingCity));
        }
    }
}