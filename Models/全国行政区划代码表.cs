using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class 全国行政区划代码表
    {
        public 全国行政区划代码表()
        {
        }
        public string 地区编码 { get; set; }
        public string 上级编码 { get; set; }
        public string 地区名称 { get; set; }
        public string 地区级别 { get; set; }
        public string 是否末级 { get; set; }
       
    }
}