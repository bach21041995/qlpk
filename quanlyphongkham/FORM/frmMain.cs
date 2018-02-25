using DevExpress.XtraTab;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public DataTable dt = new DataTable();
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        void addForm(XtraTabPage tabpage, Form frm, string s)
        {
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Show();
            tabpage.Text = s;
            tabpage.Controls.Add(frm);
            tabMain.TabPages.Add(tabpage);
            tabMain.SelectedTabPage = tabpage;
        }

        void loadPage(XtraTabPage tabpage, Form frm)
        {
            try
            {
                tabpage.Controls.Add(frm);
                tabMain.TabPages.Add(tabpage);
                tabMain.SelectedTabPage = tabpage;
                frm.Show();
            }
            catch { }
        }

        private void tabMain_CloseButtonClick(object sender, EventArgs e)
        {
            int i = tabMain.SelectedTabPageIndex;
            tabMain.TabPages.Remove(tabMain.SelectedTabPage);
            tabMain.SelectedTabPageIndex = i - 1;
        }

        XtraTabPage tabChucDanh;
        frmCHUC_DANH chucdanh;
        private void btnCD_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chucdanh == null)
            {
                tabChucDanh = new XtraTabPage();
                chucdanh = new frmCHUC_DANH();
                addForm(tabChucDanh, chucdanh, "Chức danh");
            }
            else
            {
                loadPage(tabChucDanh, chucdanh);
            }
        }

        XtraTabPage tabChucVu;
        frmCHUC_VU chucvu;
        private void btnCV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chucvu == null)
            {
                tabChucVu = new XtraTabPage();
                chucvu = new frmCHUC_VU();
                addForm(tabChucVu, chucvu, "Chức vụ");
            }
            else
            {
                loadPage(tabChucVu, chucvu);
            }
        }

        XtraTabPage tabNhanVien;
        frmNHAN_VIEN nhanvien ;
        private void btnNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (nhanvien == null)
            {
                tabNhanVien = new XtraTabPage();
                nhanvien = new frmNHAN_VIEN();
                addForm(tabNhanVien, nhanvien, "Nhân viên");
            }
            else
            {
                loadPage(tabNhanVien, nhanvien);
            }
        }


        XtraTabPage tabLoaiThuoc;
        frmLOAI_THUOC loaithuoc;
        private void btnLT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(loaithuoc == null)
            {
                tabLoaiThuoc = new XtraTabPage();
                loaithuoc = new frmLOAI_THUOC();
                addForm(tabLoaiThuoc, loaithuoc, "Loại thuốc");
            }
            else
            {
                loadPage(tabLoaiThuoc, loaithuoc);
            }
        }

        XtraTabPage tabThuoc;
        frmDM_THUOC thuoc;
        
        private void btnThuoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (thuoc == null)
            {
                tabThuoc = new XtraTabPage();
                thuoc = new frmDM_THUOC();
                addForm(tabThuoc, thuoc, "Danh mục Thuốc");
                
            }
            else
            {
                loadPage(tabThuoc, thuoc);
            }
        }

        XtraTabPage tabLBL;
        frmLOAI_BENHLY lbl;
        private void btnLBL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbl == null)
            {
                tabLBL = new XtraTabPage();
                lbl = new frmLOAI_BENHLY();
                addForm(tabLBL, lbl, "Danh mục loại bệnh lý");

            }
            else
            {
                loadPage(tabLBL, lbl);
            }
        }

        XtraTabPage tabCLS;
        frmCAN_LAM_SAN cls;
        private void btnCLS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cls == null)
            {
                tabCLS = new XtraTabPage();
                cls = new frmCAN_LAM_SAN();
                addForm(tabCLS, cls, "Danh mục cận lâm sàn");

            }
            else
            {
                loadPage(tabCLS, cls);
            }
        }

        XtraTabPage tabPTN;
        frmPHIEU_TIEP_NHAN ptn;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ptn == null)
            {
                tabPTN = new XtraTabPage();
                ptn = new frmPHIEU_TIEP_NHAN();
                addForm(tabPTN, ptn, "Phiếu tiếp nhận");
            }
            else
            {
                loadPage(tabPTN, ptn);
            }
        }

        XtraTabPage tabKB;
        frmKHAM_BENH kb;

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(kb == null)
            {
                tabKB = new XtraTabPage();
                kb = new frmKHAM_BENH();
                addForm(tabKB, kb, "Khám bệnh");
            }
            else
            {
                loadPage(tabKB, kb);
            }
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = frmDANG_NHAP.nguoidung;
            txtSdt.Text = frmDANG_NHAP.sdt;
            txtNgaySinh.Text = frmDANG_NHAP.ngaysinh;
            txtGioitinh.Text = frmDANG_NHAP.gioitinh;
            txtCV.Text = frmDANG_NHAP.cv;
            txtCD.Text = frmDANG_NHAP.cd;
        }
    }
}
