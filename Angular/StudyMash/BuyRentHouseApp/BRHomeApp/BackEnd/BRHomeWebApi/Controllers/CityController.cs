using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly BRHomeDbContext _bRHomeDbContext;

        public CityController(BRHomeDbContext bRHomeDbContext)
        {
            this._bRHomeDbContext = bRHomeDbContext;
        }

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            var cities = await _bRHomeDbContext.Cities.ToListAsync();
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
            await _bRHomeDbContext.Cities.AddAsync(city);
            await _bRHomeDbContext.SaveChangesAsync();
            
            return Ok(city);
        }

        //api/city/
        [HttpPost()]
        public async Task<ActionResult> Post(City city)
        {
            await _bRHomeDbContext.Cities.AddAsync(city);
            await _bRHomeDbContext.SaveChangesAsync();
            
            return Ok(city);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var city = await _bRHomeDbContext.Cities.FindAsync(id);
            _bRHomeDbContext.Cities.Remove(city);
            await _bRHomeDbContext.SaveChangesAsync();
            
            return Ok(city);
        }
    }
}