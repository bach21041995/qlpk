using quanlyphongkham.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_CHUC_VU
    {
        ConnectionDatabase conDB = new ConnectionDatabase();

        public DataTable getChucVu()
        {
            string query = "select * from CHUC_VU";
            DataTable dt = conDB.ExecuteQuery(query);
            return dt;
        }

        public bool deleteChucVu(string macv)
        {
            string query = "delete CHUC_VU where CV_ID = '" + macv + "'";
            int result = conDB.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool updateChucVu(CHUC_VU cv)
        {
            if (kiemTraNhapLieu(cv))
            {
                string query = "update CHUC_VU set CV_TEN = N'" + cv.Cv_ten + "' where CV_ID = '" + cv.Id_cv + "'";
                int result = conDB.ExecuteNonQuery(query);
                return result > 0;
            }
            return true;
        }

        public DataTable TimChucvu(string cv)
        {
            string query = "select * from CHUC_VU where lower(CV_TEN) like N'%" + cv.ToLower() + "%' or lower(CV_ID) like N'%" + cv.ToLower() + "%'";
            return conDB.ExecuteQuery(query);
        }

        

        public bool insertChucVu(CHUC_VU cv)
        {
            if (kiemTraNhapLieu(cv))
            {
                try
                {
                    string query = string.Format("insert CHUC_VU (CV_ID,CV_TEN) values ('{0}',N'{1}')", cv.Id_cv, cv.Cv_ten);
                    int result = conDB.ExecuteNonQuery(query);
                    return result > 0;
                }
                catch
                {
                    if (kiemtraTrungMaCV(cv).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do tên chức vụ '" + cv.Cv_ten + "' đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return false;
        }

        

        public bool kiemTraNhapLieu(CHUC_VU cv)
        {
            if (cv.Id_cv.Equals(""))
            {
                MessageBox.Show("Mã chức danh không được trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cv.Cv_ten.Equals(""))
            {
                MessageBox.Show("Tên chức vụ không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public DataTable kiemtraTrungMaCV(CHUC_VU cv)
        {
            string query = "select * from CHUC_VU where CV_ID = '" + cv.Id_cv + "'";
            DataTable dt = conDB.ExecuteQuery(query);
            return dt;
        }
    }
}
