using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Users
    {
        public enum Genders
        {
            男 = 0,
            女 = 1
        }

        public Users()
        {
        }
        public int UserId { get; set; }
        public string Tel { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }      
        public string verificationcode { get; set; }
        public int Gender { get; set; }
        public int Addr1 { get; set; }
        public int Addr2 { get; set; }
        public int Addr3 { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Touxiang { get; set; }
        public string Idcard { get; set; }
        public int? SellerId { get; set; }
        public string Likes { get; set; }
        public  int? Intentionality { get; set; }
        public string Nickname { get; set; }
        public string QQ { get; set; }
        public string WeChat { get; set; }
        public int? DateBirth { get; set; }
        public string Keyword { get; set; }
        public int? Level { get; set; }
        public int? Education { get; set; }
        public string Certification { get; set; }
        public int? IsLogin { get; set; }
        public int? status { get; set; }
        public int? AddTime { get; set; }
        public string Remark { get; set; }
        [NotMapped]
        public string Addr { get; set; }
        [NotMapped]
        public string sex { get; set; }
    }


}