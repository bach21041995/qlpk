using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlyphongkham.DAO;

namespace quanlyphongkham.FORM
{
    public partial class frmDANG_NHAP : Form
    {
        public frmDANG_NHAP()
        {
            InitializeComponent();
        }

        DAO_DANG_NHAP dao_dn = new DAO_DANG_NHAP();
        public DataTable dt = new DataTable();
        public static string nguoidung = "";
        public static string ngaysinh = "";
        public static string gioitinh = "";
        public static string cv = "";
        public static string cd = "";
        public static string sdt = "";
        public static string taikhoan = "";
        public static string matkhau = "";
        public static int idnv = 0;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan = txtTK.Text;
            matkhau = txtMK.Text;
            frmMain main = new frmMain();
            if (dao_dn.checkLogin(taikhoan, matkhau))
            {
                dt = dao_dn.getTK_MK(taikhoan, matkhau);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Đăng nhập không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTK.Focus();
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    foreach (DataRow item in dt.Rows)
                    {
                        nguoidung = item["NV_HOTEN"].ToString();
                        cv = item["CV_TEN"].ToString();
                        cd = item["CD_TEN"].ToString();
                        sdt = item["NV_SDT"].ToString();
                        gioitinh = item["NV_GIOITINH"].ToString();
                        ngaysinh = item["NV_NGAYSINH"].ToString();
                        idnv = int.Parse(item["NV_ID"].ToString());
                    }

                }
            }
        }
    }
}
