using quanlyphongkham.DAO;
using quanlyphongkham.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyphongkham.FORM
{
    public partial class frmCHUC_DANH : Form
    {
        public frmCHUC_DANH()
        {
            InitializeComponent();
            loadChucDanh();
        }

        DAO_CHUC_DANH dao_chucdanh = new DAO_CHUC_DANH();
        bool dieukien = true;

        void loadChucDanh()
        {
            gcCD.DataSource = dao_chucdanh.getChucDanh();
            // binding();
            //groupControl1.BackColor = Color.Red;
        }

        private CHUC_DANH getTTChucDanh()
        {
            string id = txtMaCD.Text;
            string ten = txtTenCD.Text;
            
            CHUC_DANH cd = new CHUC_DANH(id,ten);
            return cd;
        }

        void xulyControls(bool b)
        {
            btnThem.Enabled = !b;
            btnSua.Enabled = !b;
            btnXoa.Enabled = !b;
            pnDataChucDanh.Visible = b;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN CHỨC DANH";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnDataChucDanh.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnDataChucDanh);
                frm.Size = new System.Drawing.Size(360, 320);
                frm.FormClosing += form_closing;
            }
            pnDataChucDanh.Visible = true;
            if (dieukien)
            {
            }
            else
            {
            }
            frm.ShowDialog();
        }

        void resetText()
        {
            txtMaCD.Text = "";
            txtTenCD.Text = "";
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            dieukien = true;
            showFormThongTin();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            CHUC_DANH cd = getTTChucDanh();
            if (dieukien)
            {
                if (dao_chucdanh.insertChucDanh(cd))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChucDanh();
                    //xulyControls(false);
                    resetText();
                    //frm.Visible = false;
                }
            }
            else
            {
                if (dao_chucdanh.updateChucDanh(cd))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChucDanh();
                    xulyControls(false);
                    frm.Visible = false;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            txtMaCD.Enabled = false;
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaCD.Text = gridView1.GetFocusedRowCellValue("CD_ID").ToString();
                txtTenCD.Text = gridView1.GetFocusedRowCellValue("CD_TEN").ToString();
                //txtTienMotTiet.Text = gridView1.GetFocusedRowCellValue("TienMotTiet").ToString();
                lbMa.Text = txtMaCD.Text = gridView1.GetFocusedRowCellValue("CD_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("CD_TEN").ToString();
            }
            catch
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa chức danh  '" + lbTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dao_chucdanh.deleteChucDanh(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChucDanh();
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa Chức danh '" + lbTen.Text + "' vì có nhân viên sử dụng thông tin Chức danh này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frm.Visible = false;
        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            dieukien = true;
            txtMaCD.Enabled = true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadChucDanh();
        }

        void timKiem()
        {
            string s = txtTim.Text;
            if (s.Length > 0)
            {
                gcCD.DataSource = dao_chucdanh.TimChucdanh(s);
            }
            else if (s.Length == 0)
            {
                loadChucDanh();
            }
        }

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }
    }
}
