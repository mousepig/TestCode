using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DAL;

namespace WebApplication1.Models.BLL
{
    public class AddressManager
    {
        private AddressServices addr = new AddressServices();

        /// <summary>
        /// 根据地区编码查地区名称
        /// </summary>
        /// <param name="addr3"></param>
        /// <returns></returns>
        public List<全国行政区划代码表> Checks(string addr3)
        {
            return addr.Checks(addr3);
        }
    }
}