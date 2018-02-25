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
    class DAO_CHUC_DANH
    {
        ConnectionDatabase conDB = new ConnectionDatabase();

        public DataTable getChucDanh()
        {
            string query = "select * from CHUC_DANH";
            DataTable dt = conDB.ExecuteQuery(query);
            return dt;
        }

        public bool deleteChucDanh(string macd)
        {
            string query = "delete CHUC_DANH where CD_ID = '" + macd + "'";
            int result = conDB.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable TimChucdanh(string cd)
        {
            string query = "select * from CHUC_DANH where lower(CD_ID) like N'%" + cd.ToLower() + "%' or lower(CD_TEN) like N'%" + cd.ToLower() + "%'";
            return conDB.ExecuteQuery(query);
        }

        public bool updateChucDanh(CHUC_DANH cd)
        {
            if (kiemTraNhapLieu(cd))
            {
                string query = "update CHUC_DANH set CD_TEN = N'" + cd.Cd_ten + "' where CD_ID = '" + cd.Id_cd + "'";
                int result = conDB.ExecuteNonQuery(query);
                return result > 0;
            }

            return true;
        }

        public bool insertChucDanh(CHUC_DANH cd)
        {
            if (kiemTraNhapLieu(cd))
            {
                try
                {
                    string query = string.Format("insert CHUC_DANH (CD_ID,CD_TEN) values ('{0}',N'{1}')", cd.Id_cd, cd.Cd_ten);
                    int result = conDB.ExecuteNonQuery(query);
                    return result > 0;
                }
                catch
                {
                    if (kiemtraTrungMaCD(cd).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do tên chức danh '" + cd.Cd_ten + "' đã có", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            return false;
        }

        public bool kiemTraNhapLieu(CHUC_DANH cd)
        {
            if (cd.Id_cd.Equals(""))
            {
                MessageBox.Show("Mã chức danh không được trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cd.Cd_ten.Equals(""))
            {
                MessageBox.Show("Tên chức danh không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public DataTable kiemtraTrungMaCD(CHUC_DANH cd)
        {
            string query = "select * from CHUC_DANH where CD_ID = '" + cd.Id_cd + "'";
            DataTable dt = conDB.ExecuteQuery(query);
            return dt;
        }
    }
}
