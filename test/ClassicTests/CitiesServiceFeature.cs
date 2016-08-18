using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkRepository.Repositories;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model;
using Services.Services;
using Xbehave;
using Xunit;

namespace ClassicTests
{
    class CitiesServiceFeature
    {
        [Scenario]
        public async Task CityAddition(City city,  CityService repository)
        {
            List<City> listCities = new List<City>();
            Assert.Equal(0, listCities.Count);


        }
    }
}
