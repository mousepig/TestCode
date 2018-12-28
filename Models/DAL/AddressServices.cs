using Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.Models.DAL
{
    public class AddressServices
    {
        全国行政区划代码表 address = new 全国行政区划代码表();
        private DB db = new DB();
        /// <summary>
        /// 根据地区编码查地区名称
        /// </summary>
        /// <param name="addr3"></param>
        /// <returns></returns>
        public List<全国行政区划代码表>  Checks(string addr3)
        {
            List<全国行政区划代码表> alist = new List<全国行政区划代码表>();
            //创建Sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select 地区编码,地区名称 from dbo.全国行政区划代码表 where 地区编码=@地区编码");
            SqlParameter[] para = new SqlParameter[] {new SqlParameter ("@地区编码", addr3),};
            try
            {
                // 执行查询语句
                SqlDataReader reader = db.Query(sb.ToString(), para);



                while (reader.Read())
                {
                    alist.Add(new 全国行政区划代码表
                    {
                        地区编码 = reader[0].ToString(),
                       地区名称 = reader[1].ToString(),

                    });

                }

                reader.Close();
            }
            
            catch (Exception)
            {

                throw;

            }
            finally
            {
                db.Close();
            }

            return alist;
        }
    }
}