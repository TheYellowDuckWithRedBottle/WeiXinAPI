using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Model;

namespace WeiXinAPI.Profiles
{
    public class ProvinceProfiles:Profile
    {
        public ProvinceProfiles()
        {
            CreateMap<Province, ProvinceDto>()
                .ForMember(destinationMember: des => des.ProvinceName
                , memberOptions: opt => opt.MapFrom(mapExpression:src=>src.Name));
            CreateMap<ProvinceAddDto, Province>();
                
            
        }
    }
}
