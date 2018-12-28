using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DAL;

namespace WebApplication1.Models.BLL
{
    public class ProvinceManager
    {
        private ProvinceServices p = new ProvinceServices();
        /// <summary>
        /// 查询省
        /// </summary>
        /// <returns></returns>
        public List<全国行政区划代码表> GetProvinces()
        {
            return p.GetProvinces();
        }
        public List<全国行政区划代码表> city(string Id)
        {
            return p.city(Id);
        }
    }
}