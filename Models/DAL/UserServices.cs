using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using System.Data.SqlClient;
using System.Text;
using Models.DAL;

namespace WebApplication1.Models.DAL
{
    public class UserServices
    {
        Users Order = new Users();
        private DB db = new DB();
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public Users Login(string Tel, string PassWord)
        {
            //创建Sql语句
          StringBuilder sb = new StringBuilder();
          sb.AppendLine(" select * from  Users  where Tel=@Tel and PassWord=@PassWord");
          SqlParameter[] para = new SqlParameter[] {new SqlParameter ("@Tel",Tel),
                                                    new SqlParameter ("@PassWord",PassWord)};
            try
            {
                // 执行查询语句
                SqlDataReader reader = db.Query(sb.ToString(), para);
                //如果检索到则返回true，否则返回false

                if (reader.Read())
                {
                    Users user = new Users();
                    user.Tel = Convert.ToString(reader["Tel"]);
                    user.UserName = Convert.ToString(reader["UserName"]);
                    user.PassWord = Convert.ToString(reader["PassWord"]);
                    return user;
                }
                else
                {
                    reader.Close();
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
            return null;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Register(Users user)
        {
           string sql = string.Format("INSERT INTO Users values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}')",  user.Tel,user.UserName,user.PassWord,user.verificationcode,user.Gender,user.Addr1,user.Addr2,user.Addr3,user.Address,user.Age,user.Email,user.Touxiang,user.Idcard,user.SellerId,user.Likes,user.Intentionality,user.Nickname,user.QQ,user.WeChat,user.DateBirth,user.Keyword,user.Level,user.Education,user.Certification,user.IsLogin,user.status,user.AddTime,user.Remark);
           
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
        /// 判断手机号是否存在(userId)
        /// </summary>
        /// <param name="handphone"></param>
        /// <returns></returns>
        public int IsExitstPhone(string handphone)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" select count(*) from  Users  where Tel=" + handphone + " ");
            try
            {
                // 执行查询语句
                int reader = db.QueryCount(sb.ToString());
                //如果检索到则返回true，否则返回false
                return reader;
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
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        public List<Users> UserList()
        {
            List<Users> ulist = new List<Users>();
            try
            {
                string sql = string.Format(" select UserId,UserName,Gender,Addr1,Addr2,Addr3,Idcard,Likes from  Users");

                SqlDataReader reader = db.Query(sql);
                while (reader.Read())
                {
                    ulist.Add(new Users
                    {
                        UserId = Convert.ToInt32(reader[0].ToString()),
                        UserName = reader[1].ToString(),
                        Gender = Convert.ToInt32(reader[2].ToString()),
                        Addr1 = Convert.ToInt32(reader[3].ToString()),
                        Addr2 = Convert.ToInt32(reader[4].ToString()),
                        Addr3 = Convert.ToInt32(reader[5].ToString()),
                        Idcard = reader[6].ToString(),
                        Likes = reader[7].ToString(),
                       
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

            return ulist;
        }

        //public List<Users> ListUserId(string UserId)
        //{
        //    List<Users> ulist = new List<Users>();
        //    try
        //    {
        //        string sql = string.Format(" select Addr1,Addr2,Addr3 from  Users where UserId=" + UserId + "");

        //        SqlDataReader reader = db.Query(sql);
        //        while (reader.Read())
        //        {
        //            ulist.Add(new Users
        //            {
        //                //UserId = Convert.ToInt32(reader[0].ToString()),
                       
        //                Addr1 = Convert.ToInt32(reader[0].ToString()),
        //                Addr2 = Convert.ToInt32(reader[1].ToString()),
        //                Addr3 = Convert.ToInt32(reader[2].ToString()),
                       

        //            });

        //        }

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

        //    return ulist;
        //}
    }
}