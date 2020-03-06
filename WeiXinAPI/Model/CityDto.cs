using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeiXinAPI.Enitities;

namespace WeiXinAPI.Model
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public ICollection<Area> Areas { get; set; }
        public string CityName { get; set; }
        public int TotalPopulation { get; set; }
        public int ConfirmedPopulation { get; set; }
        public int CurdPopulation { get; set; }
        public int DeadPopulation { get; set; }

    }
}
