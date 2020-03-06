using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Model;
using WeiXinAPI.ResourceParameters;
using WeiXinAPI.Services;

namespace WeiXinAPI.Controllers
{
    [ApiController]
    [Route(template: "api/provinces")]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;


        public ProvinceController(IMapper mapper,IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<ProvinceDto>>> GetProvinces([FromQuery] ProvinceDtoParameters  provinceDtoParameters)
        {
            var province = await _provinceRepository.GetProvincesAsync(provinceDtoParameters);
            var provinceDto = _mapper.Map<IEnumerable<ProvinceDto>>(province);
            return Ok(provinceDto);
        }

        [HttpGet(template:"{provinceId}",Name =nameof(GetProvince))]
        public async Task<ActionResult<ProvinceDto>> GetProvince(Guid provinceId)
        {
            var province = await _provinceRepository.GetProvinceAsync(provinceId);
            if(province==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProvinceDto>(province));
        }
        [HttpPost]
        public async Task<ActionResult<ProvinceDto>> CreateProvince([FromBody]ProvinceAddDto provinceAddDto)
        {
            var entity = _mapper.Map<Province>(provinceAddDto);
            _provinceRepository.AddProvince(entity);
            await _provinceRepository.SaveAsync();
            var returndto = _mapper.Map<ProvinceDto>(entity);

            return CreatedAtRoute(nameof(GetProvince), new { provinceId = returndto.id }, returndto);

        }


    }
}
