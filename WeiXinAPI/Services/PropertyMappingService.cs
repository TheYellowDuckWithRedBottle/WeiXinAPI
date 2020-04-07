using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;
using WeiXinAPI.Model;

namespace WeiXinAPI.Services
{
    public class PropertyMappingService: IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _cityPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)//完成cityDto到city的映射
            {
                {"Id",new PropertyMappingValue(new List<string>{"Id"})},
                {"CityName",new PropertyMappingValue(new List<string>{"CityName"})}
               
            };
        private readonly IList<IPropertyMapping> _propertyMappings=new List<IPropertyMapping>();
        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<CityDto, City>(_cityPropertyMapping));
        }
        public Dictionary<string,PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var matchingMapping = _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();
            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First().MappingDictionary;
            }
            throw new Exception(message:$"无法找到唯一映射关系:{typeof(TSource)},{typeof(TDestination)}") ;
        }
    }
}
