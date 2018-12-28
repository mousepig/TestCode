using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;

namespace Models.BLL
{
    public class Common
    {

        /// <summary>
        /// 生成随机编码
        /// </summary>
        public static string Num()
        {
            string code = "SN" + DateTime.Now.ToString("yyyyMMddHHmmssffffff");
            return code;
        }
        /// <summary>
        /// 随机生成用户名
        /// </summary>
        /// <returns></returns>
        public static string GetNames()
        {
            string[] Name1 =  { "赵", "钱", "孙", "李", "周", "吴", "郑", "王", "冯",
                               "陈", "褚", "卫", "蒋", "沈", "韩", "杨", "朱", "秦", "尤", "许", "何", "吕", "施",
                               "张", "孔", "曹", "严", "华", "金", "魏", "陶", "姜", "戚", "谢", "邹", "喻", "柏",
                                "水", "窦", "章", "云", "苏", "潘", "葛", "奚", "范", "彭", "郎" };
            string[] Name2 = {"鲁","韦","昌","马","苗","凤","花","方","俞","任","袁"
                              ,"柳","酆","鲍","史","唐","费","廉","岑","薛","雷","贺","倪","汤","滕","殷","罗",
                              "毕","郝","邬","安","常","乐","于","时","傅","皮","卞","齐","康","伍","余","元",
                              "卜","顾","孟","平","黄"};
            string[] Name3 = { "梅", "盛", "林", "刁", "锺", "徐", "邱", "骆", "高",
                              "夏", "蔡", "樊", "胡", "凌", "霍", "虞", "万", "支", "柯", "昝", "管", "卢", "莫",
                              "经", "房", "裘", "缪", "干", "解", "应", "宗", "丁", "宣", "贲", "邓", "郁", "单",
                              "杭", "洪", "包", "诸", "左", "石", "崔", "吉", "钮", "龚", "程", "嵇", "邢", "滑",
                              "裴", "陆", "荣", "翁", "荀", "羊", "於", "惠", "甄", "麴", "家", "封", "芮", "羿",
                              "储", "靳", "汲", "邴", "糜", "松", "井" };
            int index1 = new Random().Next(0, Name1.Length);
            int index2 = new Random().Next(0, Name2.Length);
            int index3 = new Random().Next(0, Name3.Length);
            string Name = Convert.ToString(Name1[index1] + Name2[index2] + Name3[index3]);
            Console.WriteLine("这次生成的名字是：" + Name);
            return Name;

        }

        /// <summary>
        /// 随机生成电话号码
        /// </summary>
        /// <returns></returns>
        public static string getRandomTel()
        {
            string[] telStarts = "134,135,136,137,138,139,150,151,152,157,158,159,130,131,132,155,156,133,153,180,181,182,183,185,186,176,187,188,189,177,178".Split(',');
            Random ran = new Random();
            int n = ran.Next(10, 1000);
            int index = ran.Next(0, telStarts.Length - 1);
            string first = telStarts[index];
            string second = (ran.Next(100, 888) + 10000).ToString().Substring(1);
            string thrid = (ran.Next(1, 9100) + 10000).ToString().Substring(1);
            return first + second + thrid;
        }
        /// <summary>
        /// 是否支付
        /// </summary>
        public static int is_pay()
        {
         int ispay= new Random().Next(0, 2);
            return ispay;
    }
        /// <summary> 
        /// 生成时间戳 
        /// </summary> 
        /// <returns></returns> 

        public static int GetTimeStamp()
        {
            int created_at = new Random().Next(1483200000, 1542120623);



            //long unixTimeStamp = 1478162177;
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); 
            DateTime dt = startTime.AddSeconds(created_at);//Unix时间戳转时间
            

            return created_at;
        }
        /// <summary>
        /// 价格随机数
        /// </summary>
        /// <returns></returns>
        public static int total()
        {

            //int a = new Random().Next(99);
            //int b = new Random().Next(99);
            // int tep = a + b;
            // string temp = tep.ToString();
            // return temp;
            int price = new Random().Next(0, 5000);
            return price;

        }

        #region MD5加密
        public static string MD5(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(pwd);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            string str = "";
            for (int i = 0; i < md5data.Length; i++)
            {
                str += md5data[i].ToString("x").PadLeft(2, '0');

            }
            return str;
        }
        #endregion

        /// <summary>
        /// 随机数
        /// </summary>
        /// <returns></returns>
        public static string strRandom()
        {
            string num = "";
            for (int i = 0; i < 6; i++)
            {


                Random rd = new Random();
                num = rd.Next(000000, 999999).ToString();
            }
            return num;
        }
        #region 生成日期随机码
        /// <summary>
        /// 生成日期随机码
        /// </summary>
        /// <returns></returns>
        public static string GetRamCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }

        #region 过滤HTML标记
        public static string DropinHtml(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring)) return "";
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            // Htmlstring = Regex.Replace(Htmlstring, @"<(?!p|/p).*?>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<(?!p|/p|img|br).*?>", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);

            // Htmlstring = Regex.Replace(Htmlstring, @"<(?!(img|src)\s+)[^<>]*?>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Htmlstring.Replace("&emsp;", "");
            Htmlstring = Htmlstring.Replace("div", "p");
            Htmlstring = Htmlstring.Replace("&", "");
            // Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion
        #endregion
        /// <summary>
        /// 返回文件扩展名，不含“.”
        /// </summary>
        /// <param name="_filepath">文件全名称</param>
        /// <returns>string</returns>
        public static string GetFileExt(string _filepath)
        {
            if (string.IsNullOrEmpty(_filepath))
            {
                return "";
            }
            if (_filepath.LastIndexOf(".") > 0)
            {
                return _filepath.Substring(_filepath.LastIndexOf(".") + 1); //文件扩展名，不含“.”
            }
            return "";
        }
        #region 获得当前绝对路径
        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPath(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                //return HttpContext.Current.Server.MapPath(strPath);
                return strPath;
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }

        /// <summary>
        /// 获得当前绝对路径
        /// </summary>
        /// <param name="strPath">指定的路径</param>
        /// <returns>绝对路径</returns>
        public static string GetMapPathj(string strPath)
        {
            if (strPath.ToLower().StartsWith("http://"))
            {
                return strPath;
            }
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion

        public class Picture
        {
            private Image srcImage;
            private string srcFileName;

            /// <summary>
            /// 创建
            /// </summary>
            /// <param name="FileName">原始图片路径</param>
            public bool SetImage(string FileName)
            {
                srcFileName = GetMapPath(FileName);
                try
                {
                    srcImage = Image.FromFile(srcFileName);
                }
                catch
                {
                    return false;
                }
                return true;

            }

            #region 保存图片

            /// <summary>
            /// 保存图片
            /// </summary>
            /// <param name="image">Image 对象</param>
            /// <param name="savePath">保存路径</param>
            /// <param name="ici">指定格式的编解码参数</param>
            private static void SaveImage(Image image, string savePath, ImageCodecInfo ici)
            {
                //设置 原图片 对象的 EncoderParameters 对象
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = new EncoderParameter(Encoder.Quality, ((long)100));
                image.Save(savePath, ici, parameters);
                parameters.Dispose();
            }

            /// <summary>
            /// 获取图像编码解码器的所有相关信息
            /// </summary>
            /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
            /// <returns>返回图像编码解码器的所有相关信息</returns>
            private static ImageCodecInfo GetCodecInfo(string mimeType)
            {
                ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
                foreach (ImageCodecInfo ici in CodecInfo)
                {
                    if (ici.MimeType == mimeType)
                        return ici;
                }
                return null;
            }


            /// <summary>
            /// 得到图片格式
            /// </summary>
            /// <param name="name">文件名称</param>
            /// <returns></returns>
            public static ImageFormat GetFormat(string name)
            {
                string ext = name.Substring(name.LastIndexOf(".") + 1);
                switch (ext.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                        return ImageFormat.Jpeg;
                    case "bmp":
                        return ImageFormat.Bmp;
                    case "png":
                        return ImageFormat.Png;
                    case "gif":
                        return ImageFormat.Gif;
                    default:
                        return ImageFormat.Jpeg;
                }
            }
            #endregion

            /// <summary>
            /// 获取图片流
            /// </summary>
            /// <param name="url">图片URL</param>
            /// <returns></returns>
            private static Stream GetRemoteImage(string url)
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                request.ContentLength = 0;
                request.Timeout = 20000;
                HttpWebResponse response = null;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    return response.GetResponseStream();
                }
                catch
                {
                    return null;
                }
            }

            public string PostDataGetHtml(string uri, string postData)
            {
                try
                {
                    byte[] data = System.Text.Encoding.UTF8.GetBytes(postData);

                    Uri uRI = new Uri(uri);
                    HttpWebRequest req = WebRequest.Create(uRI) as HttpWebRequest;
                    req.Method = "POST";
                    req.KeepAlive = true;
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = data.Length;
                    req.AllowAutoRedirect = true;

                    Stream outStream = req.GetRequestStream();
                    outStream.Write(data, 0, data.Length);
                    outStream.Close();

                    HttpWebResponse res = req.GetResponse() as HttpWebResponse;
                    Stream inStream = res.GetResponseStream();
                    StreamReader sr = new StreamReader(inStream, System.Text.Encoding.UTF8);
                    string htmlResult = sr.ReadToEnd();

                    return htmlResult;
                }
                catch (Exception ex)
                {
                    return "网络错误：" + ex.Message.ToString();
                }
            }
        }
    }
}