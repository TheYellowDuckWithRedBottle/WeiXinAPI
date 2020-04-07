using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiXinAPI.ResourceParameters
{
    public class CityDtoParameters
    {
        private const int MaxPageSize = 20;
        public string CityName { get; set; }
        public string Q { get; set; }
        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string OrderBy { get; set; } = "Name";
    }
}
