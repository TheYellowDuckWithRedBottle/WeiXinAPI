using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Helps;
using WeiXinAPI.Model;
using WeiXinAPI.Services;

namespace WeiXinAPI.Controllers
{
    [ApiController]
    [Route(template: "api/provincecollection")]
    public class CompanyCollectionsController:ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProvinceRepository provinceRepository;

        public CompanyCollectionsController(IMapper mapper,IProvinceRepository provinceRepository)
        {
            this.mapper = mapper;
            this.provinceRepository = provinceRepository;
        }
       [HttpGet(template:"{ids}",Name =nameof(GetProvinceCollection))]
       public async Task<ActionResult> GetProvinceCollection([FromRoute]
        [ModelBinder(BinderType =typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if(ids==null)
            {
                return BadRequest();
            }
            var entites = await provinceRepository.GetProvincesAsync(ids);

            if(ids.Count()!= entites.Count())
            {
                return NotFound();
            }
            var dtoToReturn = mapper.Map<IEnumerable<ProvinceDto>>(entites);
            return Ok(dtoToReturn);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProvinceDto>>> CreateProvinceCollection(IEnumerable<ProvinceAddDto> provinceCollection)
        {
            var provinceEntities = mapper.Map<IEnumerable<Province>>(provinceCollection);
            foreach (var province in provinceEntities)
            {
                provinceRepository.AddProvince(province);
            }
            await provinceRepository.SaveAsync();
            var dtos = mapper.Map<IEnumerable<ProvinceDto>>(provinceEntities);

            var idsString = string.Join(",", dtos.Select(x => x.id));
            return CreatedAtRoute(nameof(GetProvinceCollection), new { ids = idsString }, dtos);
        }
    }
}
