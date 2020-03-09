using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Double_selection_systemModel;
using System.Data;
using System.Data.SqlClient;

namespace Double_selection_systemDal
{
     public class TeacherService
    {

        #region 常量变量的定义
        //通过app.config 里的名为sqlserver获取app.config里的链接字符串
        private readonly string connString = ConfigurationManager.ConnectionStrings["SQLSEVER"].ConnectionString;
        #endregion

        #region 检查有没有这个老师
        /// <summary>
        /// 检查有没有这个老师
        /// </summary>
        /// <param name="loginId">老师工号</param>
        /// <returns>true：有这个工号</returns>
        public bool CheckTeacherIsExists(int loginId)
        {
            bool flag = false;
            //创建sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select count(*)");
            sb.AppendLine("from Teacher");
            sb.AppendLine("where id=@loginId");
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",loginId)
            };
            //创建链接对象
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                //创建执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //设置 执行工具的参数
                cmd.Parameters.AddRange(paras);
                //打开链接
                conn.Open();
                //执行
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                //判断
                if (count > 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return flag;
        }

        #endregion

        #region 执行教师登入检查
        /// <summary>
        /// 执行教师登入检查
        /// </summary>
        /// <param name="loginId">用户id</param>
        /// <param name="loginPwd">用户密码</param>
        /// <returns>true：登入成功  flase：反则</returns>
        public bool CheckTeacherLogin(int loginId, string loginPwd)
        {
            bool flag = false;
            //创建sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from Teacher");
            sb.AppendLine("where id=@loginId and pwd=@loginPwd");
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@loginPwd",loginPwd)
            };
            //创建链接对象
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                //创建执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //设置执行工具的参数
                cmd.Parameters.AddRange(paras);
                //打开链接
                conn.Open();
                //执行
                SqlDataReader reader = cmd.ExecuteReader();
                //判断
                if (reader.Read())
                {
                    flag = true;
                }
                reader.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return flag;
            //flag=true 代表登入成功>>reader找得到则flag=true
        }
        #endregion

        #region 根据id获取老师对象
        /// <summary>
        /// 根据id获取老师对象
        /// </summary>
        /// <param name="id">老师id</param>
        /// <returns>返回老师对象</returns>
        public Teacher GetTeacherById(int loginId)
        {
            Teacher tea = null;
            //sql语句
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select * from Teacher");
            sb.AppendLine("where id=@loginId");
            //设置参数
            SqlParameter[] paras =
            {
                new SqlParameter("@loginId",loginId)
            };
            //创建链接对象
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                //创建执行工具
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                //设置执行工具的参数
                cmd.Parameters.AddRange(paras);
                //打开链接
                conn.Open();
                //执行
                SqlDataReader reader = cmd.ExecuteReader();
                //判断
                if (reader.Read())
                {
                    tea = new Teacher();
                    tea.Id = loginId;
                    tea.Pwd = Convert.ToString(reader["pwd"]);
                    tea.Name = Convert.ToString(reader["name"]);
                    tea.Age = Convert.ToInt32(reader["age"]);
                    tea.TeachYear = Convert.ToInt32(reader["teachYear"]);
                    tea.GradeId = Convert.ToInt32(reader["gradeId"]);
                    tea.Title = Convert.ToString(reader["title"]);
                    tea.Introduction = Convert.ToString(reader["introduction"]);
                }
                reader.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return tea;
        }
        #endregion


    }
}
