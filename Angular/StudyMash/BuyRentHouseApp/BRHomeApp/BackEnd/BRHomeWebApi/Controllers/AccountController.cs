using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BRHomeWebApi.Controllers
{

    public class AccountController : BaseController
    {
         private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AccountController(IUnitOfWork uow, IMapper mapper)
        {  
            this._uow = uow;
            this._mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginReqDto loginReqDto)
        { 
           var user = await _uow.userRepository.Authenticate(loginReqDto.UserName,loginReqDto.Password);
           if(user ==  null)
           {
               return Unauthorized();
           }
           var loginResDto = new LoginResDto()
           {
               UserName = user.UserName,
               Token = "To Be Generated."
           };
            return Ok(loginResDto);
        }
    }
}