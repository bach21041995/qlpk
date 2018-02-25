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
    class DAO_BENH_LY
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getBL()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getDM_BENHLY", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            //string query = " select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID order by THUOC_ID";
            //return connecDB.ExecuteQuery(query);
        }

        public string TimBL(string tk)
        {
            
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("TimBL", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@tenbl", SqlDbType.NVarChar, 50);
            cmd.Parameters["@tenbl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@tk"].Value = tk;
            cmd.Parameters["@tenbl"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string bl = cmd.Parameters["@tenbl"].Value.ToString();
            conn.Close();
            return bl;
        }

        public string TimIDBL(string tk)
        {

            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("TimIDBL", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@idbl", SqlDbType.NVarChar, 50);
            cmd.Parameters["@idbl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@tk"].Value = tk;
            cmd.Parameters["@idbl"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string bl = cmd.Parameters["@idbl"].Value.ToString();
            conn.Close();
            return bl;
        }

        
    }
}
