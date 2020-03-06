using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiXinAPI.Enitities
{
    public class City
    {
        public Guid Id { get; set; }
        public Guid ProvinceId { get; set; }
        public ICollection<Area> Areas { get; set; }
        public string Name { get; set; }
        public int TotalPopulation { get; set; }
        public int ConfirmedPopulation { get; set; }
        public int CurdPopulation { get; set; }
        public int DeadPopulation { get; set; }

        public Province province { get; set; }
    }
}
