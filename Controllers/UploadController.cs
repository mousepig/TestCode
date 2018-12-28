using Models.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UploadController : Controller
    {
        // GET: Test
        public JsonResult  Upload()
        {     
            return Json(new { status = 1, message = "添加用户成功" });
        }
        // GET: Test
        public JsonResult Uploads(HttpPostedFileBase file)
        {

            string fileExt = Common.GetFileExt(file.FileName); //文件扩展名，不含“.”
           string  GetMapPath= Common.GetMapPath(file.FileName);
           string data= DateTime.Now.ToString("yyyyMM");
            string uploadPath = HttpContext.Request.MapPath("/Upload/"+data+"/");
            //string uploadPath = ("./UploadFile/");
            string fileName = file.FileName.Substring(file.FileName.LastIndexOf(@"\") + 1); //取得原文件名
            string imgurl = "/Upload/"+data+"/";
            string newFileName = Common.GetRamCode() + "." + fileExt; //随机生成新的文件名
            string FilePath = uploadPath + newFileName; //上传后的路径
            file.SaveAs(FilePath);
            return Json(new { status = 1, message = "成功" , photo = imgurl + newFileName });
        }

    }
}