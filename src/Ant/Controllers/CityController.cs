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
        public async Task<IActionResult> Get()
        {
            return Ok(await _cityService.GetAllCities());
        }

        // GET api/city/3
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _cityService.GetCityById(id));
        }

        // POST api/city
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]City value)
        {
            await _cityService.AddCity(value);
            return Created($"/api/cities", value);
        }

        // PUT api/city
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]City value)
        {
            return Ok(await _cityService.UpdateCity(value));
        }

        // DELETE api/city/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(City city)
        {
            await _cityService.RemoveCity(city);
            return Ok();
        }
    }
}
