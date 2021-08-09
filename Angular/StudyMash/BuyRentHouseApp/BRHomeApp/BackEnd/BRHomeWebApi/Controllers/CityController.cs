using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BRHomeWebApi.DataC;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Get()
        {
            var cities = _bRHomeDbContext.Cities.ToList();
            return Ok(cities);
        }

    }
}