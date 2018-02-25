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
    class DAO_CT_BENHLY
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public bool InsertCTBL(CT_BENHLY t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("themCT_BENHLY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            
            cmd.Parameters.Add("@BL_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);

            cmd.Parameters.Add("@CTBL_CHUYENMON", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CTBL_MUCDO", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@CTBL_TRANGTHAI", SqlDbType.Int);

            
            cmd.Parameters["@BL_ID"].Value = t.Id_bl;
            cmd.Parameters["@KB_ID"].Value = t.Id_kb;

            cmd.Parameters["@CTBL_CHUYENMON"].Value = t.Ctbl_chuyenmon;
            cmd.Parameters["@CTBL_MUCDO"].Value = t.Ctbl_mucdo;
            cmd.Parameters["@CTBL_TRANGTHAI"].Value = t.Ctbl_trangthai;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public bool UpdateCTBL(CT_BENHLY t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("suaCT_BENHLY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;

            cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@BL_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CTBL_CHUYENMON", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@CTBL_MUCDO", SqlDbType.NVarChar, 10);


            cmd.Parameters["@KB_ID"].Value = t.Id_kb;
            cmd.Parameters["@BL_ID"].Value = t.Id_bl;
            cmd.Parameters["@CTBL_CHUYENMON"].Value = t.Ctbl_chuyenmon;
            cmd.Parameters["@CTBL_MUCDO"].Value = t.Ctbl_mucdo;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public void deleteCTBL(CT_BENHLY t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaCT_BENHLY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@BL_ID", SqlDbType.NVarChar, 20);

            cmd.Parameters["@KB_ID"].Value = t.Id_kb;
            cmd.Parameters["@BL_ID"].Value = t.Id_bl;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }
    }
}
