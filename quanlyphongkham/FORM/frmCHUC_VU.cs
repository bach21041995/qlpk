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
    public partial class frmCHUC_VU : Form
    {
        public frmCHUC_VU()
        {
            InitializeComponent();
            loadChucVu();
        }

        DAO_CHUC_VU dao_chucvu = new DAO_CHUC_VU();
        bool dieukien = true;
        void loadChucVu()
        {
            gdCV.DataSource = dao_chucvu.getChucVu();

            // binding();
            //groupControl1.BackColor = Color.Red;
        }


        
        private CHUC_VU getTTChucVu()
        {
            string id = txtMaCV.Text;
            string ten = txtTenCV.Text;

            CHUC_VU cv = new CHUC_VU(id, ten);
            return cv;
        }

        void xulyControls(bool b)
        {
            btnThem.Enabled = !b;
            btnSua.Enabled = !b;
            btnXoa.Enabled = !b;
            pnDataChucVu.Visible = b;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN CHỨC VỤ";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnDataChucVu.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnDataChucVu);
                frm.Size = new System.Drawing.Size(360, 320);
                frm.FormClosing += form_closing;
            }
            pnDataChucVu.Visible = true;
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
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            dieukien = true;
            showFormThongTin();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }



        private void gdCV_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            txtMaCV.Enabled = false;
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaCV.Text = gridView1.GetFocusedRowCellValue("CV_ID").ToString();
                txtTenCV.Text = gridView1.GetFocusedRowCellValue("CV_TEN").ToString();
                //txtTienMotTiet.Text = gridView1.GetFocusedRowCellValue("TienMotTiet").ToString();
                lbMa.Text = txtMaCV.Text = gridView1.GetFocusedRowCellValue("CV_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("CV_TEN").ToString();
            }
            catch
            {
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa chức vụ  '" + lbTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    dao_chucvu.deleteChucVu(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xulyControls(false);
                    loadChucVu();
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa Chức vụ '" + lbTen.Text + "' vì có nhân viên sử dụng thông tin Chức vụ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frm.Visible = false;
            dieukien = true;
            txtMaCV.Enabled = true;
        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            dieukien = true;
            txtMaCV.Enabled = true;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            CHUC_VU cv = getTTChucVu();
            if (dieukien)
            {
                if (dao_chucvu.insertChucVu(cv))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChucVu();
                    //xulyControls(false);
                    resetText();
                    //frm.Visible = false;
                }
            }
            else
            {
                if (dao_chucvu.updateChucVu(cv))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChucVu();
                    xulyControls(false);
                    frm.Visible = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadChucVu();
        }

        void timKiem()
        {
            string s = txtTim.Text;
            if (s.Length > 0)
            {   
                gdCV.DataSource = dao_chucvu.TimChucvu(s);
            }
            else if (s.Length == 0)
            {
                loadChucVu();
            }
        }

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }
    }
}
