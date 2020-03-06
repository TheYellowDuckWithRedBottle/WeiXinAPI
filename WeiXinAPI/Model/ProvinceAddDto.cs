using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiXinAPI.Model
{
    public class ProvinceAddDto
    {
        public string Name { get; set; }

        public string ProvCapital { get; set; }
       
        public int TotalPopulation { get; set; }
        public int ConfirmedPopulation { get; set; }
        public int CurdPopulation { get; set; }
        public int DeadPopulation { get; set; }
        public ICollection<CityAddDto> Cities { get; set; } = new List<CityAddDto>();
    }
}
