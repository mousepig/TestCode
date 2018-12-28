using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Models.DAL;
using Models.BLL;
using WebApplication1.Models;
using WebApplication1.Models.DAL;
using WebApplication1.Models.BLL;
using System.Text.RegularExpressions;
using System.IO;
using System.Web.Services.Description;
using static WebApplication1.Models.Users;

namespace WebApplication1.Controllers
{
    public class HomeController : BaseController
    {
        public new ActionResult Index()
        {
            ViewData["Message"] = "hello word";
            return View();
        }

        Order order = new Order();
        private OrderServices orders = new OrderServices();
        [HttpPost]
        public ActionResult Index(List<string> orderno, List<string> name, List<string> tel, List<decimal> total, List<int> is_pay, List<string> remark, List<int> caeated_at)
        {

            for (int i = 0; i < orderno.Count; i++)
            {


                order.orderno = orderno[i];
                order.name = name[i];
                order.tel = tel[i];
                order.total = total[i];
                order.is_pay = is_pay[i];
                order.remark = remark[i];
                order.caeated_at = caeated_at[i];
                ProductSubmit(order);
            }
            return View();
        }
        public bool ProductSubmit(Order order)
        {

            orders.add(order);

            return true;
        }

        public List<Order> Query()
        {

            return orders.Query();

        }
        public ActionResult About()
        {
            var list = Query();
            foreach (var item in list)
            {
                //  info= item.orderno;

                //   Array name[i] = item.name;
                ViewBag.Model = list;
            }
            return View();
        }
        [HttpPost]
        public ActionResult About1()
        {

            var list = Query();
            JsonResult ajaxRes = new JsonResult();
            // string[] info = { };

            List<string> date = new List<string>();
            List<string> count = new List<string>();

            foreach (var item in list)
            {
                //  info= item.orderno;

                //   Array name[i] = item.name;
                ViewBag.Model = list;

                date.Add(item.orderno);
                count.Add(item.name);

                //  ajaxRes.Data = new { 日期 = item.orderno, 统计 = item.name };

            }
            string[] dateArr = date.ToArray();
            string[] countArr = count.ToArray();
            ajaxRes.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //  ajaxRes.Data = dateArr;
            //   ajaxRes.Data = countArr;
            ajaxRes.Data = new { 日期 = dateArr, 统计 = countArr };


            return ajaxRes;
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public JsonResult Contact1()
        {
            string[][] user =
                {
                new string[]{ "李蕊", "18"},
                new string[]{ "王宝杰", "20" },
                new string[]{ "李海鹏", "15" }
            };
            string[] name = new string[3];
            string[] age = new string[3];
            //  List<string> name = new List<string>();
            // string[] dateArr = name.ToArray();
            for (int i = 0; i <= 2; i++)
            {

                name[i] = user[i][0];
                age[i] = user[i][1];


            }
            string[][] date = new string[2][];
            date[0] = name;
            date[1] = age;

            return Json(date);
        }

        public ActionResult UserList(int page = 1, int limit = 30)
        {
            Provinces();
            List(page = 1, limit = 30);
            
            return View();
        }

        [HttpGet]
        public JsonResult List(int page=1,int limit=30)
        {

            List<Users> ulist = new List<Users>();
            List<全国行政区划代码表> plist = new List<全国行政区划代码表>();
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            int Count = 0;
                
 
            var lists = user.UserList();
          
            foreach (Users item in lists)
            {
                //Session["UserId"] = item.UserId.ToString();
                //var add = user.ListUserId(item.UserId.ToString());

                //ViewBag.Add1 = add[0].Addr1.ToString();
                if (item.Gender==0)
                {
                    item.sex = Genders.男.ToString();
                }
                if (item.Gender == 1)
                {
                    item.sex = Genders.女.ToString();
                }
                var alist1 = address.Checks(item.Addr1.ToString());
                ViewBag.List = item.Addr1.ToString();
                

                var alist2 = address.Checks(item.Addr2.ToString());
                ViewBag.Addr2 = item.Addr2.ToString();

               
                var alist3 = address.Checks(item.Addr3.ToString());
                ViewBag.Addr3 = item.Addr3.ToString();


                    // ViewBag.cc = GetCities(ViewBag.List);
                    //ViewBag.aa = Area(ViewBag.Addr2);

                
                if (lists.Count == 0)//当一条用户数据都没有时，执行
                {
                    item.Addr = "";
                }
                if (alist1.Count==0)//当item.Addr1没值时，执行
                {
                    item.Addr = "";
                }
                else
                {
                    ViewBag.List1 = alist1[0].地区名称;
                    ViewBag.List2 = alist2[0].地区名称;
                    ViewBag.List3 = alist3[0].地区名称;
                    
                    item.Addr= alist1[0].地区名称+' '+ alist2[0].地区名称 + ' ' + alist3[0].地区名称 + ' ' ;
                    ViewBag.Addrr = item.Addr.Split(' ')[0];
                    ViewBag.Addrrr = item.Addr.Substring(item.Addr.LastIndexOf(" "));
                }
             
             
            }
            
            
          
            //foreach (var item in lists)
            //{
            //    address.Checks(item.Addr3.ToString());
            //    var alist = address.Checks(item.Addr3.ToString());
            //     var areaname = "";
            //    foreach (var aitem in alist)
            //    {
            //        areaname = aitem.地区名称;
            //    }
            //   var Addr3 = item.Addr3.ToString();
            //    Addr3 = areaname;
            //    //json.Data = new {ID=item.UserId, 用户名 = item.UserName, 性别= item.Gender, 城市 = Addr3, 身份证号 = item.Idcard,爱好 = item.Likes };              
            //}

            TableModel<Users> laydata = new TableModel<Users>();
            laydata.code = 200;
            laydata.msg = "";
            laydata.count = Count;
            laydata.data = lists;
            json.Data = laydata;

            //GetCities(ViewBag.List);
            return json;
        }


        public ActionResult Add()
        {
            return View();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        //[HttpPost]
        //public JsonResult Adds(string userid, string password, string username)
        //{
        //    if (userid == "")
        //    {
        //        // Response.Write("<script>alert('请输入手机号!');location.href='/Home/Adds';</script>");
        //        return Json(new { status = 1, message = "请输入手机号" });
        //    }
        //    model.UserId = userid;
        //    model.PassWord = password;
        //    model.PassWord = Common.MD5(model.PassWord);
        //    model.UserName = username;

        //    //  保存到数据库
        //    int result = user.IsExitstPhone(userid);
        //    if (result > 0)
        //    {
        //        return Json(new { status = 1, message = "手机号码已经被占用！请换手机号码" });
        //    }


        //    user.Register(model);

        //    return Json(new { status = 1, message = "添加用户成功" });
        //}
        [ValidateInput(false)]
        public string Adds()
        {
            if (Request.Form["Tel"].ToString() == "")
            {
                Response.Write("<script>alert('请输入手机号!');location.href='/Home/Managers';</script>");
                return "请输入手机号";
            }
            model.Touxiang = Request.Form["Touxiang"].ToString();//头像
            model.Tel = Request.Form["Tel"].ToString();//电话
            model.PassWord = Request.Form["password"].ToString();
            model.PassWord = Common.MD5(model.PassWord);//密码
           // model.UserName = Request.Form["username"].ToString();//用户名
          model.UserName = Server.HtmlEncode(Common.DropinHtml(Request.Form["username"].ToString()));
            model.Age = Convert.ToInt32(Request.Form["Age"]);//年龄
            model.Idcard = Request.Form["Idcard"].ToString();//身份证号
            model.Email = Request.Form["Email"].ToString();//邮箱
            
            model.SellerId = Convert.ToInt32(Request.Form["SellerId"]);//销售员id 
            model.Nickname = Request.Form["Nickname"].ToString();//昵称
            model.QQ = Request.Form["QQ"].ToString();//QQ号
            model.WeChat = Request.Form["WeChat"].ToString();//微信号
            DateTime DateStart = new DateTime(1970, 1, 1, 8, 0, 0);//时间戳的开始时间
            DateTime Birth = DateTime.Today;//当前时间
          //  DateTime Birth = Convert.ToDateTime(DateTime.Today.ToString("yyyy-MM-dd"));
            //DateTime Birth = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
            //bo表示是否转换成功 如果转换不成功yu的值是0，成功则是转换后的值。
            bool bo = DateTime.TryParse(Request.Form["DateBirth"], out Birth);
            if (bo == true)
            {
                DateTime DateBirth = Convert.ToDateTime(Request.Form["DateBirth"]);//出生日期
                model.DateBirth = Convert.ToInt32((DateBirth - DateStart).TotalSeconds);//出生日期转时间戳
            }
             model.DateBirth =null;

            model.AddTime = Convert.ToInt32((DateTime.Now - DateStart).TotalSeconds);//当前时间的时间戳
            int yu = 0;
            //bo表示是否转换成功 如果转换不成功yu的值是0，成功则是转换后的值。
            bool p = int.TryParse(Request.Form["p"], out yu);
            if (p == true)
            {
                model.Addr1 = Convert.ToInt32(Request.Form["p"]);//省
            }
            bool c = int.TryParse(Request.Form["c"], out yu);
            if (c == true)
            {
                model.Addr2 = Convert.ToInt32(Request.Form["c"]);//市
            }
            bool a = int.TryParse(Request.Form["a"], out yu);
            if (a == true)
            {
                model.Addr3 = Convert.ToInt32(Request.Form["a"]);//区
            }
            //model.Addr2 = Convert.ToInt32(Request.Form["c"]);
            //model.Addr3 = Convert.ToInt32(Session["id"]);
            model.Address = Request.Form["Address"].ToString();//详细地址
            model.Gender = Convert.ToInt32(Request.Form["Gender"]);//性别
            model.Likes = Request.Form["Likes"].ToString();//爱好
            string Keyword = Request.Form["Keyword"].ToString();//关键字
            model.Level = Convert.ToInt32(Request.Form["Level"]);//会员级别
            model.Education = Convert.ToInt32(Request.Form["Education"]);//学历
            model.Remark = Server.HtmlEncode(Common.DropinHtml(Request.Form["Remark"].ToString()));
            /*model.Remark = Request.Form["Remark"].ToString();*///会员简介
            string file1= Request.Form["file1"].ToString();//身份证正面
            string file2 = Request.Form["file2"].ToString();//身份证反面
            string file3 = Request.Form["file3"].ToString();//手持身份证
            string file4 = Request.Form["file4"].ToString();//证明图
            string Telba = Request.Form["Telba"].ToString();//你爸电话
            string Telma = Request.Form["Telma"].ToString();//你妈电话
            model.Certification = file1 + file2 + file3 + file4 + Telba + Telma;//认证资料
            bool Intentionality = int.TryParse(Request.Form["Intentionality"], out yu);
            if (Intentionality == true)
            {
                model.IsLogin = Convert.ToInt32(Request.Form["Intentionality"]);//意向度
            }
            bool IsLogin = int.TryParse(Request.Form["IsLogin"], out yu);
            if (IsLogin == true)
            {
                model.IsLogin = Convert.ToInt32(Request.Form["IsLogin"]);//是否登录
            }
            
            //  保存到数据库
            int result = user.IsExitstPhone(model.Tel);
            if (result > 0)
            {
                Response.Write("<script>alert('手机号码已经被占用！请换手机号码!');location.href='/Home/Managers';</script>");
               
            }


            user.Register(model);

            Response.Write("<script>alert('添加用户成功!');location.href='/Home/Managers';</script>");
            return "添加用户成功";
        }




        public ActionResult Login()
        {
            return View();
        }
        private UserManager user = new UserManager();
        private AddressManager address = new AddressManager();
        Users model = new Users();
        [HttpPost]
        public JsonResult Logins(string username, string password)
        {
            string Tel = username;
            string PassWord = Common.MD5(password);
            Session["Tel"] = username;
            model = user.Login(Tel, PassWord);
            if (model != null && model.Tel == Tel && model.PassWord == PassWord)
            {

                return Json(new { status = 1, message = "登陆成功,正在跳转......" });
            }

            return Json(new { status = 0, message = "登陆失败，请检测用户名或密码是否正确" });
        }
        public ActionResult Managers()
        {
            return View();
        }
        public ActionResult Register()
        {
            this.Session.Clear();
            this.Session.Abandon();
            return View();
        }
        #region 验证码
        /// <summary>
        /// 验证码的校验
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            TempData["VerificationCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            var s = File(bytes, @"image/jpeg");
            return s;
        }
        #endregion

        [HttpPost]
        public JsonResult registers(string username, string password, string verifi)
        {



            model.Tel = username;
            model.PassWord = password;
            model.PassWord = Common.MD5(model.PassWord);

            model.verificationcode = verifi;
            string context = Convert.ToString(Session["context" + username]);
            if (verifi != context)
            {
                return Json(new { status = 0, message = "验证码不正确" });
            }
            //  保存到数据库
            int result = user.IsExitstPhone(username);
            if (result > 0)
            {
                return Json(new { status = 1, msg = "手机号码已经被占用！请换手机号码" });
            }


            user.Register(model);

            return Json(new { status = 1, message = "注册成功，请登录" });

        }


        public JsonResult yanzhengma(string username)
        {
            model.Tel = username;
            string context = Common.strRandom();
            Session["context" + username] = context;
            int result = user.IsExitstPhone(username);
            if (result > 0)
            {
                return Json(new { status = 1, msg = "手机号码已经被占用！请换手机号码" });
            }
            return Json(new { msg = context });
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
            ViewBag.add = list;
            
            foreach (var item in list)
            {
                date.Add(item.地区名称);

                items.Add(new SelectListItem()
                {
                    Text = string.Concat("", " ", item.地区名称),
                    Value = item.地区编码.ToString()
                    
                });
                ViewBag.Text = item.地区名称;
                ViewBag.Value = item.地区编码;
                
            }
            //if (!items.Count.Equals(0))
            //{
            //    items.Insert(0, new SelectListItem() { Text = "选择省", Value = "" });
            //}
            
            return Json(items, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region 加载市
        /// <summary>
        /// 加载市
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetCities(string id)
        {
            var city = pss.city(id);
            ViewBag.city = city;
            foreach (var item in city)
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
        [HttpGet]
        public JsonResult Area(string id)
        {
            var list = pss.city(id);
            ViewBag.area = list;
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

        #region 获取区的id

        /// <summary>
        /// 获取区的id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetArea(string id)
        {
            Session["id"] = id;

            return Json(id, JsonRequestBehavior.AllowGet);

        }
        #endregion

        public class TableModel<T>
        {
            public TableModel()
            {
                this.code = 0;
                this.msg = string.Empty;
            }
            public int code { get; set; }
            public string msg { get; set; }
            public int count { get; set; }
            public List<T> data { get; set; }
        }
    }
}