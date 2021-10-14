using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Models;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BRHomeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : BaseController
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper mapper;

        public PropertyController(IUnitOfWork uow, IMapper mapper)
         {
            this._uow = uow;
            this.mapper = mapper;
        }

        [HttpGet("list/{sellRent}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetProperties(int sellRent)
        {
            var properties = await _uow.propertyRepository.GetProperties(sellRent);
            var propertiesDto = mapper.Map<IEnumerable<PropertyListDto>>(properties);
            return Ok(propertiesDto);
        }

        [HttpGet("details/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetPropertyDetails(int id)
        {
            var property = await _uow.propertyRepository.GetPropertyDetails(id);
            var propertyDetailsDto = mapper.Map<PropertyDetailsDto>(property);
            return Ok(propertyDetailsDto);
        }

        [HttpPost("add/")]
        [AllowAnonymous]
        public async Task<ActionResult> AddPropertyDetails(PropertyDto propertyDto)
        {
            Property property = mapper.Map<Property>(propertyDto);
            property.PostedBy = 6;
            property.PostedOn = DateTime.Now;
            _uow.propertyRepository.AddProperty(property);
            await _uow.SaveAsync();

            return StatusCode(201);
        }
    }
}