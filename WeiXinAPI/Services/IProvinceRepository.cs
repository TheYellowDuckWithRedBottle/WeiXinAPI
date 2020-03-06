using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.ResourceParameters;

namespace WeiXinAPI.Services
{
   public interface IProvinceRepository
    {
        Task<IEnumerable<Province>> GetProvincesAsync(ProvinceDtoParameters parameters);
        Task<IEnumerable<Province>> GetProvincesAsync(IEnumerable<Guid> guids);
        Task<Province> GetProvinceAsync(Guid Province);
        Task<Province> GetProvinceAsync(string ProvinceName);

        void AddProvince(Province province);
        void UpdateProvince(Province province);
        void DeleteProvince(Province province);
        Task<bool> ProvinceExistsAsync(string ProvinceName);
        Task<bool> ProvinceExistAsync(Guid guid);


        Task<IEnumerable<City>> GetCitiesAsync(Guid Province,string cityName,string q);
        Task<City> GetCityAsync(Guid ProvinceId,Guid CityId);

        void AddCity(Guid ProvinceId, City   City);
        void UpdateCity(City city);
        void DeleteCity(City city);
        Task<bool> CityExistsAsync(string CityName);
        Task<bool> CityExistsAsync(Guid guid);

        Task<bool> SaveAsync();
    }
}
