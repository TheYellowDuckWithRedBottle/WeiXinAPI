using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Model;
using WeiXinAPI.Services;

namespace WeiXinAPI.Controllers
{
    [ApiController]
    [Route(template:"api/provinces/{provinceId}/cities")]
    public class CityController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProvinceRepository provinceRepository;

        public CityController(IMapper mapper,IProvinceRepository provinceRepository)
        {
            this.mapper = mapper??throw new ArgumentNullException(nameof(mapper));
            this.provinceRepository = provinceRepository?? throw new ArgumentNullException(nameof(provinceRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities(Guid provinceId,
            [FromQuery(Name ="CityName")]string filterName,string q)
        {
            var city =await provinceRepository.GetCitiesAsync(provinceId, filterName,q);
            if(city==null)
            {
                return NotFound();
            }
            var cityDtos = mapper.Map<IEnumerable<CityDto>>(city);
            return Ok(cityDtos);
        }
        [HttpGet(template:"{CityId}",Name =nameof(GetCity))]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCity(Guid provinceId,Guid CityId)
        {
            if(!await provinceRepository.ProvinceExistAsync(provinceId))
            {
                return NotFound();
            }
            var city = await provinceRepository.GetCityAsync(provinceId, CityId);
            if (city == null)
            {
                return NotFound();
            }
            var cityDto = mapper.Map<CityDto>(city);
            return Ok(cityDto);
        }
        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCityForProvince(Guid ProvinceId ,CityAddDto cityAddDto )
        {
            if(!await provinceRepository.ProvinceExistAsync(ProvinceId))
            {
                return NotFound();
            }
            var entity = mapper.Map<City>(cityAddDto);
            provinceRepository.AddCity(ProvinceId, entity);
            await provinceRepository.SaveAsync();

            var dtoReturn = mapper.Map<CityDto>(entity);
            return CreatedAtRoute(nameof(GetCity),new { provinceId = ProvinceId, CityId = dtoReturn.Id }, dtoReturn);
        }
       


    }
}
