using AutoMapper;
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
    }
}