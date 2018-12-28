using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using Models.DAL;

namespace Models.BLL
{
    public class OrderManager
    {

        private OrderServices orders = new OrderServices();
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int add(Order order)
        {

            int re = orders.add(order);
            return re;

        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        //public List<Order> Query(Order order)
        //{

        //    return orders.Query(order);

        //}
        public List<Order> Query()
        {

            return orders.Query();

        }
    }
}