using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ant.IRepositories;
using Ant.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Ant.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        // GET: api/city
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cityRepository.GetAll());
        }

        // GET api/city/3
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_cityRepository.Get(id));
        }

        // POST api/city
        [HttpPost]
        public IActionResult Post([FromBody]City value)
        {
            _cityRepository.Add(value);
            return Created($"/api/cities/{value.Id}", value);
        }

        // PUT api/city
        [HttpPut]
        public IActionResult Put([FromBody]City value)
        {
            return Ok(_cityRepository.Update(value));
        }

        // DELETE api/city/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cityRepository.Remove(id);
            return Ok();
        }
    }
}
