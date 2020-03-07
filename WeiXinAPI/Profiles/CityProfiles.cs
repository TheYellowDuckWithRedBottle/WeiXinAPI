using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Model;

namespace WeiXinAPI.Profiles
{
    public class CityProfiles:Profile
    {
        public CityProfiles()
        {
            CreateMap<City, CityDto>()
                .ForMember(destinationMember: des => des.CityName
                , memberOptions: opt => opt.MapFrom(mapExpression: src => src.Name));
            CreateMap<CityAddDto, City>().ForMember(destinationMember:des=>des.Name
            ,memberOptions:opt=>opt.MapFrom(mapExpression:src=>src.CityName));
            CreateMap<CityUpdateDto, City>().ForMember(destinationMember: des => des.Name
            , memberOptions: opt => opt.MapFrom(mapExpression: src => src.CityName));
        }
    }
}
