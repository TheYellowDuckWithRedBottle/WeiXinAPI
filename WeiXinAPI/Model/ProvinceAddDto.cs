using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeiXinAPI.Model
{
    public class ProvinceAddDto
    {
        [Display(Name="公司名")]
        [Required(ErrorMessage ="{0}这个字段是必填的")]
        [MaxLength(100,ErrorMessage ="{0}的最大长度不超过{1}")]
        public string Name { get; set; }

        public string ProvCapital { get; set; }
       
        public int TotalPopulation { get; set; }
        public int ConfirmedPopulation { get; set; }
        public int CurdPopulation { get; set; }
        public int DeadPopulation { get; set; }
        public ICollection<CityAddDto> Cities { get; set; } = new List<CityAddDto>();
    }
}
