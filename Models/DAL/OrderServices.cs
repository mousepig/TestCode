using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Data.SqlClient;
using System.Text;

namespace Models.DAL
{
    public class OrderServices
    {
        Order Order = new Order();
        private DB db = new DB();
        //添加数据                                                                                                                                                                                                                                                                                     
        public int add(Order order)
        {
            string sql = string.Format("INSERT INTO Orders values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", order.orderno, order.name,order.tel, order.total, order.is_pay,order.remark,order.caeated_at);
            SqlConnection conn = new SqlConnection(DB.connString);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                return comm.ExecuteNonQuery();
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
                conn.Close();
            }
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        //public List<Order> Query(Order order)
        //{
        //     List<Order> olist = new List<Order>();
        //    try
        //    {
        //        string sql = string.Format("select datename(year,DATEADD(S,caeated_at + 8 * 3600,'1970-01-01 00:00:00'))+'年'+datename(month, DATEADD(S,caeated_at + 8 * 3600,'1970-01-01 00:00:00'))+'月'as 年月 ,sum(1) as 统计 from Orders group by datename(year, DATEADD(S, caeated_at + 8 * 3600, '1970-01-01 00:00:00')) + '年' + datename(month, DATEADD(S, caeated_at + 8 * 3600, '1970-01-01 00:00:00')) + '月'");

        //        //  string sql = string.Format("select * from Orders");



        //        SqlDataReader reader = db.Query(sql);
        //        while (reader.Read())
        //        {
        //            olist.Add(new Order
        //            {

        //               // caeated_at = reader[0].ToString(),
        //                orderno = reader[0].ToString(),
        //                name = reader[1].ToString(),
        //                //  string caeated_at = reader[0].ToString();
        //                // string sun = reader[1].ToString(),
        //            });
        //            //string caeated_at = reader[0].ToString();
        //            // string sun = reader[1].ToString();

        //            //olist.Add(new Order
        //            //{
        //            //    orderno = reader[0].ToString(),
        //            //    name = reader[1].ToString(),
        //            //    tel = reader[2].ToString(),
        //            //    total =Convert.ToDecimal( reader[3].ToString()),
        //            //    is_pay =Convert.ToInt32( reader[4].ToString()),
        //            //    remark= reader[5].ToString(),
        //            //    caeated_at =Convert.ToInt32( reader[6].ToString()),

        //            //});
        //        }
        //        //while (reader.Read())
        //        //{

        //        //   order.orderno = Convert.ToString(reader["orderno"]);

        //        //    order.caeated_at = Convert.ToInt32(reader["caeated_at"]);

        //        //   // order.caeated_at = 123223;

        //        //    olist.Add(Order);

        //        //}
        //        reader.Close();
        //    }
        //    catch (Exception)
        //    {

        //        throw;

        //    }
        //    finally
        //    {
        //        db.Close();
        //    }

        //    return olist;
        //}
        public List<Order> Query()
        {
            List<Order> olist = new List<Order>();
            try
            {
                string sql = string.Format("select datename(year,DATEADD(S,caeated_at + 8 * 3600,'1970-01-01 00:00:00'))+'年'+datename(month, DATEADD(S,caeated_at + 8 * 3600,'1970-01-01 00:00:00'))+'月'as 年月 ,sum(1) as 统计 from Orders group by datename(year, DATEADD(S, caeated_at + 8 * 3600, '1970-01-01 00:00:00')) + '年' + datename(month, DATEADD(S, caeated_at + 8 * 3600, '1970-01-01 00:00:00')) + '月' order by datename(year, DATEADD(S,caeated_at + 8 * 3600,'1970-01-01 00:00:00'))+'年'+datename(month, DATEADD(S,caeated_at + 8 * 3600,'1970-01-01 00:00:00'))+'月' asc");

                //  string sql = string.Format("select * from Orders");



                SqlDataReader reader = db.Query(sql);
                while (reader.Read())
                {
                    olist.Add(new Order
                    {

                        // caeated_at = reader[0].ToString(),
                        orderno = reader[0].ToString(),
                        name = reader[1].ToString(),
                        //  string caeated_at = reader[0].ToString();
                        // string sun = reader[1].ToString(),
                    });
                    //string caeated_at = reader[0].ToString();
                    // string sun = reader[1].ToString();

                    //olist.Add(new Order
                    //{
                    //    orderno = reader[0].ToString(),
                    //    name = reader[1].ToString(),
                    //    tel = reader[2].ToString(),
                    //    total =Convert.ToDecimal( reader[3].ToString()),
                    //    is_pay =Convert.ToInt32( reader[4].ToString()),
                    //    remark= reader[5].ToString(),
                    //    caeated_at =Convert.ToInt32( reader[6].ToString()),

                    //});
                }
                //while (reader.Read())
                //{

                //   order.orderno = Convert.ToString(reader["orderno"]);

                //    order.caeated_at = Convert.ToInt32(reader["caeated_at"]);

                //   // order.caeated_at = 123223;

                //    olist.Add(Order);

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

            return olist;
        }


    }
}