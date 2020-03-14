using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Helps;
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
        public ProvinceController(IMapper mapper, IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository ?? throw new ArgumentNullException(nameof(provinceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet(Name =nameof(GetProvinces))]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<ProvinceDto>>> GetProvinces(
            [FromQuery] ProvinceDtoParameters provinceDtoParameters)
        {
            var province = await _provinceRepository.GetProvincesAsync(provinceDtoParameters);
            var previousLink = province.HasPrevious ? CreateProvincesResourceUri(provinceDtoParameters, ResourceUriType.PreviousPage) : null;
            var nextLink = province.HasNext ? CreateProvincesResourceUri(provinceDtoParameters, ResourceUriType.NextPage) : null;

            var paginationMetadata = new { 
                totalCount=province.TotalCount,
            pageSize=province.PageSize,
            currentPage=province.CurrentPage,
            totalPages=province.TotalPages,
                nextLink,
                previousLink,
            
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata,new JsonSerializerOptions { 
            Encoder=JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            }));
            var provinceDto = _mapper.Map<IEnumerable<ProvinceDto>>(province);
            return Ok(provinceDto);
        }

        [HttpGet(template: "{provinceId}", Name = nameof(GetProvince))]
        public async Task<ActionResult<ProvinceDto>> GetProvince(Guid provinceId)
        {
            var province = await _provinceRepository.GetProvinceAsync(provinceId);
            if (province == null)
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
        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,OPTIONS");
            return Ok();
        }
        [HttpDelete(template:"{provinceId}")]
        public async Task<IActionResult> DeleteProvinceById(Guid provinceId)
        {
            var provinceEntity = await _provinceRepository.GetProvinceAsync(provinceId);
            if (provinceEntity==null)
            {
                return NotFound();
            }
            await _provinceRepository.GetCitiesAsync(provinceId,null,null);
             _provinceRepository.DeleteProvince(provinceEntity);
            await _provinceRepository.SaveAsync();
            return NoContent();

        }
        private string CreateProvincesResourceUri(ProvinceDtoParameters parameters, ResourceUriType uriType)
        {
            switch (uriType)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link(nameof(GetProvinces), new 
                    { 
                        pageNumber=parameters.PageNuber-1,
                        pageSize=parameters.PageSize,
                        provinceName=parameters.ProvinceName,
                        searchTerm=parameters.SearchItems
                    });
                case ResourceUriType.NextPage:
                    return Url.Link(nameof(GetProvinces), new
                    {
                        pageNumber = parameters.PageNuber + 1,
                        pageSize = parameters.PageSize,
                        provinceName = parameters.ProvinceName,
                        searchTerm = parameters.SearchItems
                    });
                default:
                    return Url.Link(nameof(GetProvinces), new
                    {
                        pageNumber = parameters.PageNuber,
                        pageSize = parameters.PageSize,
                        provinceName = parameters.ProvinceName,
                        searchTerm = parameters.SearchItems
                    });
            }
        }
    }
}
