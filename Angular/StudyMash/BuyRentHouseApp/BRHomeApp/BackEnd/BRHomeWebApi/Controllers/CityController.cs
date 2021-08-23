using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Models;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper;

        public CityController(  IUnitOfWork uow, IMapper mapper)
        {  
            this._uow = uow;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult> Get()
        {
            throw new Exception();
            var cities = await _uow.cityRepository.GetCitiesAsync();
            var cityDtoData = _mapper.Map<IEnumerable<CityDto>>(cities);
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
            City city = _mapper.Map<City>(cityDto);
            city.LastUpdatedBy = "Cp";
            city.LastUpdateOn = DateTime.Now;

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

         //api/city/update/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateCity(int id, CityDto cityDto)
        {
            if(id == cityDto.Id)
                return BadRequest("Update not allowed.");

            var cityFromDB = await _uow.cityRepository.FindCity(id);

            if(cityFromDB == null)
                return BadRequest("Update not allowed.");

            cityFromDB.LastUpdatedBy = "Cp";
            cityFromDB.LastUpdateOn = DateTime.Now;
           
           _mapper.Map(cityDto,cityFromDB);

           await _uow.SaveAsync();
            
              return StatusCode(200);
        }

        //api/city/update/{id}
        ///<Summary>
        /// Since HttpPatch gives more power to the API user 
        /// It can be misused. it is security vulerblity. 
        /// So we need use PUT by adding New DTOs
        ///</Summary>
        [HttpPatch("update/{id}")]
        public async Task<ActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        {
            var cityFromDB = await _uow.cityRepository.FindCity(id);

            if(cityFromDB == null)
                return BadRequest("Update not allowed.");
                
            cityFromDB.LastUpdatedBy = "Cp";
            cityFromDB.LastUpdateOn = DateTime.Now;
           
           cityToPatch.ApplyTo(cityFromDB, ModelState);

           await _uow.SaveAsync();
            
              return StatusCode(200);
        }

         //api/city/update/{id}
        [HttpPut("updatecityname/{id}")]
        public async Task<ActionResult> UpdateCityName(int id, CityUpdateDto cityUpdateDto)
        {
            var cityFromDB = await _uow.cityRepository.FindCity(id);

            if(cityFromDB == null)
                return BadRequest("Update not allowed.");

            cityFromDB.LastUpdatedBy = "Cp";
            cityFromDB.LastUpdateOn = DateTime.Now;
           
           _mapper.Map(cityUpdateDto,cityFromDB);

           await _uow.SaveAsync();
            
              return StatusCode(200);
        }
    }
}