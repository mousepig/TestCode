using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Models.DAL
{
    /// <summary>
    /// 此类维护数据库连接字符串，和 SqlConnection 对象
    /// </summary>
    public class DB
    {



        //连接数据库字符串
        public static string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //  public static string connString = "server=localhost;user id=root;password=sa;database=crm; pooling=true;";

        //数据库连接对象
        private SqlConnection conn = null;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }
        //执行sql语句对象
        private SqlCommand comm = null;



        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void Open()
        {

            try
            {
                //判断conn对象是否为空
                if (conn == null)
                {
                    //创建conn对象
                    conn = new SqlConnection(connString);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                else if (conn.State == ConnectionState.Broken)
                {
                    conn.Close();
                    conn.Open();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("创建SqlConnection失败!");
                throw;
            }
        }


        /// <summary>
        /// 完成增删改操作的方法
        /// </summary>
        /// <param name="sql">增删改sql语句</param>
        /// <returns>增删改影响的行数</returns>
        public int Update(string sql)
        {
            int res = -1;
            Open();
            try
            {
                comm = new SqlCommand(sql, conn);
                res = comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sql);
                throw;
            }
            finally
            {
                Close();
            }
            return res;
        }

        public int QueryCount(string sqlCount)
        {
            int res = 0;
            Open();
            try
            {
                comm = new SqlCommand(sqlCount, conn);
                res =Convert.ToInt32( comm.ExecuteScalar());
            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sqlCount);
                throw;
            }
            finally
            {
                Close();
            }
            return res;
        }

        public object QueryCount(string sqlCount, SqlParameter[] sps)
        {
            object res = 0;
            Open();
            try
            {
                comm = new SqlCommand(sqlCount, conn);
                comm.Parameters.AddRange(sps);
                res = comm.ExecuteScalar();
            }
            catch (Exception)
            {

                Console.WriteLine("执行异常:" + sqlCount);
                throw;
            }
            finally
            {
                Close();
            }
            return res;
        }

        /// <summary>
        public SqlDataReader Query(string sql)
        /// 完成查询
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>SqlDataReader</returns>
        {
            SqlDataReader dr = null;
            Open();
            try
            {

                comm = new SqlCommand(sql, conn);

                dr = comm.ExecuteReader();
            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sql);
                throw;
            }
            return dr;

        }
        /// <summary>
        /// 执行查询 返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet QueryToDataSet(string sql)
        {
            DataSet ds = new DataSet();
            Open();
            try
            {

                //comm = new SqlCommand(sql, conn);
                SqlDataAdapter dr = new SqlDataAdapter(sql, conn);
                dr.Fill(ds);

            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sql);
                throw;
            }
            return ds;

        }


        public SqlDataReader Query(string sql, SqlParameter[] sps)
        {
            SqlDataReader dr = null;
            Open();
            try
            {
                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddRange(sps);
                dr = comm.ExecuteReader();
            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sql);
                throw;
            }
            return dr;

        }

        public DataSet QuerySet(string sql)
        {
            DataSet ds = new DataSet();
            Open();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(ds);
            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sql);
                throw;
            }
            finally
            {
                Close();
            }
            return ds;

        }
        /// <summary>
        /// 对数据库进行增删改 含有参数的方法 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Update(string sql, SqlParameter[] para)
        {
            int res = -1;
            Open();
            try
            {
                comm = new SqlCommand(sql, conn);
                comm.Parameters.AddRange(para);
                res = comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("执行异常:" + sql);
                throw;
            }
            finally
            {
                Close();
            }
            return res;
        }

        public void Close()
        {
            try
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open || conn.State == ConnectionState.Broken)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("关闭数据库连接失败!");
                throw;
            }
        }
    }
}
