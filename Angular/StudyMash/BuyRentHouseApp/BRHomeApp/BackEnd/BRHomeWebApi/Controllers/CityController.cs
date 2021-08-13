using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using BRHomeWebApi.DataC;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Models;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using BRHomeWebApi.Models;

namespace BRHomeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {  
        private readonly IUnitOfWork _uow;

        public CityController(  IUnitOfWork uow)
        {  
            this._uow = uow;
        }

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            var cities = await _uow.cityRepository.GetCitiesAsync();
            var cityDtoData = cities.Select(x => new CityDto(){
                                                Id = x.Id,
                                                Name = x.Name
                                            });
            return Ok(cityDtoData);
        }

        //api/city/add/{cityName}
        [HttpPost("add/{cityName}")]
        public async Task<ActionResult> AddCity(string cityName)
        {
            City city = new City()
            {
                Name = cityName,
                LastUpdatedBy = "Cj",
                LastUpdateOn = DateTime.Now
            };
             _uow.cityRepository.AddCity(city);
            await _uow.SaveAsync();
            
            return StatusCode(201);
        }

        //api/city/
        [HttpPost()]
        public async Task<ActionResult> Post(CityDto cityDto)
        {
            City city = new City()
            {
                Name = cityDto.Name,
                LastUpdatedBy = "Cj",
                LastUpdateOn = DateTime.Now
            };
            
                _uow.cityRepository.AddCity(city);
            await _uow.SaveAsync();
            
              return StatusCode(201);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _uow.cityRepository.DeleteCity(id);
            await _uow.SaveAsync();
            
            return Ok(id);
        }
    }
}