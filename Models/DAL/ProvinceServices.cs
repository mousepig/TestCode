using Models.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication1.Models.DAL
{
    public class ProvinceServices
    {
        private DB db = new DB();
        List<全国行政区划代码表> plist = new List<全国行政区划代码表>();
        /// <summary>
        /// 查询省
        /// </summary>
        /// <returns></returns>
        public List<全国行政区划代码表>  GetProvinces()
        {
              
        StringBuilder sb = new StringBuilder();
           // sb.AppendLine(" select * from  dbo.全国行政区划代码表  where 上级编码=0 ");
            string sql = string.Format(" select * from  dbo.全国行政区划代码表  where 上级编码=0 and len(地区编码)=2");
            try
            {
                // 执行查询语句
                //如果检索到则返回true，否则返回false
                SqlDataReader reader = db.Query(sql);
                while (reader.Read())
                {
                    plist.Add(new 全国行政区划代码表
                    {

                        地区编码 = reader[0].ToString(),
                        上级编码 = reader[1].ToString(),
                        地区名称 = reader[2].ToString(),
                        地区级别 = reader[3].ToString(),
                        是否末级 = reader[4].ToString(),
                    });
                }

                //if (reader.Read())
                //{
                //    全国行政区划代码表 list = new 全国行政区划代码表();
                //    list.地区编码 = Convert.ToString(reader["地区编码"]);
                //    list.上级编码 = Convert.ToString(reader["上级编码"]);
                //    list.地区名称 = Convert.ToString(reader["地区名称"]);
                //    list.地区级别 = Convert.ToString(reader["地区级别"]);
                //    list.是否末级 = Convert.ToString(reader["是否末级"]);
                //    return list;
                //}
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

            return plist;
        }
        public List<全国行政区划代码表> city(string Id)
        {
            //创建Sql语句
            StringBuilder sb = new StringBuilder();
            if (Id.Length == 2)
            {
                sb.AppendLine(" select * from  dbo.全国行政区划代码表  where 上级编码=@provinceId and len(地区编码)=4  ");
            }
            if (Id.Length==4)
            {
                sb.AppendLine(" select * from  dbo.全国行政区划代码表  where 上级编码=@provinceId and len(地区编码)=6  ");
            }
                SqlParameter[] para = new SqlParameter[] {new SqlParameter ("@provinceId",Id),
                                                  };
            try
            {
                // 执行查询语句
                SqlDataReader reader = db.Query(sb.ToString(), para);
                //如果检索到则返回true，否则返回false

                while (reader.Read())
                {
                    plist.Add(new 全国行政区划代码表
                    {

                        地区编码 = reader[0].ToString(),
                        上级编码 = reader[1].ToString(),
                        地区名称 = reader[2].ToString(),
                        地区级别 = reader[3].ToString(),
                        是否末级 = reader[4].ToString(),
                    });
                }
              
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //关闭数据库连接
                db.Close();
            }
            return plist;
        }

    }
}