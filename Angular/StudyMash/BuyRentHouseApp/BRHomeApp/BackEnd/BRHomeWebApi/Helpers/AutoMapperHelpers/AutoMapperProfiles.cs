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
            CreateMap<City,CityUpdateDto>().ReverseMap();
            CreateMap<User,LoginReqDto>().ReverseMap();
            CreateMap<Property,PropertyListDto>()
                 .ForMember(destination => destination.City,
                                 option => option.MapFrom(
                                     source => source.City.Name
                                 ))
                 .ForMember(destination => destination.CountryName,
                                 option => option.MapFrom(
                                     source => source.City.CountryName
                                 ))
                 .ForMember(destination => destination.PropertyType,
                                 option => option.MapFrom(
                                     source => source.PropertyType.Name
                                 ))
                 .ForMember(destination => destination.FurnishingType,
                                 option => option.MapFrom(
                                     source => source.FurnishingType.Name
                                 ));

            CreateMap<Property,PropertyDetailsDto>()
                 .ForMember(destination => destination.City,
                                 option => option.MapFrom(
                                     source => source.City.Name
                                 ))
                 .ForMember(destination => destination.CountryName,
                                 option => option.MapFrom(
                                     source => source.City.CountryName
                                 ))
                 .ForMember(destination => destination.PropertyType,
                                 option => option.MapFrom(
                                     source => source.PropertyType.Name
                                 ))
                 .ForMember(destination => destination.FurnishingType,
                                 option => option.MapFrom(
                                     source => source.FurnishingType.Name
                                 ));

                CreateMap<FurnishingType,KeyValuePairDto>().ReverseMap();

                CreateMap<PropertyType,KeyValuePairDto>().ReverseMap();

                CreateMap<Property, PropertyDto>().ReverseMap();

                CreateMap<Photo, PhotoDto>().ReverseMap();
        }
    }
}