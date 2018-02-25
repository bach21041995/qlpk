using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DAO
{
    class ConnectionDatabase
    {
        public string connectionStr = @"Data Source=JAEJIN-PC\SQLEXPRESS;Initial Catalog=qlpk10;Integrated Security=True";


        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            SqlConnection con = new SqlConnection(connectionStr);
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            DataTable dt = new DataTable();

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains("@"))
                    {
                        com.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(com);
            da.Fill(dt);
            con.Close();

            return dt;
        }


        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            SqlConnection con = new SqlConnection(connectionStr);
            con.Open();
            SqlCommand com = new SqlCommand(query, con);

            if (parameter != null)
            {
                string[] listPara = query.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains("@"))
                    {
                        com.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            data = com.ExecuteNonQuery();
            con.Close();
            return data;
        }

        public object ExecuteScalar(string sql, object[] parameter = null)
        {
            object data = 0;
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand com = new SqlCommand(sql, connection);

            if (parameter != null)
            {
                string[] listPara = sql.Split(' ');
                int i = 0;
                foreach (string item in listPara)
                {
                    if (item.Contains('@'))
                    {
                        com.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            data = com.ExecuteScalar();

            connection.Close();
            return data;
        }
    }
}
