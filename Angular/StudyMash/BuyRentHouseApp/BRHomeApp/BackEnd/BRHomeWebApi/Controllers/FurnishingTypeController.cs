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
    public class FurnishingTypeController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public FurnishingTypeController(IUnitOfWork uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        [HttpGet("list")]
        public async Task<ActionResult> GetFurnishingTypes(){
            var ftypes = await uow.furnishTypeRepository.GetFurnishingTypeAsync();
            var keyValueTypeDto = mapper.Map<IEnumerable<KeyValuePairDto>>(ftypes);

            return Ok(keyValueTypeDto);

        }
    }
}