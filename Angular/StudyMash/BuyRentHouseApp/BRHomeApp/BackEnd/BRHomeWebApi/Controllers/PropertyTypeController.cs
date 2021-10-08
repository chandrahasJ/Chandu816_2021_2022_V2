using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BRHomeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyTypeController : ControllerBase
    {
        
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public PropertyTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetPropertyTypes(){
            var ptypes = await uow.propertyTypeRepository.GetPropertyTypeAsync();
            var keyValueTypeDto = mapper.Map<IEnumerable<KeyValuePairDto>>(ptypes);

            return Ok(keyValueTypeDto);

        }
    }
}