using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.IRepositories;
using Contracts.IServices;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Ant.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private ICityService _cityService;

        public CityController(ICityService cityRepository)
        {
            _cityService = cityRepository;
        }
        // GET: api/city
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cityService.GetAllCities());
        }

        // GET api/city/3
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_cityService.GetCityById(id));
        }

        // POST api/city
        [HttpPost]
        public IActionResult Post([FromBody]City value)
        {
            _cityService.AddCity(value);
            return Created($"/api/cities", value);
        }

        // PUT api/city
        [HttpPut]
        public IActionResult Put([FromBody]City value)
        {
            return Ok(_cityService.UpdateCity(value));
        }

        // DELETE api/city/3
        [HttpDelete("{id}")]
        public IActionResult Delete(City city)
        {
            _cityService.RemoveCity(city);
            return Ok();
        }
    }
}
