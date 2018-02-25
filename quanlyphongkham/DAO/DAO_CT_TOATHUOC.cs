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
    class DAO_CT_TOATHUOC
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();
        public bool InsertCTTT(CT_TOATHUOC t)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("themCT_TOATHUOC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@TT_ID", SqlDbType.Int);
                cmd.Parameters.Add("@THUOC_ID", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@CTT_SONGAYUONG", SqlDbType.Int);
                cmd.Parameters.Add("@CTT_CACHDUNG", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@CTT_SANG", SqlDbType.Int);
                cmd.Parameters.Add("@CTT_TRUA", SqlDbType.Int);
                cmd.Parameters.Add("@CTT_CHIEU", SqlDbType.Int);
                cmd.Parameters.Add("@CTT_TOI", SqlDbType.Int);
                cmd.Parameters.Add("@CTT_SOLUONG", SqlDbType.Int);
                cmd.Parameters.Add("@CTT_DONGIA", SqlDbType.Float);
                cmd.Parameters.Add("@CTT_THANHTIEN", SqlDbType.Float);
                cmd.Parameters["@TT_ID"].Value = t.Id_tt;
                cmd.Parameters["@THUOC_ID"].Value = t.Id_thuoc;
                cmd.Parameters["@CTT_SONGAYUONG"].Value = t.Ctt_songayuong;
                cmd.Parameters["@CTT_CACHDUNG"].Value = t.Ctt_cachdung;
                cmd.Parameters["@CTT_SANG"].Value = t.Ctt_sang;
                cmd.Parameters["@CTT_TRUA"].Value = t.Ctt_trua;
                cmd.Parameters["@CTT_CHIEU"].Value = t.Ctt_chieu;
                cmd.Parameters["@CTT_TOI"].Value = t.Ctt_toi;
                cmd.Parameters["@CTT_SOLUONG"].Value = t.Ctt_sl;
                cmd.Parameters["@CTT_DONGIA"].Value = t.Ctt_dongia;
                cmd.Parameters["@CTT_THANHTIEN"].Value = t.Ctt_thanhtien;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }

        public DataTable getCT_TOATHUOCbyID(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getCT_TOATHUOCbyID", conn);
            DataTable dt = new DataTable();
            int id = int.Parse(tk);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idtt", SqlDbType.Int);
            cmd.Parameters["@idtt"].Value = id;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }


        public void xoaCT_TOATHUOC(string mt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaCT_TOATHUOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@THUOC_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@THUOC_ID"].Value = mt;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }
    }
}
