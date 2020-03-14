using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    [Route(template: "api/provinces/{provinceId}/cities")]
    public class CityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProvinceRepository provinceRepository;

        public CityController(IMapper mapper, IProvinceRepository provinceRepository)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
        }
        /// <summary>
        /// 在某个省里面根据名字和过滤条件查询某个城市
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="filterName"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities(Guid provinceId,
            [FromQuery(Name = "CityName")]string filterName, string q)
        {
            var city = await provinceRepository.GetCitiesAsync(provinceId, filterName, q);
            if (city == null)
            {
                return NotFound();
            }
            var cityDtos = mapper.Map<IEnumerable<CityDto>>(city);
            return Ok(cityDtos);
        }
        /// <summary>
        /// 根据省的ID和城市的ID获取城市
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="CityId"></param>
        /// <returns></returns>
        [HttpGet(template: "{CityId}", Name = nameof(GetCity))]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCity(Guid provinceId, Guid CityId)
        {
            if (!await provinceRepository.ProvinceExistAsync(provinceId))
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

        /// <summary>
        /// 在某个省里面添加一个城市
        /// </summary>
        /// <param name="ProvinceId"></param>
        /// <param name="cityAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CityDto>> CreateCityForProvince(Guid ProvinceId, CityAddDto cityAddDto)
        {
            if (!await provinceRepository.ProvinceExistAsync(ProvinceId))
            {
                return NotFound();
            }
            var entity = mapper.Map<City>(cityAddDto);
            provinceRepository.AddCity(ProvinceId, entity);
            await provinceRepository.SaveAsync();

            var dtoReturn = mapper.Map<CityDto>(entity);
            return CreatedAtRoute(nameof(GetCity), new { provinceId = ProvinceId, CityId = dtoReturn.Id }, dtoReturn);
        }

        /// <summary>
        /// 根据省的名称和市的名称整体替换城市的内容
        /// </summary>
        /// <param name="ProvinceId"></param>
        /// <param name="CityId"></param>
        /// <param name="cityUpdateDto"></param>
        /// <returns></returns>
        [HttpPut(template: "{CityId}")]
        public async Task<IActionResult> UpdateCityForProvince(Guid ProvinceId, Guid CityId, CityUpdateDto cityUpdateDto)
        {

            if (!await provinceRepository.ProvinceExistAsync(ProvinceId))
            {
                return NotFound();
            }

            var city = await provinceRepository.GetCityAsync(ProvinceId, CityId);
            if (city == null)
            {
                return NotFound();
            }
            mapper.Map(cityUpdateDto, city);
            provinceRepository.UpdateCity(city);
            await provinceRepository.SaveAsync();
            return NoContent();
        }
        [HttpPatch(template: "{CityId}")]

        public async Task<IActionResult> PartiallyUpdateEmployeeForCompany(Guid ProvinceId, Guid CityId, 
            JsonPatchDocument<CityUpdateDto> patchDoucment)

        {
            if (!await provinceRepository.ProvinceExistAsync(ProvinceId))
            {
                return NotFound();
            }

            var city = await provinceRepository.GetCityAsync(ProvinceId, CityId);
            if (city == null)
            {
                return NotFound();
            }
            var dtoToPathch = mapper.Map<CityUpdateDto>(city);

            patchDoucment.ApplyTo(dtoToPathch,ModelState);
            //需要处理验证
            if (!TryValidateModel(dtoToPathch))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(dtoToPathch, city);
            provinceRepository.UpdateCity(city);
            await provinceRepository.SaveAsync();

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCityForProvince(Guid ProvinceId,Guid CityId)
        {
            if(!await provinceRepository.ProvinceExistAsync(ProvinceId))
            {
                return NotFound();
            }
            var city =await provinceRepository.GetCityAsync(ProvinceId, CityId);
            if(city==null)
            {
                return NotFound();
            }
            provinceRepository.DeleteCity(city);
            await provinceRepository.SaveAsync();
            return NoContent();
        }


    }
}
