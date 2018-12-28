using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }
        public BaseController() {


            //try
            //{

            //    Session["UserId"].ToString();
            //    if (Session["UserId"] == null)
            //    {
            //        Response.Write("<script>alert('请登录')</script>");
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('已登录')</script>");
            //    }
            //}
            //catch 
            //{

            //}


            //if ( Session["UserId"]==null)
            //{

            //    Response.Write("<script>alert('请登录')</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('已登录')</script>");
            //}
      
        //Users model = new Users();
           
            
        //        if (model.UserId!= null)
        //        {
        //            model = Session["UserId"] as Users;
        //        }
        //        else
        //        {
        //        //Response.Write(" <script>alert('请先登录');window.location='/Home/Logins';</script>");
              
               
        //       // return;
        //        }
            
           
        }

    }
}