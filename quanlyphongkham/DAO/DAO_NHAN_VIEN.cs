using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Data;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_NHAN_VIEN
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSNhanVien()
        {
            string query = " select NV_ID, NV_HOTEN, (CASE NV_GIOITINH when '1' then N'Nam' else N'Nữ' end) as NV_GIOITINH, NV_NGAYSINH, NV_CMT, NV_SDT, NV_DIACHI, CD_TEN, CV_TEN"
                            + " from NHAN_VIEN a, CHUC_DANH b, CHUC_VU c where a.CD_ID = b.CD_ID and a.CV_ID = c.CV_ID order by NV_ID";
            return connecDB.ExecuteQuery(query);
        }

        public DataTable getDSBS()
        {
            string query = "select NV_ID, NV_HOTEN from NHAN_VIEN where CV_ID = 'BS'";
            return connecDB.ExecuteQuery(query);
        }

        public DataTable TimNV(string nv)
        {
            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            string query = "select NV_ID, NV_HOTEN, (CASE NV_GIOITINH when '1' then N'Nam' else N'Nữ' end) as NV_GIOITINH, NV_NGAYSINH, NV_CMT, NV_SDT, NV_DIACHI, CD_TEN, CV_TEN"
                            + " from NHAN_VIEN a, CHUC_DANH b, CHUC_VU c where a.CD_ID = b.CD_ID and a.CV_ID = c.CV_ID and (lower(NV_HOTEN) like N'%" + nv.ToLower() + "%' or lower(NV_ID) like N'%" + nv.ToLower() + "%' or lower(CV_TEN) like N'%" + nv.ToLower() + "%' or lower(CD_TEN) like N'%" + nv.ToLower() + "%' or lower(NV_CMT) like N'%" + nv.ToLower() + "%' or lower(NV_SDT) like N'%" + nv.ToLower() + "%' or lower(NV_DIACHI) like N'%" + nv.ToLower() + "%')";
            return connecDB.ExecuteQuery(query);
        }

        public DataTable getChucDanh()
        {
            string query = " select CD_ID, CD_TEN from CHUC_DANH";
            return connecDB.ExecuteQuery(query);
        }

        public DataTable getChucVu()
        {
            string query = " select CV_ID, CV_TEN from CHUC_VU";
            return connecDB.ExecuteQuery(query);
        }

        public DataTable getGVTheoChucDanh(string macd)
        {
            string query = " select NV_ID, NV_HOTEN, (CASE NV_GIOITINH when 'true' then N'Nam' else N'Nữ' end) as NV_GIOITINH, NV_NGAYSINH, NV_CMT, NV_DIACHI, NV_DIENTHOAI, CD_ID,CD_TEN"
                        + " from NHAN_VIEN a, CHUC_DANH b where a.CD_ID = b.CD_ID and CD_ID = '" + macd + "'";
            return connecDB.ExecuteQuery(query);
        }


        


        public bool deleteNhanVien(string magv)
        {
            string query = "delete NHAN_VIEN where NV_ID = '" + magv + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool InsertNhanVien(NHAN_VIEN nv)
        {
            if (KiemTraNhapLieu(nv))
            {
                try
                {
                    string query = string.Format("Insert NHAN_VIEN (CD_ID, CV_ID, NV_HOTEN, NV_GIOITINH, NV_NGAYSINH, NV_CMT, NV_SDT, NV_DIACHI, NV_TAIKHOAN, NV_MATKHAU, NV_TINHTRANG) values ('{0}', '{1}', N'{2}', '{3}', CONVERT(DATE, '{4}', 103) , '{5}',  '{6}', N'{7}', '{8}', '{9}', '{10}')",
                                    nv.Id_cd, nv.Id_cv, nv.Nv_hoten, nv.Nv_gioitinh, nv.Nv_ngaysinh, nv.Nv_cmt, nv.Nv_sdt, nv.Nv_diachi, nv.Nv_tk, nv.Nv_mk, nv.Nv_trangthai);
                    int result = connecDB.ExecuteNonQuery(query);
                    return result > 0;
                }
                catch
                {
                    /*if (KiemTraTrungCMT(nv).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do CMT của giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if(KiemTraTrungSDT(nv).Rows.Count == 0)
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

        

        public bool KiemTraNhapLieu(NHAN_VIEN nv)
        {
            if (nv.Nv_hoten.Equals(""))
            {
                MessageBox.Show("Tên giáo viên không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (nv.Nv_ngaysinh.Equals(""))
            {
                MessageBox.Show("Ngày sinh không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            return true;
        }

        public DataTable KiemTraTrungCMT(NHAN_VIEN nv)
        {
            string query = "select * from NHAN_VIEN where NV_CMT = '" + nv.Nv_cmt + "'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }

        public DataTable KiemTraTrungSDT(NHAN_VIEN nv)
        {
            string query = "select * from NHAN_VIEN where NV_SDT = '" + nv.Nv_sdt + "'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }

        public bool UpdateNhanVien(NHAN_VIEN nv)
        {
            if (KiemTraNhapLieu(nv))
            {
                string query = string.Format("Update NHAN_VIEN set CD_ID = '{0}', CV_ID = '{1}', NV_HOTEN = N'{2}', NV_GIOITINH = N'{3}', NV_NGAYSINH = CONVERT(DATE, '{4}', 103), NV_CMT = '{5}',  NV_SDT = '{6}', NV_DIACHI = N'{7}'  where NV_ID = '{8}'",
                                               nv.Id_cd, nv.Id_cv, nv.Nv_hoten, nv.Nv_gioitinh, nv.Nv_ngaysinh, nv.Nv_cmt, nv.Nv_sdt, nv.Nv_diachi, nv.Id_nv);
                int result = connecDB.ExecuteNonQuery(query);
                return result > 0;
            }
            return true;
        }
    }
}
