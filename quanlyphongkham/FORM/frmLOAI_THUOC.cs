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
using quanlyphongkham.DTO;

namespace quanlyphongkham.FORM
{
    public partial class frmLOAI_THUOC : Form
    {
        public frmLOAI_THUOC()
        {
            InitializeComponent();
            loadLoaithuoc();
        }

        DAO_LOAI_THUOC dao_loaithuoc = new DAO_LOAI_THUOC();
        bool dieukien = true;

        void loadLoaithuoc()
        {
            gcLT.DataSource = dao_loaithuoc.getLoaiThuoc();
            // binding();
            //groupControl1.BackColor = Color.Red;
        }

        private LOAI_THUOC getTTLoaithuoc()
        {
            string id = txtMaLT.Text;
            string ten = txtTenLT.Text;
            int tt = 1;
            LOAI_THUOC cd = new LOAI_THUOC(id, ten, tt);
            return cd;
        }

        void xulyControls(bool b)
        {
            btnThem.Enabled = !b;
            btnSua.Enabled = !b;
            btnXoa.Enabled = !b;
            pnDataLT.Visible = b;
        }

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN LOẠI THUỐC";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnDataLT.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnDataLT);
                frm.Size = new System.Drawing.Size(360, 320);
                //frm.FormClosing += form_closing;
            }
            pnDataLT.Visible = true;
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
            txtMaLT.Text = "";
            txtTenLT.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            dieukien = true;
            showFormThongTin();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LOAI_THUOC lt = getTTLoaithuoc();
            if (dieukien)
            {
                if (dao_loaithuoc.insertLoaithuoc(lt))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLoaithuoc();
                    //xulyControls(false);
                    resetText();
                    //frm.Visible = false;
                }
            }
            else
            {
                if (dao_loaithuoc.updateLoaiThuoc(lt))
                {
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLoaithuoc();
                    xulyControls(false);
                    frm.Visible = false;
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            txtMaLT.Enabled = false;
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaLT.Text = gridView1.GetFocusedRowCellValue("LT_ID").ToString();
                txtTenLT.Text = gridView1.GetFocusedRowCellValue("LT_TEN").ToString();
                //txtTienMotTiet.Text = gridView1.GetFocusedRowCellValue("TienMotTiet").ToString();
                lbMa.Text = txtMaLT.Text = gridView1.GetFocusedRowCellValue("LT_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("LT_TEN").ToString();
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
                    dao_loaithuoc.deleteLoaiThuoc(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadLoaithuoc();
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa loại thuốc '" + lbTen.Text + "' vì có thuốc đang sử dụng thông tin loại thuốc này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frm.Visible = false;
            xulyControls(false);
        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            xulyControls(false);
            //sua(true);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadLoaithuoc();
        }

        void timKiem()
        {
            string s = txtTim.Text;
            if (s.Length > 0)
            {
                gcLT.DataSource = dao_loaithuoc.TimLT(s);
            }
            else if (s.Length == 0)
            {
                loadLoaithuoc();
            }
        }

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }
    }

    
}
