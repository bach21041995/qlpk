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
    class DAO_LOAI_BENHLY
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSLBL()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getLOAI_BENHLY", conn);
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

        public DataTable TimLBL(string tk)
        {
            string t = tk.ToLower();
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("timLOAI_BENHLY", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters["@tk"].Value = t;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            //string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and (lower(THUOC_TEN) like N'%" + tk.ToLower() + "%' or lower(THUOC_ID) like N'%" + tk.ToLower() + "%' or lower(LT_TEN) like N'%" + tk.ToLower() + "%')";
            //return connecDB.ExecuteQuery(query);
        }

        public bool InsertLBL(LOAI_BENHLY t)
        {
            if (KiemTraNhapLieu(t))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("themLOAI_BENHLY", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@LBL_ID", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@LBL_TEN", SqlDbType.NVarChar, 20);
                    
                    cmd.Parameters["@LBL_ID"].Value = t.Id_lbl;
                    cmd.Parameters["@LBL_TEN"].Value = t.Lbl_ten;
                    
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
                    if (KiemTraTrungTenThuoc(t).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do tên loại bệnh lý đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void deleteLBL(string mt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaLOAI_BENHLY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LBL_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@LBL_ID"].Value = mt;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }



        public bool KiemTraNhapLieu(LOAI_BENHLY t)
        {
            if (t.Id_lbl.Equals(""))
            {
                MessageBox.Show("Mã loại bệnh lý không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (t.Lbl_ten.Equals(""))
            {
                MessageBox.Show("Tên loại bệnh lý không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public DataTable KiemTraTrungTenThuoc(LOAI_BENHLY t)
        {
            string query = "select * from LOAI_BENHLY where LBL_TEN = '" + t.Lbl_ten + "'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }

        public bool UpdateLBL(LOAI_BENHLY t)
        {
            if (KiemTraNhapLieu(t))
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("suaLOAI_BENHLY", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@LBL_ID", SqlDbType.NVarChar, 10);
                cmd.Parameters.Add("@LBL_TEN", SqlDbType.NVarChar, 20);

                cmd.Parameters["@LBL_ID"].Value = t.Id_lbl;
                cmd.Parameters["@LBL_TEN"].Value = t.Lbl_ten;

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            return true;
        }
    }
}
