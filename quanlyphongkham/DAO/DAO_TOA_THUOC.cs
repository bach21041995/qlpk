using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_TOA_THUOC
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public bool InsertTT(TOA_THUOC t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("themTOA_THUOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@TT_TEN", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@TT_LOIDAN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TT_TRANGTHAI", SqlDbType.Int);
            cmd.Parameters["@KB_ID"].Value = t.Id_kb;
            cmd.Parameters["@TT_TEN"].Value = t.Tt_ten;
            cmd.Parameters["@TT_LOIDAN"].Value = t.Tt_loidan;
            cmd.Parameters["@TT_TRANGTHAI"].Value = t.Tt_trangthai;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public int getIDTT_MAX()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getIDTT_MAX", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@last", SqlDbType.Int);
            cmd.Parameters["@last"].Direction = ParameterDirection.Output;
            cmd.Parameters["@last"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            int ma = int.Parse(cmd.Parameters["@last"].Value.ToString());
            conn.Close();

            return ma;
        }

        public DataTable getTTbyBN(int idbn)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getTTbyBN", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BN_ID", SqlDbType.Int).Value = idbn;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
