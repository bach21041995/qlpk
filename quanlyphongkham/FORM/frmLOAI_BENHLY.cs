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
    public partial class frmLOAI_BENHLY : Form
    {
        public frmLOAI_BENHLY()
        {
            InitializeComponent();
        }

        DAO_LOAI_BENHLY daoLBL = new DAO_LOAI_BENHLY();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        bool dieukien = true;

        void loadLBL()
        {
            gdLBL.DataSource = daoLBL.getDSLBL();
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
            txtTenLBL.Text = "";
            txtMaLBL.Text = "";
            
        }

        private LOAI_BENHLY LayTTLBL()
        {
            string ma = txtMaLBL.Text;
            string ten = txtTenLBL.Text;
            

            LOAI_BENHLY lbl = new LOAI_BENHLY(ma, ten);

            return lbl;
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
                frm.Text = "THÔNG TIN LOẠI BỆNH LÝ";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnEdit.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnEdit);
                frm.Size = new System.Drawing.Size(362, 255);
            }
            pnEdit.Visible = true;
            frm.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
            //sua(true);
        }



        private void frmLOAI_BENHLY_Load(object sender, EventArgs e)
        {
            loadLBL();
        }

        void timKiem()
        {
            string s = txtTim.Text;
            

            if (s.Length > 0)
            {
                
                gdLBL.DataSource = daoLBL.TimLBL(s);
                
            }
            else if (s.Length == 0)
            {
                loadLBL();
            }
        }

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            xuLyControl(true);
            dieukien = true;
            //btnThemTiep.Enabled = true;
            //cbLT2.Enabled = true;
            showFormThongTin();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMaLBL.Text = gridView1.GetFocusedRowCellValue("LBL_ID").ToString();
                lbMa.Text = gridView1.GetFocusedRowCellValue("LBL_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("LBL_TEN").ToString();
                txtTenLBL.Text = gridView1.GetFocusedRowCellValue("LBL_TEN").ToString();
            }
            catch
            {
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LOAI_BENHLY t = LayTTLBL();
            if (dieukien)
            {
                if (daoLBL.InsertLBL(t))
                {
                    MessageBox.Show("Thêm thành công");
                    loadLBL();
                    xuLyControl(false);
                    //txtMa.Enabled = true;
                    frm.Visible = false;
                    resetText();
                }
            }
            else
            {
                if (daoLBL.UpdateLBL(t))
                {
                    MessageBox.Show("Sửa thành công");
                    loadLBL();
                    xuLyControl(false);
                    //txtMa.Enabled = true;
                    frm.Visible = false;
                    resetText();
                    //sua(true);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dieukien = false;
            xuLyControl(true);
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa loại bệnh lý '" + lbTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    daoLBL.deleteLBL(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xuLyControl(false);
                    loadLBL();
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa loại bệnh lý '" + lbTen.Text + "' vì có bệnh lý thuộc loại bệnh lý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadLBL();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(false);
            //sua(true);
            frm.Visible = false;
        }
    }
}
