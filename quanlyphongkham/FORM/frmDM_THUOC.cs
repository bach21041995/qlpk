using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlyphongkham.DTO;
using quanlyphongkham.DAO;
using DevExpress.XtraGrid;

namespace quanlyphongkham.FORM
{
    public partial class frmDM_THUOC : Form
    {
        public frmDM_THUOC()
        {
            InitializeComponent();
            
        }

        DAO_DM_THUOC daoThuoc = new DAO_DM_THUOC();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        bool dieukien = true;

        void loadThuoc()
        {
            gcThuoc.DataSource = daoThuoc.getDSThuoc();
        }

        public void loadData()
        {     
            //cbLT.DataSource = daoThuoc.getLT();
            //cbLT.DisplayMember = "LT_TEN";
            //cbLT.ValueMember = "LT_ID";
            //cbLT.Items.Insert(0, "Tất cả");
            //cbLT.SelectedIndex = 0;
            cbLT2.DataSource = daoThuoc.getLT();
            cbLT2.DisplayMember = "LT_TEN";
            cbLT2.ValueMember = "LT_ID";
        }

        void binding()
        {
            //cbLT.DataBindings.Clear();
            //cbLT.DataBindings.Add("SelectedValue", gcThuoc.DataSource, "LT_ID");
        }

        private void frmDM_THUOC_Load(object sender, EventArgs e)
        {
            loadThuoc();
            loadData();
            //binding();
            //cbLT_SelectedIndexChanged(null, null);
            //gridView1_FocusedRowChanged(null, null);
            //cbLT_SelectedIndexChanged(sender, e);
        }

        void xuLyControl(bool b)
        {
            btnThem.Enabled = !b;
            btnSua.Enabled = !b;
            btnXoa.Enabled = !b;
            pnEdit.Enabled = b;
            btnLuu.Visible = b;
            btnHuy.Visible = b;
            //btnThemTiep.Visible = b;
        }

        void resetText()
        {
            txtTen.Text = "";
            txtCD.Text = "";
            txtHDSD.Text = "";
            txtMa.Text = "";
            txtDVT.Text = "";
            txtGia.Text = "";
        }

        private DM_THUOC LayTTThuoc()
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string idlt = cbLT2.SelectedValue.ToString();
            string hdsd = txtHDSD.Text;
            string cd = txtCD.Text;
            string dvt = txtDVT.Text;
            float gia = float.Parse(txtGia.Text);
            int tt = 1;
            string cachdung = txtCachdung.Text;
            
            DM_THUOC t = new DM_THUOC(ma, idlt, ten, hdsd, dvt, cd, gia, tt, cachdung);

            return t;
        }

        Form frm = null;
        public void showFormThongTin()
        {

            //cbGioiTinh.SelectedIndex = 0;
            //cbLT2_SelectedIndexChanged(null, null);
            //cbbDT_SelectedIndexChanged(null, null);
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN THUỐC";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnEdit.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnEdit);
                frm.Size = new System.Drawing.Size(580, 310);
            }
            pnEdit.Visible = true;
            frm.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            xuLyControl(true);
            dieukien = true;
            loadData();
            //btnThemTiep.Enabled = true;
            cbLT2.Enabled = true;
            showFormThongTin();
            cbLT2_SelectedIndexChanged(sender, e);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMa.Text = gridView1.GetFocusedRowCellValue("THUOC_ID").ToString();
                lbMa.Text = gridView1.GetFocusedRowCellValue("THUOC_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("THUOC_TEN").ToString();
                
                txtTen.Text = gridView1.GetFocusedRowCellValue("THUOC_TEN").ToString();
                txtHDSD.Text = gridView1.GetFocusedRowCellValue("THUOC_HDSD").ToString();
                txtCD.Text = gridView1.GetFocusedRowCellValue("THUOC_CONGDUNG").ToString();
                txtDVT.Text = gridView1.GetFocusedRowCellValue("THUOC_DVT").ToString();
                txtGia.Text = gridView1.GetFocusedRowCellValue("THUOC_GIA").ToString();
                cbLT2.Text = gridView1.GetFocusedRowCellValue("LT_TEN").ToString();
            }
            catch
            {
            }
        }

        

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_THUOC t = LayTTThuoc();
            if (dieukien)
            {
                if (daoThuoc.InsertThuoc(t))
                {
                    MessageBox.Show("Thêm thành công");
                    loadThuoc();
                    xuLyControl(false);
                    //txtMa.Enabled = true;
                    frm.Visible = false;
                    resetText();
                }
            }
            else
            {
                if (daoThuoc.UpdateThuoc(t))
                {
                    MessageBox.Show("Sửa thành công");
                    loadThuoc();
                    xuLyControl(false);
                    //txtMa.Enabled = true;
                    frm.Visible = false;
                    resetText();
                    //sua(true);
                }
            }
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
            //sua(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(false);
            //sua(true);
            frm.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                loadData();
                loadThuoc();
                //string value = cbLT.SelectedValue.ToString();
                //gcThuoc.DataSource = daoThuoc.getThuocByLT(value);
                //loadData();
            }
            catch
            {
                //MessageBox.Show("Chưa có thuốc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(true);
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void cbLT2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string malt = cbLT2.SelectedValue.ToString();

                if (dieukien == true)
                {
                    txtMa.Text = daoThuoc.insertMaThuoc(malt);
                }
               else
               {
                    txtMa.Text = gridView1.GetFocusedRowCellValue("THUOC_ID").ToString();
               }
            }
            catch
            {
            }
        }

        void timKiem()
        {
            string s = txtTim.Text;
            //string where = "";
            //string query = "";
            //where = " lower(THUOC_TEN) like N'%" + s.ToLower() + "%'";
            
            /*if (cbbTK.Text == "Mã học viên")
            {
                where = "  mahv like '%" + s + "%'";
            }
            else if (cbbTK.Text == "Tên học viên")
            {
                where = " lower(tenhv) like N'%" + s.ToLower() + "%'";
            }
            else if (cbbTK.Text == "Đối tượng")
            {
                where = " lower(c.tendt) like N'%" + s.ToLower() + "%'";
            }
            else if (cbbTK.Text == "Lớp")
            {
                where = " lower(b.tenlop) like N'%" + s.ToLower() + "%'";
            }*/

            if (s.Length > 0)
            {
                //query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
                //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + where + "";
                //DataTable dt = conDB.ExecuteQuery(query);
                gcThuoc.DataSource = daoThuoc.TimThuoc(s);
                /*if (dt != null)
                {
                    gcHocVien.DataSource = dt;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }*/
            }
            else if (s.Length == 0)
            {
                loadThuoc();
            }
        }

        

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa thuốc  '" + lbTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    daoThuoc.deleteThuoc(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xuLyControl(false);
                    loadThuoc();
                }
            }
            catch
            {
                //MessageBox.Show("Không thể xóa thuốc '" + lbTen.Text + "' vì có nhân viên sử dụng thông tin Chức vụ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
