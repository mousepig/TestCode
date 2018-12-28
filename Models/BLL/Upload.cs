using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebApplication1.Models.DAL;

namespace WebApplication1.Models.BLL
{
    public class Upload
    {
        HttpContextBase context = null;
        private string paths;

        public string FileUrl { get; private set; }
        public string FileSUrl { get; private set; }
        public string FileMUrl { get; private set; }
        public string FileExe { get; private set; }

        public Upload(HttpContextBase httpContext)
        {
            context = httpContext;
        }

        private bool showError(string message)
        {
            Hashtable hash = new Hashtable();
            hash["error"] = 1;
            hash["message"] = message;
            HttpContext.Current.Response.Write(message);
            HttpContext.Current.Response.End();
            return false;
        }

        public bool Up(HttpPostedFileBase imgFile)
        {
            return this.Up(imgFile, "image");
        }

        public bool Up(HttpPostedFileBase imgFile, string fileType)
        {
            String aspxUrl = context.Request.Path.Substring(0, context.Request.Path.LastIndexOf("/") + 1);

            //文件保存目录路径
            String savePath = "/FilePro/attached/";

            //文件保存目录URL
            String saveUrl = "/attached/";

            //定义允许上传的文件扩展名
            Hashtable extTable = new Hashtable();
            extTable.Add("image", "jpg,jpeg,png,bmp");

            //最大文件大小
            int maxSize = 1000000;

            if (imgFile == null)
            {
                showError("请选择文件。");
            }

            String dirPath = paths; //context.Server.MapPath(savePath);
            if (!Directory.Exists(dirPath))
            {
                showError("上传目录不存在。");
            }

            String dirName = fileType;
            if (String.IsNullOrEmpty(dirName))
            {
                dirName = "image";
            }
            if (!extTable.ContainsKey(dirName))
            {
                showError("目录名不正确。");
            }

            String fileName = imgFile.FileName;
            String fileExt = Path.GetExtension(fileName).ToLower();
            FileExe = fileExt;
            if (imgFile.InputStream == null || imgFile.InputStream.Length > maxSize)
            {
                showError("上传文件大小超过限制。");
            }

            if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(((String)extTable[dirName]).Split(','), fileExt.Substring(1).ToLower()) == -1)
            {
                showError("上传文件扩展名是不允许的扩展名。\n只允许" + ((String)extTable[dirName]) + "格式。");
            }

            //创建文件夹
            // dirPath += dirName + "/";
            //saveUrl += dirName + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            String ymd = DateTime.Now.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo);
            //  dirPath += ymd + "/";
            // saveUrl += ymd + "/";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", DateTimeFormatInfo.InvariantInfo) + fileExt;
            String filePath = dirPath + '\\' + newFileName;

            imgFile.SaveAs(filePath);
            FileUrl = newFileName;
            if (dirName != "image")
            {

                if (fileType == "image")
                {
                    bool? isSave = SaveImage(filePath);
                    if (isSave == null)
                    {
                        FileMUrl = FileUrl;
                        FileSUrl = saveUrl + "s_" + newFileName;
                    }
                    else if ((bool)isSave)
                    {
                        FileMUrl = saveUrl + "m_" + newFileName;
                        FileSUrl = saveUrl + "s_" + newFileName;
                    }
                    else
                    {
                        FileMUrl = FileUrl;
                        FileSUrl = FileUrl;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sSource">原始图片的地址</param>
        /// <param name="tSource">保存图片的地址</param>
        /// C:\Users\Public\Pictures\Sample Pictures\xkk.jpg
        public bool? SaveImage(string sSource)
        {
            sSource = sSource.Replace("/", "\\");
            string savePath = sSource.Substring(0, sSource.LastIndexOf("\\"));
            string tSource = sSource.Substring(sSource.LastIndexOf("\\") + 1);
            string sPicPath = savePath + "\\s_" + tSource;
            string mPicPath = savePath + "\\m_" + tSource;
            int width = Convert.ToInt32(WebConfigurationManager.AppSettings["smallPicWidth"]);
            int height = Convert.ToInt32(WebConfigurationManager.AppSettings["smallPicHeight"]);

            Image iSource = Image.FromFile(sSource);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            //Size tem_size = new Size(iSource.Width, iSource.Height); //创建了原图片的大小
            //if (tem_size.Height > height || tem_size.Width > width)
            //{
            //    if ((tem_size.Width * height) > (tem_size.Height * width))
            //    {
            //        sW = width;
            //        sH = (width * tem_size.Height) / tem_size.Width;
            //    }
            //    else
            //    {
            //        sH = height;
            //        sW = (tem_size.Width * height) / tem_size.Height;
            //    }
            //}
            //else
            //{
            //    sW = tem_size.Width;
            //    sH = tem_size.Height;
            //}

            Bitmap oB = new Bitmap(sW, sH);
            Graphics g = Graphics.FromImage(oB);
            g.Clear(Color.WhiteSmoke);
            g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImage(iSource, new Rectangle(0, 0, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            g.Dispose();

            int sw4 = sW * 4, sh4 = sH * 4;
            Bitmap oBm = null;
            //if (sw4 < tem_size.Width && sh4 < tem_size.Height)
            //{
            //    oBm = new Bitmap(sW * 4, sH * 4);
            //    Graphics gm = Graphics.FromImage(oBm);
            //    gm.Clear(Color.WhiteSmoke);
            //    gm.CompositingMode = CompositingMode.SourceCopy;
            //    gm.CompositingQuality = CompositingQuality.HighQuality;
            //    gm.SmoothingMode = SmoothingMode.HighQuality;
            //    gm.InterpolationMode = InterpolationMode.HighQualityBilinear;

            //    gm.DrawImage(iSource, new Rectangle(0, 0, sW * 4, sH * 4), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //    gm.Dispose();

            //}

            EncoderParameters eps = new EncoderParameters();
            //oB.Save(
            long[] v = new long[1];
            v[0] = 100;
            EncoderParameter p = new EncoderParameter(Encoder.Quality, v);//相应图形编码器需要的参数
            eps.Param[0] = p;
            try
            {
                ImageCodecInfo[] imageCodeArr = ImageCodecInfo.GetImageEncoders();//获取已经存在安装好的图形编码器
                ImageCodecInfo jpegInfo = null;
                for (int i = 0; i < imageCodeArr.Length; i++)
                {
                    if (imageCodeArr[i].FormatDescription.Equals("JPEG"))
                    {
                        jpegInfo = imageCodeArr[i];
                        break;
                    }
                }
                if (jpegInfo != null)
                {
                    oB.Save(sPicPath, jpegInfo, eps);
                    if (oBm != null)
                        oBm.Save(mPicPath, jpegInfo, eps);
                }
                else
                {
                    oB.Save(sPicPath, tFormat);
                    if (oBm != null)
                        oBm.Save(mPicPath, tFormat);
                }
                if (oBm == null)
                    return null;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                oB.Dispose();
                oBm.Dispose();
            }
        }
    }
}