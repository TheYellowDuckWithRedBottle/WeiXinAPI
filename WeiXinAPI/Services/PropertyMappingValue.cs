using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiXinAPI.Services
{
    public class PropertyMappingValue
    {
        public IEnumerable<string>  DestinationProperties { get; set; }//数据库实体中的多个属性

        public bool Revert { get; set; }//是否反转排序

        public PropertyMappingValue(IEnumerable<string> destinationProperties,bool revert=false)
        {
            Revert = revert;
            DestinationProperties = destinationProperties??throw new ArgumentNullException(nameof(destinationProperties));
        }
    }
}
