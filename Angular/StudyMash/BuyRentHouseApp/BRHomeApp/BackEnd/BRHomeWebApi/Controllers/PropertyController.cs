using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public PropertyController(IUnitOfWork uow)
         {
            this._uow = uow;
        }

        [HttpGet("type/{sellRent}")]
        [AllowAnonymous]
        public async Task<ActionResult> GetProperties(int sellRent)
        {
            var properties = await _uow.propertyRepository.GetProperties(sellRent);
            return Ok(properties);
        }
    }
}