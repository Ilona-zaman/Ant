using System;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using Xbehave;
using Xunit;
using Microsoft.Extensions.DependencyInjection;

namespace ClassicTests
{
    public class CitiesRepositoryFeature
    {
        private static DbContextOptions<CityDBContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<CityDBContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        private DbContextOptionsBuilder<CityDBContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CityDBContext>();
            return optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AntDB;Trusted_Connection=True;");
        }

        [Scenario]
        public async Task CityAddition(City city, CityDBContext context, CityRepository repository)
        {
            "Given city".x(() => city = new City
            {
                Latitude = 100,
                Longitude = 200,
                Name = "Grodno"
            });
           
            "And given CityDBContext".x(() => context = new CityDBContext(CreateNewContextOptions())).Teardown(() => context.Dispose());

            "And given City repository".x(() => repository = new CityRepository(context));

            "When I save city".x(() => repository.Add(city));

            "Then the city should exist in database".x(() => Assert.Equal(1, context.Cities.Count()));
        }

        [Scenario]
        public async Task CityUpdating(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(CreateNewContextOptions()))
                .Teardown(() => context.Dispose());

            "And given City repository".x(() => repository = new CityRepository(context));

            "And given city".x(() => city = new City
            {
                Latitude = 100,
                Longitude = 200,
                Name = "Grodno"
            });

            "And after saving city".x(() => repository.Add(city));

            "And change city".x(() =>
                city.Name = "New Grodno");

            "When I update city".x(() => repository.Update(city));

            "Then the city should have new Name".x(() => Assert.Equal("New Grodno", repository.Get(city.Id).Result.Name));
        }

        [Scenario]
        public async Task CityDeleting(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(CreateNewContextOptions())).Teardown(() => context.Dispose());

            "And given City repository".x(() => repository = new CityRepository(context));

            "And given city".x(() => city = new City
            {
                Latitude = 100,
                Longitude = 200,
                Name = "Grodno"
            });

            "And after saving city".x(() => repository.Add(city));

            "When I delete city".x(() => repository.Remove(city));

            "Then the city shouldn't exist in database".x(() => Assert.Equal(0, context.Cities.Count()));
        }

        [Scenario]
        public async Task CityGetAll(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(CreateNewContextOptions())).Teardown(() => context.Dispose());

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
        
        [Scenario]
        public async Task CityGetById(City city, CityDBContext context, CityRepository repository)
        {
            "Given CityDBContext".x(() => context = new CityDBContext(CreateNewContextOptions())).Teardown(() => context.Dispose());

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