using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRHomeWebApi.Core.RepositoryPattern;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using BRHomeWebApi.Models;

namespace BRHomeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    { 
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        { 
            this._cityRepository = cityRepository;
        }

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            var cities = await _cityRepository.GetCitiesAsync();
            return Ok(cities);
        }

        //api/city/add/{cityName}
        [HttpPost("add/{cityName}")]
        public async Task<ActionResult> AddCity(string cityName)
        {
            City city = new City()
            {
                Name = cityName
            };
             _cityRepository.AddCity(city);
            await _cityRepository.SaveAsync();
            
            return StatusCode(201);
        }

        //api/city/
        [HttpPost()]
        public async Task<ActionResult> Post(City city)
        {
                _cityRepository.AddCity(city);
            await _cityRepository.SaveAsync();
            
              return StatusCode(201);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _cityRepository.DeleteCity(id);
            await _cityRepository.SaveAsync();
            
            return Ok(id);
        }
    }
}