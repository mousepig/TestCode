using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.BLL;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class DataController : Controller
    {


        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            var fileName = file.FileName;
            var filePath = Server.MapPath(string.Format("~/{0}", "File"));
            file.SaveAs(Path.Combine(filePath, fileName));
            return View();
        }


        public ActionResult Address()
        {

            return View();
        }

        List<SelectListItem> items = new List<SelectListItem>();
        List<string> date = new List<string>();
        public static List<全国行政区划代码表> plist = new List<全国行政区划代码表>();
        private ProvinceServices pss = new ProvinceServices();

        #region 加载省
        /// <summary>
        /// 加载省
        /// </summary>
        /// <returns></returns>
        public JsonResult Provinces()
        {

            var list = pss.GetProvinces();
            foreach (var item in list)
            {
                date.Add(item.地区名称);

                items.Add(new SelectListItem()
                {
                    Text = string.Concat("", " ", item.地区名称),
                    Value = item.地区编码.ToString()
                });
            }
            if (!items.Count.Equals(0))
            {
                items.Insert(0, new SelectListItem() { Text = "选择省", Value = "" });
            }

            return Json(items, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 加载市
        /// <summary>
        /// 加载市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetCities(string id)
        {
            var list = pss.city(id);
            foreach (var item in list)
            {
                date.Add(item.地区名称);

                items.Add(new SelectListItem()
                {
                    Text = string.Concat("", " ", item.地区名称),
                    Value = item.地区编码.ToString()
                });
            }
            if (!items.Count.Equals(0))
            {
                items.Insert(0, new SelectListItem() { Text = "选择市", Value = "" });
            }
            return Json(items, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 加载区

        /// <summary>
        /// 加载区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Area(string id)
        {
            var list = pss.city(id);
            foreach (var item in list)
            {
                date.Add(item.地区名称);

                items.Add(new SelectListItem()
                {
                    Text = string.Concat("", " ", item.地区名称),
                    Value = item.地区编码.ToString()
                });
            }
            //if (!items.Count.Equals(0))
            //{
            //    items.Insert(0, new SelectListItem() { Text = "请选择", Value = "" });
            //}
            return Json(items, JsonRequestBehavior.AllowGet);

        }
        #endregion



        private UserManager user = new UserManager();
        Users model = new Users();

        #region 保存地址

        [HttpPost]
        public JsonResult Address1(string p, string c, string a)
        {
            model.Address = p + c + a;
            user.Register(model);
            return Json(new { status = 1, msg = "地址添加成功!" });
        }
        #endregion

    }
}