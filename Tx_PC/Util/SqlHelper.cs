using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Util
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public partial class SqlHelper
    {
        /// <summary>
        /// 配置字符串
        /// </summary>
        /// <param name="config"></param>
        public SqlHelper(string config)
        {
            var a = ConfigurationManager.AppSettings[config];
            this.connstr = a;
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string connstr;
        /// <summary>
        /// 连接字符串
        /// </summary>
        //internal static readonly string connstr =
        //   System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).AppSettings.Settings["connectionstring"].Value;
        /// <summary>
        /// 调试模式
        /// </summary>
        //internal static readonly string connstr =
        //    "Data Source=192.168.0.138;Initial Catalog=lx_dev;Persist Security Info=True;User ID=sa;Password=password@55950784";
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns>返回数据库连接对象</returns>
        private SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.Open();
            return conn;
        }
        /// <summary>
        /// 执行SQL语句并返回受影响行数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>返回受影响行数</returns>
        public int ExecuteNonQuery(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteNonQuery(conn, cmdText, parameters);
            }
        }
        public bool Execute(string cmdText, params SqlParameter[] parameters)
        {
            return Convert.ToInt32(ExecuteNonQuery(cmdText, parameters)) > 0;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        public bool Insert(string tableName, object obj)
        {
            if (obj is List<Tuple<string, object>>)
            {
                var tArr = obj as List<Tuple<string, object>>;
                List<SqlParameter> pArr = new List<SqlParameter>();
                List<string> fArr = new List<string>();
                List<string> vArr = new List<string>();
                tArr.ForEach((tuple) =>
                {
                    var fItem = tuple.Item1.Replace("To", "[To]");
                    pArr.Add(new SqlParameter("@" + tuple.Item1, tuple.Item2));
                    fArr.Add(fItem);
                    vArr.Add("@" + tuple.Item1);
                });
                var sql = string.Format("insert into {0} ({1}) values({2})", tableName, string.Join(",", fArr), string.Join(",", vArr));
                return Execute(sql, pArr.ToArray());
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 简单判断数据是否存在
        /// </summary>
        public bool IsContain(string cmdText)
        {
            return Convert.ToInt32(ExecuteScalar(string.Format("select count(*) from {0}", cmdText))) > 0;
        }
        /// <summary>
        /// 简易分页
        /// </summary>
        /// <returns></returns>
        public DataTable EasyPager(string table, string orderBy, string filter, int limit, int cur, out int count)
        {
            var sqlCount = String.Format("select count(*) from {0} where {1}",
                    table,
                    string.IsNullOrEmpty(filter) ? "1=1" : filter);
            var sqlData = String.Format(@"select * from (select *,ROW_NUMBER()Over({1}) As Page_Row_Number from 
                                         (select * from {0} as a) as b
                                          where {2}) as c where Page_Row_Number BETWEEN {3} and {4}",
                    table,
                    orderBy,
                    string.IsNullOrEmpty(filter) ? "1=1" : filter,
                    limit * (cur - 1) + 1,
                    limit * cur);
            count = Convert.ToInt32(ExecuteScalar(sqlCount));
            return ExecuteDataTable(sqlData);
        }
        /// <summary>
        /// 返回查询结果中的第一行第一列
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>返回首行首列</returns>
        public object ExecuteScalar(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteScalar(conn, cmdText, parameters);
            }
        }
        /// <summary>
        /// 返回一个数据表
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>数据表</returns>
        public DataTable ExecuteDataTable(string cmdText,
            params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return ExecuteDataTable(conn, cmdText, parameters);
            }
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>数据表</returns>
        public DataTable GetProcedure(string cmdText, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                return GetProcedure(conn, cmdText, parameters);
            }
        }
        #region 具体执行
        private int ExecuteNonQuery(SqlConnection conn, string cmdText, params SqlParameter[] paramters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(paramters);
                return cmd.ExecuteNonQuery();
            }
        }
        private object ExecuteScalar(SqlConnection conn, string cmdText, params SqlParameter[] paramters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(paramters);
                return cmd.ExecuteScalar();
            }
        }
        private DataTable ExecuteDataTable(SqlConnection conn, string cmdText, params SqlParameter[] paramaters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.Parameters.AddRange(paramaters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        private DataTable GetProcedure(SqlConnection conn, string cmdText, params SqlParameter[] paramters)
        {
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paramters);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        #endregion
    }
}