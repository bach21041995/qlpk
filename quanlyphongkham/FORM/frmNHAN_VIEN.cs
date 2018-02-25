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
    public partial class frmNHAN_VIEN : Form
    {
        public frmNHAN_VIEN()
        {
            InitializeComponent();
            loadNhanVien();
        }

        DAO_NHAN_VIEN dao_nv = new DAO_NHAN_VIEN();
        bool dieukien = true;

        void loadNhanVien()
        {
            gdNV.DataSource = dao_nv.getDSNhanVien();
        }

        void loadChucDanh()
        {
            cbCD.DataSource = dao_nv.getChucDanh();
            cbCD.DisplayMember = "CD_TEN";
            cbCD.ValueMember = "CD_ID";
        }

        void loadChucVu()
        {
            cbCV.DataSource = dao_nv.getChucVu();
            cbCV.DisplayMember = "CV_TEN";
            cbCV.ValueMember = "CV_ID";
        }

        void loadGT()
        {
            var items = new BindingList<KeyValuePair<string, string>>();

            items.Add(new KeyValuePair<string, string>("1", "Nam"));
            items.Add(new KeyValuePair<string, string>("0", "Nữ"));

            cbGioitinh.DataSource = items;
            cbGioitinh.ValueMember = "Key";
            cbGioitinh.DisplayMember = "Value";
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

        Form frm = null;
        public void showFormThongTin()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Text = "THÔNG TIN NHÂN VIÊN";
                frm.MaximizeBox = false;
                frm.MinimizeBox = false;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                frm.StartPosition = FormStartPosition.CenterScreen;
                pnEdit.Dock = DockStyle.Top | DockStyle.Left;
                frm.Controls.Add(pnEdit);
                frm.Size = new System.Drawing.Size(587, 356);
                frm.FormClosing += form_closing;
            }
            pnEdit.Visible = true;
            frm.ShowDialog();
        }

        private NHAN_VIEN LayTTNV()
        {
            //int idnv = int.Parse(lbMa.Text);
            string ten = txtTen.Text;
            DateTime dt = Convert.ToDateTime(dateNS.Text);
            string ngaysinh = dt.ToShortDateString();
            int gioitinh = (cbGioitinh.Text == "Nam") ? 1 : 0;
            string dienthoai = txtSDT.Text;
            string cmt = txtCMT.Text;
            string tk = txtTK.Text;
            string mk = txtMK.Text;
            string diachi = txtDiachi.Text;
            string idcd = cbCD.SelectedValue.ToString();
            
            //int i = int.parse(label5.Text.ToString());
            string idcv = cbCV.SelectedValue.ToString();
            
            NHAN_VIEN nv = new NHAN_VIEN(idcd, idcv, ten, gioitinh, ngaysinh, cmt, dienthoai, diachi, tk, mk, 1);

            return nv;
        }

        void resetText()
        {
            txtDiachi.Text = "";
            txtSDT.Text = "";
            txtTen.Text = "";
            txtCMT.Text = "";
            txtTK.Text = "";
            txtMK.Text = "";
            txtMk2.Text = "";
            dateNS.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        void sua(bool b)
        {
            txtTK.Visible = b;
            txtMK.Visible = b;
            txtMk2.Visible = b;
            label10.Visible = b;
            label11.Visible = b;
            label12.Visible = b;
        }

        private void gdNV_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetText();
            xuLyControl(true);
            dieukien = true;
            //btnThemTiep.Enabled = true;
            loadChucDanh();
            loadChucVu();
            loadGT();
            showFormThongTin();
            sua(true);
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
                NHAN_VIEN nv = LayTTNV();
                if (dieukien)
                {
                    if (dao_nv.InsertNhanVien(nv))
                    {
                        MessageBox.Show("Thêm thành công");
                        loadNhanVien();
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                        frm.Visible = false;
                        resetText();
                    }
                }
                else
                {
                    if (dao_nv.UpdateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        loadNhanVien();
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                        frm.Visible = false;
                        resetText();
                        sua(true);
                    }
                }
            }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyControl(true);
            dieukien = false;
            loadGT();
            //txtMa.Enabled = false;
            //btnThemTiep.Enabled = false;
            sua(false);
            showFormThongTin();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                lbMa.Text = gridView1.GetFocusedRowCellValue("NV_ID").ToString();
                lbTen.Text = gridView1.GetFocusedRowCellValue("NV_HOTEN").ToString();
                txtCMT.Text = gridView1.GetFocusedRowCellValue("NV_CMT").ToString();
                //txtMa.Text = gridView1.GetFocusedRowCellValue("MaGV").ToString();
                txtTen.Text = gridView1.GetFocusedRowCellValue("NV_HOTEN").ToString();
                txtSDT.Text = gridView1.GetFocusedRowCellValue("NV_SDT").ToString();
                txtDiachi.Text = gridView1.GetFocusedRowCellValue("NV_DIACHI").ToString();
                cbCD.Text = gridView1.GetFocusedRowCellValue("CD_TEN").ToString();
                cbCV.Text = gridView1.GetFocusedRowCellValue("CV_TEN").ToString();
                dateNS.Text = gridView1.GetFocusedRowCellValue("NV_NGAYSINH").ToString();
                cbGioitinh.Text = gridView1.GetFocusedRowCellValue("NV_GIOITINH").ToString();
                
                
            }
            catch
            {
            }
        }

        private void form_closing(object sender, FormClosingEventArgs e)
        {
            xuLyControl(false);
            sua(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl(false);
            sua(true);
            frm.Visible = false;
        }

        private void frmNHAN_VIEN_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            loadChucDanh();
            loadChucVu();
            loadGT();
            gridView1_FocusedRowChanged(null, null);
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCMT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        void timKiem()
        {
            string s = txtTim.Text;
            if (s.Length > 0)
            {
                gdNV.DataSource = dao_nv.TimNV(s);
            }
            else if (s.Length == 0)
            {
                loadNhanVien();
            }
        }

        private void txtTim_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }
    }
}
