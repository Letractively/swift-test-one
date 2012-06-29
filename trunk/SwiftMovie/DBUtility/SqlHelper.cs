using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DBUtility
{
    public class SqlHelper
    {
        static void prepareCmd(ref SqlCommand sqlcmd, string cmdText, CommandType ct, SqlParameter[] sqlparas)
        {
            sqlcmd.CommandText = cmdText;
            sqlcmd.CommandType = ct;
            if (sqlparas != null)
            {
                sqlcmd.Parameters.AddRange(sqlparas);
            }
        }
        public static SqlDataReader executeReader(string cmdText, CommandType ct, params SqlParameter[] sqlparas)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SummerMovieConnection"].ConnectionString;
            SqlConnection sqlcn = new SqlConnection(connStr);
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcn;
            prepareCmd(ref sqlcmd, cmdText, ct, sqlparas);
            sqlcn.Open();
            SqlDataReader sqldr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
            return sqldr;
        }
        public static int executeNonQuery(string cmdText, CommandType ct, params SqlParameter[] sqlparas)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SummerMovieConnection"].ConnectionString;
            using (SqlConnection sqlcn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcn;
                prepareCmd(ref sqlcmd, cmdText, ct, sqlparas);
                sqlcn.Open();
                int effectRowCount = sqlcmd.ExecuteNonQuery();
                sqlcn.Close();
                return effectRowCount;
            }
        }
        public static DataTable executeTable(string cmdText, CommandType ct, params SqlParameter[] sqlparas)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SummerMovieConnection"].ConnectionString;
            using (SqlConnection sqlcn = new SqlConnection(connStr))
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlcn;
                prepareCmd(ref sqlcmd, cmdText, ct, sqlparas);
                SqlDataAdapter sqlada = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                sqlcn.Open();
                sqlada.Fill(dt);
                sqlcn.Close();
                return dt;
            }
        }

    }
}
