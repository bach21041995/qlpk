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
    class DAO_BENH_NHAN
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSBN()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getBENH_NHAN", conn);
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

        public bool InsertBN(BENH_NHAN t)
        {
            //if (KiemTraNhapLieu(t))
            //{
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("themBENH_NHAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@BN_HOTEN", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@BN_CMT", SqlDbType.NVarChar, 12);
                    cmd.Parameters.Add("@BN_SDT", SqlDbType.NVarChar, 11);
                    cmd.Parameters.Add("@BN_DIACHI", SqlDbType.NVarChar, 40);
                    cmd.Parameters.Add("@BN_NGAYSINH", SqlDbType.Date);
                    cmd.Parameters.Add("@BN_GIOITINH", SqlDbType.Int);
                    cmd.Parameters.Add("@BN_NHOMMAU", SqlDbType.NVarChar, 2);
                    cmd.Parameters.Add("@BN_TRANGTHAI", SqlDbType.Int);

                    cmd.Parameters["@BN_HOTEN"].Value = t.Hoten;
                    cmd.Parameters["@BN_CMT"].Value = t.Cmt;
                    cmd.Parameters["@BN_SDT"].Value = t.Sdt;
                    cmd.Parameters["@BN_DIACHI"].Value = t.Diachi;
                    cmd.Parameters["@BN_NGAYSINH"].Value = t.Ngaysinh;
                    cmd.Parameters["@BN_GIOITINH"].Value = t.Gioitinh;
                    cmd.Parameters["@BN_NHOMMAU"].Value = t.Nhommau;
                    cmd.Parameters["@BN_TRANGTHAI"].Value = t.Trangthai;

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;


                    /*string query = string.Format("Insert DM_THUOC (THUOC_ID, LT_ID, THUOC_TEN, THUOC_HDSD, THUOC_DVT, THUOC_CONGDUNG, THUOC_GIA, THUOC_TRANGTHAI) values ('{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}')",
                                    t.Id_thuoc, t.Id_lt, t.Thuoc_ten, t.Thuoc_hdsd, t.Thuoc_dvt, t.Thuoc_congdung, t.Thuoc_gia, t.Thuoc_trangthai);
                    int result = connecDB.ExecuteNonQuery(query);
                    return result > 0;*/
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                    return false;
                    //if (KiemTraTrung(t).Rows.Count == 0)
                    //{
                    //    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm không thành công do số CMND hoặc SDT đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    ///*if(KiemTraTrungSDT(nv).Rows.Count == 0)
                    //{
                    //    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm không thành công do Số điện thoại của giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}*/
                }
            //}
            //return false;

            
        }


        public bool UpdateBN(BENH_NHAN t)
        {
            if (KiemTraNhapLieu(t))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("suaBENH_NHAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@BN_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@BN_HOTEN", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@BN_CMT", SqlDbType.NVarChar, 12);
                    cmd.Parameters.Add("@BN_SDT", SqlDbType.NVarChar, 11);
                    cmd.Parameters.Add("@BN_DIACHI", SqlDbType.NVarChar, 40);
                    cmd.Parameters.Add("@BN_NGAYSINH", SqlDbType.Date);
                    cmd.Parameters.Add("@BN_GIOITINH", SqlDbType.Int);
                    cmd.Parameters.Add("@BN_NHOMMAU", SqlDbType.NVarChar, 2);
                    cmd.Parameters.Add("@BN_TRANGTHAI", SqlDbType.Int);

                    cmd.Parameters["@BN_ID"].Value = t.Id_bn;
                    cmd.Parameters["@BN_HOTEN"].Value = t.Hoten;
                    cmd.Parameters["@BN_CMT"].Value = t.Cmt;
                    cmd.Parameters["@BN_SDT"].Value = t.Sdt;
                    cmd.Parameters["@BN_DIACHI"].Value = t.Diachi;
                    cmd.Parameters["@BN_NGAYSINH"].Value = t.Ngaysinh;
                    cmd.Parameters["@BN_GIOITINH"].Value = t.Gioitinh;
                    cmd.Parameters["@BN_NHOMMAU"].Value = t.Nhommau;
                    cmd.Parameters["@BN_TRANGTHAI"].Value = t.Trangthai;

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
                    //if (KiemTraTrung(t).Rows.Count == 0)
                    //{
                    //    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                    //else
                    //{
                    //    MessageBox.Show("Cập nhật không thành công do số CMND hoặc SDT đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    ///*if(KiemTraTrungSDT(nv).Rows.Count == 0)
                    //{
                    //    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Thêm không thành công do Số điện thoại của giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}*/
                }
            }
            return false;
        }


        public bool KiemTraNhapLieu(BENH_NHAN t)
        {
            if (t.Hoten.Equals(""))
            {
                MessageBox.Show("Tên bệnh nhân không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if(t.Cmt.Equals(""))
            {
                MessageBox.Show("CMT của bệnh nhân không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (t.Sdt.Equals(""))
            {
                MessageBox.Show("Số điện thoại của bệnh nhân không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        public DataTable KiemTraTrung(BENH_NHAN t)
        {
            string query = "select * from BENH_NHAN where (BN_CMT = '" + t.Cmt + "' or BN_SDT = '" + t.Sdt + "') and BN_TRANGTHAI = '1'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }

        public string getIDBN_max()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getIDBN_MAX", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@last", SqlDbType.Int);
            //cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar, 20);
            cmd.Parameters["@last"].Direction = ParameterDirection.Output;
            //cmd.Parameters["@malt"].Value = malt;
            //cmd.Parameters["@ma_next"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string mabn = cmd.Parameters["@last"].Value.ToString();
            conn.Close();

            return mabn;
        }
    }
}
