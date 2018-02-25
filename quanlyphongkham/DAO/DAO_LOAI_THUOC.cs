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
    class DAO_LOAI_THUOC
    {
        ConnectionDatabase conDB = new ConnectionDatabase();

        public DataTable getLoaiThuoc()
        {
            string query = "select * from LOAI_THUOC where LT_TRANGTHAI = '1'";
            DataTable dt = conDB.ExecuteQuery(query);
            return dt;
        }

        public bool deleteLoaiThuoc(string malt)
        {
            string query = "update LOAI_THUOC set LT_TRANGTHAI = '0' where LT_ID = '" + malt + "'";
            int result = conDB.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable TimLT(string lt)
        {
            string query = "select * from LOAI_THUOC where LT_TRANGTHAI = '1' and (lower(LT_ID) like N'%" + lt.ToLower() + "%' or lower(LT_TEN) like N'%" + lt.ToLower() + "%')";
            return conDB.ExecuteQuery(query);
        }

        public bool updateLoaiThuoc(LOAI_THUOC lt)
        {
            if (kiemTraNhapLieu(lt))
            {
                string query = "update LOAI_THUOC set LT_TEN = N'" + lt.Lt_ten + "' where LT_ID = '" + lt.Id_lt + "'";
                int result = conDB.ExecuteNonQuery(query);
                return result > 0;
            }
            return true;
        }

        public bool insertLoaithuoc(LOAI_THUOC lt)
        {
            if (kiemTraNhapLieu(lt))
            {
                try
                {
                    string query = string.Format("insert LOAI_THUOC (LT_ID,LT_TEN,LT_TRANGTHAI) values ('{0}',N'{1}','1')", lt.Id_lt, lt.Lt_ten, lt.Lt_trangthai);
                    int result = conDB.ExecuteNonQuery(query);
                    return result > 0;
                }
                catch
                {
                    if (kiemtraTrungMaLT(lt).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do tên loại thuốc '" + lt.Lt_ten + "' đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return false;
        }

        public bool kiemTraNhapLieu(LOAI_THUOC lt)
        {
            if (lt.Lt_ten.Equals(""))
            {
                MessageBox.Show("Tên loại thuốc không được trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public DataTable kiemtraTrungMaLT(LOAI_THUOC lt)
        {
            string query = "select * from LOAI_THUOC where LT_ID = '" + lt.Id_lt + "'";
            DataTable dt = conDB.ExecuteQuery(query);
            return dt;
        }
    }
}
