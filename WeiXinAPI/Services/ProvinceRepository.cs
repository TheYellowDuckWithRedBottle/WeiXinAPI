using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Data;
using WeiXinAPI.Enitities;
using WeiXinAPI.Helps;
using WeiXinAPI.Model;
using WeiXinAPI.ResourceParameters;

namespace WeiXinAPI.Services
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly WinXinApiDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;
        public ProvinceRepository(WinXinApiDbContext context,IPropertyMappingService propertyMappingService)
        {
            _context = context??throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        }
       /// <summary>
       /// 添加省数据
       /// </summary>
       /// <param name="province"></param>
        public void AddProvince(Province province)
        {
            if (province == null)
            {
                throw new ArgumentNullException(nameof(province));
            }
            province.Id = Guid.NewGuid();
            if (province.Cities != null)
            {
                foreach (var city in province.Cities)
                {
                    city.Id = Guid.NewGuid();
                }
            }
            _context.Province.Add(province);
        }
       /// <summary>
   /// 删除省
   /// </summary>
   /// <param name="province"></param>
        public void DeleteProvince(Province province)
        {
            if (province == null)
            {
                throw new ArgumentNullException(nameof(province));
            }
            _context.Province.Remove(province);
        }
        /// <summary>
        /// 根据省Id获取省
        /// </summary>
        /// <param name="ProvinceId"></param>
        /// <returns></returns>
        public async Task<Province> GetProvinceAsync(Guid ProvinceId)
        {
            if (ProvinceId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProvinceId));
            }
            return await _context.Province.FirstOrDefaultAsync(predicate: x => x.Id == ProvinceId);
        }
        /// <summary>
        /// 根据省的名字获取省
        /// </summary>
        /// <param name="ProvinceName"></param>
        /// <returns></returns>
        public async Task<Province> GetProvinceAsync(string ProvinceName)
        {
            if(string.IsNullOrWhiteSpace(ProvinceName))
            {
                throw new ArgumentNullException(nameof(ProvinceName));
            }
            return await _context.Province.Where(x => x.Name == ProvinceName).FirstOrDefaultAsync();
        }
        public async Task<PagedList<Province>>  GetProvincesAsync(ProvinceDtoParameters parameters)
        {
            if(parameters==null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
          
            var queryExpression = _context.Province as IQueryable<Province>;//可以延迟执行
            if(!string.IsNullOrWhiteSpace(parameters.ProvinceName))
            {
                parameters.ProvinceName = parameters.ProvinceName.Trim();
                queryExpression = queryExpression.Where(x => x.Name == parameters.ProvinceName);
            }
            if (!string.IsNullOrWhiteSpace(parameters.SearchItems))
            {
                parameters.SearchItems = parameters.SearchItems.Trim();
                queryExpression = queryExpression.Where(x => x.Name.Contains(parameters.SearchItems));
            }
            //完成过滤和搜索之后进行分页

            return await PagedList<Province>.CreateAsync(queryExpression,parameters.PageNuber,parameters.PageSize);
               //遇到Tolist，foreach，singleOrDefault会查询数据库
            
        }
        public async Task<IEnumerable<Province>> GetProvincesAsync(IEnumerable<Guid> provinceIds)
        {
            if (provinceIds == null)
            {
                throw new ArgumentNullException(nameof(provinceIds));
            }
            return await _context.Province.
                Where(x => provinceIds.Contains(x.Id)).
                OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<bool> ProvinceExistAsync(Guid provinceId)
        {
            if(provinceId == null)
            {
                throw new ArgumentNullException(nameof(provinceId));
            }
            return await _context.Province.AnyAsync(predicate: x => x.Id == provinceId);
        }

        public async Task<bool> ProvinceExistsAsync(string ProvinceName)
        {
            if(ProvinceName==null)
            {
                throw new ArgumentNullException(nameof(ProvinceName));
            }
            return await _context.Province.AnyAsync(predicate: x => x.Name == ProvinceName);
        }     

        public void UpdateProvince(Province province)
        {
           // throw new NotImplementedException();
        }


        public void AddCity(Guid ProvinceId, City City)
        {
            if(ProvinceId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProvinceId));
            }
            if (City == null)
            {
                throw new ArgumentNullException(nameof(City));
            }
            City.ProvinceId = ProvinceId;
            _context.cities.Add(City);

        }
        public Task<bool> CityExistsAsync(string CityName)
        {
            throw new NotImplementedException();
        }
        public void UpdateCity(City city)
        {
           
        }
        public Task<bool> CityExistsAsync(Guid guid)
        {
            throw new NotImplementedException();
        }
        public void DeleteCity(City city)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<City>> GetCitiesAsync(Guid ProvinceId,CityDtoParameters parameters)
        {
           if(ProvinceId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProvinceId));
            }
        
            var items = _context.cities.Where(x=>x.ProvinceId==ProvinceId) as IQueryable<City>;

            if (!string.IsNullOrWhiteSpace(parameters.CityName))
            {
                var cityStr = parameters.CityName.Trim();
                items = items.Where(x => x.Name == cityStr);
            }
            if(!string.IsNullOrWhiteSpace(parameters.Q))
            {
                parameters.Q = parameters.Q.Trim();
                items = items.Where(x => x.Name.Contains(parameters.Q));

            }

            var mappgingDictionary = _propertyMappingService.GetPropertyMapping<CityDto, City>();

            items.ApplySort(parameters.OrderBy, mappgingDictionary);

            return await items.ToListAsync();
        
        }

        public async Task<City> GetCityAsync(Guid ProvinceId, Guid CityId)
        {
            if(ProvinceId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProvinceId));
            }
            if(CityId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CityId));
            }
            return await _context.cities.Where(x => x.ProvinceId == ProvinceId && x.Id == CityId).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
       
    }
}
