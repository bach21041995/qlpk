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
    class DAO_NGAY
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        //public string getNGAY()
        //{
          //  string s = "asdasd/khhaaa";
            //s.Replace("/", "");
            
        //}

        public bool InsertNGAY(NGAY t)
        {
            if (KiemTraNhapLieu(t))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("themNGAY", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@NGAY_ID", SqlDbType.VarChar, 8);
                    cmd.Parameters.Add("@NGAY", SqlDbType.Date);
                    

                    cmd.Parameters["@NGAY_ID"].Value = t.Id_ngay;
                    cmd.Parameters["@NGAY"].Value = t.Ngay;

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;


                    /*string query = string.Format("Insert DM_THUOC (THUOC_ID, LT_ID, THUOC_TEN, THUOC_HDSD, THUOC_DVT, THUOC_CONGDUNG, THUOC_GIA, THUOC_TRANGTHAI) values ('{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}')",
                                    t.Id_thuoc, t.Id_lt, t.Thuoc_ten, t.Thuoc_hdsd, t.Thuoc_dvt, t.Thuoc_congdung, t.Thuoc_gia, t.Thuoc_trangthai);
                    int result = connecDB.ExecuteNonQuery(query);
                    return result > 0;*/
                }
                catch
                {
                    if (KiemTraTrung(t).Rows.Count == 0)
                    {
                        //MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        //MessageBox.Show("Thêm không thành công do số CMND hoặc SDT đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    /*if(KiemTraTrungSDT(nv).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do Số điện thoại của giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
            }
            return false;
        }

        public bool KiemTraNhapLieu(NGAY t)
        {
            if (t.Ngay.Equals(""))
            {
                MessageBox.Show("Ngày không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            return true;
        }

        public DataTable KiemTraTrung(NGAY t)
        {
            string query = "select * from NGAY where NGAY_ID = '" + t.Id_ngay + "'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }
    }

    
}
