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
    class DAO_DM_CANLAMSAN
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSCLS()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getDM_CANLAMSAN", conn);
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

        public DataTable TimCLS(string tk)
        {
            string t = tk.ToLower();
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("timDM_CANLAMSAN", conn);
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

        public bool InsertCLS(DM_CANLAMSAN t)
        {
            if (KiemTraNhapLieu(t))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("themDM_CANLAMSAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@CLS_ID", SqlDbType.NVarChar, 5);
                    cmd.Parameters.Add("@CLS_TEN", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@CLS_MOTA", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@CLS_DONGIA", SqlDbType.Float);


                    cmd.Parameters["@CLS_ID"].Value = t.Id_cls;
                    cmd.Parameters["@CLS_TEN"].Value = t.Cls_ten;
                    cmd.Parameters["@CLS_MOTA"].Value = t.Cls_mota;
                    cmd.Parameters["@CLS_DONGIA"].Value = t.Cls_dongia;
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

        public void deleteCLS(string mt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaDM_CANLAMSAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CLS_ID", SqlDbType.NVarChar, 5);
            cmd.Parameters["@CLS_ID"].Value = mt;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }



        public bool KiemTraNhapLieu(DM_CANLAMSAN t)
        {
            if (t.Id_cls.Equals(""))
            {
                MessageBox.Show("Mã cận lâm sàn không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (t.Cls_ten.Equals(""))
            {
                MessageBox.Show("Tên cận lâm sàn không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public DataTable KiemTraTrungTenThuoc(DM_CANLAMSAN t)
        {
            string query = "select * from DM_CANLAMSAN where CLS_TEN = '" + t.Cls_ten + "'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }

        public bool UpdateCLS(DM_CANLAMSAN t)
        {
            if (KiemTraNhapLieu(t))
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("suaDM_CANLAMSAN", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@CLS_ID", SqlDbType.NVarChar, 5);
                cmd.Parameters.Add("@CLS_TEN", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@CLS_MOTA", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@CLS_DONGIA", SqlDbType.Float);


                cmd.Parameters["@CLS_ID"].Value = t.Id_cls;
                cmd.Parameters["@CLS_TEN"].Value = t.Cls_ten;
                cmd.Parameters["@CLS_MOTA"].Value = t.Cls_mota;
                cmd.Parameters["@CLS_DONGIA"].Value = t.Cls_dongia;

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            return true;
        }
    }
}
