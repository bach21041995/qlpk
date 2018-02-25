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
    public partial class frmCAN_LAM_SAN : Form
    {
        public frmCAN_LAM_SAN()
        {
            InitializeComponent();
        }

        DAO_DM_CANLAMSAN daoCLS = new DAO_DM_CANLAMSAN();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        bool dieukien = true;

        void loadCLS()
        {
            gcCLS.DataSource = daoCLS.getDSCLS();
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
            txtMa.Text = "";
            txtMota.Text = "";
            txtGia.Text = "";
        }

        private DM_CANLAMSAN LayTTCLS()
        {
            string ma = txtMa.Text;
            string ten = txtTen.Text;
            string mota = txtMota.Text;
            float gia = float.Parse(txtGia.Text);
            int tt = 1;


            DM_CANLAMSAN cls = new DM_CANLAMSAN(ma, ten, mota, gia, tt);

            return cls;
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
                frm.Text = "THÔNG TIN CẬN LÂM SÀN";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormClosing += frm_Closing;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                pnEdit.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnEdit);
                frm.Size = new System.Drawing.Size(400, 300);
            }
            pnEdit.Visible = true;
            frm.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
            //sua(true);
        }

        private void frmCAN_LAM_SAN_Load(object sender, EventArgs e)
        {
            loadCLS();
        }

        void timKiem()
        {
            string s = txtTim.Text;


            if (s.Length > 0)
            {

                gcCLS.DataSource = daoCLS.TimCLS(s);

            }
            else if (s.Length == 0)
            {
                loadCLS();
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
            txtMa.Enabled = true;
            dieukien = true;
            //btnThemTiep.Enabled = true;
            //cbLT2.Enabled = true;
            showFormThongTin();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtMa.Text = gridView1.GetFocusedRowCellValue("CLS_ID").ToString();
                lbMa.Text = gridView1.GetFocusedRowCellValue("CLS_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("CLS_TEN").ToString();
                txtTen.Text = gridView1.GetFocusedRowCellValue("CLS_TEN").ToString();
                txtMota.Text = gridView1.GetFocusedRowCellValue("CLS_MOTA").ToString();
                txtGia.Text = gridView1.GetFocusedRowCellValue("CLS_DONGIA").ToString();
            }
            catch
            {
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DM_CANLAMSAN t = LayTTCLS();
            if (dieukien)
            {
                if (daoCLS.InsertCLS(t))
                {
                    MessageBox.Show("Thêm thành công");
                    loadCLS();
                    xuLyControl(false);
                    //txtMa.Enabled = true;
                    frm.Visible = false;
                    resetText();
                }
            }
            else
            {
                if (daoCLS.UpdateCLS(t))
                {
                    MessageBox.Show("Sửa thành công");
                    loadCLS();
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
            txtMa.Enabled = false;
            //btnThemTiep.Enabled = false;
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa cận lâm sàn '" + lbTen.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    daoCLS.deleteCLS(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xuLyControl(false);
                    loadCLS();
                }
            }
            catch
            {
                //MessageBox.Show("Không thể xóa loại bệnh lý '" + lbTen.Text + "' vì có bệnh lý thuộc loại bệnh lý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadCLS();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(false);
            //sua(true);
            frm.Visible = false;
        }
    }
}
