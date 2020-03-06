using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Data;
using WeiXinAPI.Enitities;
using WeiXinAPI.ResourceParameters;

namespace WeiXinAPI.Services
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly WinXinApiDbContext _context;

        public ProvinceRepository(WinXinApiDbContext context)
        {
            _context = context??throw new ArgumentNullException(nameof(context));
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
        public async Task<IEnumerable<Province>> GetProvincesAsync(ProvinceDtoParameters parameters)
        {
            if(parameters==null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }
            if(string.IsNullOrWhiteSpace(parameters.ProvinceName)&&string.IsNullOrWhiteSpace(parameters.SearchItems))
               {
                return await _context.Province.ToListAsync();
            }
            var queryExpression = _context.Province as IQueryable<Province>;
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
            return await queryExpression
                .ToListAsync();
            
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
        public async Task<IEnumerable<City>> GetCitiesAsync(Guid ProvinceId,string CityName,string q)
        {
           if(ProvinceId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProvinceId));
            }
            if (string.IsNullOrWhiteSpace(CityName)&&string.IsNullOrWhiteSpace(q))
            {
                return await _context.cities.Where(x => x.ProvinceId == ProvinceId).ToListAsync();
            }

            var items = _context.cities.Where(x=>x.ProvinceId==ProvinceId) as IQueryable<City>;

            if (!string.IsNullOrWhiteSpace(CityName))
            {
                var cityStr = CityName.Trim();
                items = items.Where(x => x.Name == CityName);
            }
            if(!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim();
                items = items.Where(x => x.Name.Contains(q));

            }

            return await items.OrderBy(x => x.Id).ToListAsync();
        
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
