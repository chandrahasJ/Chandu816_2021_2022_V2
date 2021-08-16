using AutoMapper;
using BRHomeWebApi.Dtos;
using BRHomeWebApi.Models;

namespace BRHomeWebApi.Helpers.AutoMapperHelpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            createMaps();
        }

        private void createMaps()
        {   
            CreateMap<City,CityDto>().ReverseMap();
        }
    }
}