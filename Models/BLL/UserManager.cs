using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.DAL;

namespace WebApplication1.Models.BLL
{
    public class UserManager
    {
        private UserServices users = new UserServices();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="Tel"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public Users Login(string Tel, string PassWord)
        {

            return users.Login(Tel, PassWord);
          
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Register(Users user)
        {

            int re = users.Register(user);
            return re;

        }
        /// <summary>
        /// 判断手机号是否存在(userId)
        /// </summary>
        /// <param name="handphone"></param>
        /// <returns></returns>
        public int IsExitstPhone(string handphone)
        {

            return users.IsExitstPhone(handphone);
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        public List<Users> UserList()
        {

            return users.UserList();

        }
        //public List<Users> ListUserId(string UserId)
        //{

        //    return users.ListUserId(UserId);

        //}
    }
}