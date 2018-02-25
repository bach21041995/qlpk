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
    class DAO_DANG_NHAP
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();
        public DataTable getTK_MK(string tk, string mk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getTK_MK", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@mk", SqlDbType.NVarChar, 30);
            cmd.Parameters["@tk"].Value = tk;
            cmd.Parameters["@mk"].Value = mk;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }


        public bool checkLogin(string user, string password)
        {
            bool b = true;
            if (user.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                b = false;
            }
            else if (password.Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                b = false;
            }

            return b;
        }
    }
}
