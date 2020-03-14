using System;

namespace WeiXinAPI.ResourceParameters
{
    public class ProvinceDtoParameters
    {
        const int MaxPageSize = 20;//最大值
        public string ProvinceName { get; set; }
        public string SearchItems { get; set; }
        
       
        public int PageNuber { get; set; } = 1;//默认的页数
        private int _pageSize=10;//默认多少页

        public int PageSize//设置Pagesize和MaxPageSize的关系
        {
            get => _pageSize;
            set => _pageSize = (value>MaxPageSize?MaxPageSize:value);
        }

    }
}
