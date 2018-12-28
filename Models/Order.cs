using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    [Serializable]
    
    public class Order
    {
        
        public Order()
        {
  
    }
        public string orderno { get; set; }
        public string name { get; set; }
        public string tel { get; set; }
        public decimal total { get; set; }
        public int is_pay { get; set; }
        public string remark { get; set; }
        public int caeated_at { get; set; }
    }
}