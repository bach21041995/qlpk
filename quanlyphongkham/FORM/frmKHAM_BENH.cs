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
using quanlyphongkham.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;

namespace quanlyphongkham.FORM
{
    public partial class frmKHAM_BENH : Form
    {
        public frmKHAM_BENH()
        {
            InitializeComponent();
        }

        DAO_PHIEU_TIEP_NHAN daoPTN = new DAO_PHIEU_TIEP_NHAN();
        DAO_BENH_NHAN daoBN = new DAO_BENH_NHAN();
        DAO_NHAN_VIEN daoNV = new DAO_NHAN_VIEN();
        DAO_BENH_LY daoBL = new DAO_BENH_LY();
        DAO_KHAM_BENH daoKB = new DAO_KHAM_BENH();
        DAO_CT_BENHLY daoCTBL = new DAO_CT_BENHLY();
        DAO_DM_THUOC daoTHUOC = new DAO_DM_THUOC();
        DAO_TOA_THUOC daoTT = new DAO_TOA_THUOC();
        DAO_CT_TOATHUOC daoCTTT = new DAO_CT_TOATHUOC();
        
        //DAO_NGAY daoNgay = new DAO_NGAY();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        bool dieukien = true;

        bool dieukien2 = true;

        bool themtt = false;

        bool delete = false;

        int bl;

        void loadPTN()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoPTN.getPTN_NGAY(ngay);
            xuly(false);

            //gdPTN.DataSource = daoPTN.getDSPTN();
        }

        void loadPTN_ALL()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN_ALL();
            xuly(false);
        }


        void loadPTN_DK()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN_DK();
            xuly(false);
        }

        void loadPTN_KX()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN_KX();
            xuly(false);
        }


        //load DS Khám bệnh
        void loadKB_NGAY()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoKB.getKB_NGAY(ngay);
            xuly(false);
        }

        void loadKB_NGAY_DK()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoKB.getKB_NGAY_DK(ngay);
            xuly(false);
        }


        void loadKB_NGAY_KX()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoKB.getKB_NGAY_KX(ngay);
            xuly(false);
        }

        void loadBL()
        {
            gdBL.DataSource = daoBL.getBL();
            xuly(false);
        }



        void xuly(bool b)
        {
            txtMaICD.Enabled = b;
            txtICD.Enabled = b;
            txtChuyenmon.Enabled = b;
            txtMucdo.Enabled = b;
            txtBenhphu.Enabled = b;
            txtMaBP.Enabled = b;
            txtKetluan.Enabled = b;
            btnKham.Enabled = !b;
            btnSua.Enabled = b;
            btnLuu2.Enabled = b;
            btnHuy2.Enabled = b;
            btnHoantat.Enabled = b;
            btnICD.Enabled = b;
            btnBP.Enabled = b;
            btnKetoa.Enabled = b;
            btnChidinh.Enabled = b;
            btnLichsu.Enabled = b;
        }

        void reset()
        {
            txtICD.Text = "";
            txtMaICD.Text = "";
            txtChuyenmon.Text = "";
            txtMucdo.Text = "";
            txtBenhphu.Text = "";
            txtMaBP.Text = "";
            txtKetluan.Text = "";
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            DateTK.Text = ngay;
        }


        public void loadData()
        {
            var items = new BindingList<KeyValuePair<string, string>>();

            items.Add(new KeyValuePair<string, string>("1", "Nam"));
            items.Add(new KeyValuePair<string, string>("0", "Nữ"));

            cbGioitinh2.DataSource = items;
            cbGioitinh2.ValueMember = "Key";
            cbGioitinh2.DisplayMember = "Value";

            var items2 = new BindingList<KeyValuePair<string, string>>();

            items2.Add(new KeyValuePair<string, string>("A", "A"));
            items2.Add(new KeyValuePair<string, string>("O", "O"));
            items2.Add(new KeyValuePair<string, string>("B", "B"));
            items2.Add(new KeyValuePair<string, string>("AB", "AB"));

            cbNhommau.DataSource = items2;
            cbNhommau.ValueMember = "Key";
            cbNhommau.DisplayMember = "Value";

            var items3 = new BindingList<KeyValuePair<string, string>>();

            items3.Add(new KeyValuePair<string, string>("TT", "Chờ khám"));
            items3.Add(new KeyValuePair<string, string>("DK", "Đang khám"));
            items3.Add(new KeyValuePair<string, string>("KX", "Đã khám"));
            items3.Add(new KeyValuePair<string, string>("TC", "Tất cả"));

            cbTT.DataSource = items3;
            cbTT.ValueMember = "Key";
            cbTT.DisplayMember = "Value";
        }

        private void frmKHAM_BENH_Load(object sender, EventArgs e)
        {
            loadData();
            loadPTN();
            loadBL();
            xuly(false);
        }

        private void cbTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTT.Text == "Chờ khám")
            {
                btnKham.Enabled = true;
                btnSua.Enabled = false;
                //DateChonNgay.Enabled = false;
                loadPTN();
                
            }
            else if (cbTT.Text == "Đang khám")
            {
                
                
                //DateChonNgay.Enabled = true;
                loadKB_NGAY_DK();
                btnKham.Enabled = false;
                btnSua.Enabled = true;


            }
            else if (cbTT.Text == "Đã khám")
            {
                btnKham.Enabled = false;
                btnSua.Enabled = true;
                //DateChonNgay.Enabled = false;
                loadKB_NGAY_KX();
            }
            else
            {
                loadKB_NGAY();
            }
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //txtMa2.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            
        }

        Form frmBL = null;
        public void showFormBL()
        {

            if (frmBL == null)
            {
                frmBL = new Form();
                frmBL.Text = "DANH MỤC BỆNH LÝ";
                frmBL.MaximizeBox = false;
                frmBL.MinimizeBox = false;
                frmBL.BackColor = Color.White;
                frmBL.FormClosing += frm_Closing;
                frmBL.StartPosition = FormStartPosition.CenterScreen;
                frmBL.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                panelBL.Dock = DockStyle.Top | DockStyle.Left;
                frmBL.Controls.Add(panelBL);
                frmBL.Size = new System.Drawing.Size(510, 350);
            }
            panelBL.Visible = true;
            frmBL.ShowDialog();
        }

        Form frmTT = null;
        public void showFormTT()
        {
            txtTenThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenThuoc.AutoCompleteCustomSource = daoTHUOC.getDSTHUOC_TOA();

            txtSoNgay.Text = "0";
            txtSang.Text = "0";
            txtTrua.Text = "0";
            txtChieu.Text = "0";
            txtToi.Text = "0";
            if (frmTT == null)
            {
                frmTT = new Form();
                frmTT.Text = "TOA THUỐC";
                frmTT.MaximizeBox = false;
                frmTT.MinimizeBox = false;
                frmTT.BackColor = Color.White;
                frmTT.FormClosing += frmTT_Closing;
                frmTT.StartPosition = FormStartPosition.CenterScreen;
                frmTT.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                panelTT.Dock = DockStyle.Top | DockStyle.Left;
                frmTT.Controls.Add(panelTT);
                frmTT.Size = new System.Drawing.Size(840, 470);
            }
            panelTT.Visible = true;
            dieukien2 = false;
            frmTT.ShowDialog();
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            //xuLyControl(false);
            //sua(true);
        }

        void resetTXTTT()
        {
            txtTenThuoc.Text = "";
            txtDVT.Text = "";
            txtCachDung.Text = "";
            txtSoNgay.Text = "";
            txtSang.Text = "";
            txtTrua.Text = "";
            txtChieu.Text = "";
            txtToi.Text = "";
        }

        private void frmTT_Closing(object sender, FormClosingEventArgs e)
        {
            resetTXTTT();
            //gcThuoc.DataSource = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bl = 1;
            showFormBL();
            
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            if(bl == 1)
            {
                txtMaICD.Text = gridView4.GetFocusedRowCellValue("BL_ID").ToString();
                txtICD.Text = gridView4.GetFocusedRowCellValue("BL_TEN").ToString();
            }
            else if(bl == 2)
            {
                txtMaBP.Text = gridView4.GetFocusedRowCellValue("BL_ID").ToString();
                txtBenhphu.Text = gridView4.GetFocusedRowCellValue("BL_TEN").ToString();
            }
            
        }

        private void btnBP_Click(object sender, EventArgs e)
        {
            bl = 2;
            showFormBL();
            
        }

        private TOA_THUOC LayTTTT()
        {
            string kbid = txtIdTT.Text;
            string ten = "";
            string loidan = txtLoiDan.Text;
            int tt = 1;

            TOA_THUOC t = new TOA_THUOC(kbid, ten, loidan, tt);
            return t;
        }

        private CT_TOATHUOC LayCTTT()
        {
            CT_TOATHUOC t = new CT_TOATHUOC();
            int id = daoTT.getIDTT_MAX();
            int idtt = id;
            t.Id_tt = idtt;
            t.Id_thuoc = daoTHUOC.getIDTHUOCbyTEN(txtTenThuoc.Text);
            t.Ctt_songayuong = int.Parse(txtSoNgay.Text);
            t.Ctt_cachdung = txtCachDung.Text;
            t.Ctt_sang = int.Parse(txtSang.Text);
            t.Ctt_trua = int.Parse(txtTrua.Text);
            t.Ctt_chieu = int.Parse(txtChieu.Text);
            t.Ctt_toi = int.Parse(txtToi.Text);
            int sl = int.Parse(txtSL.Text);
            t.Ctt_sl = sl;
            t.Ctt_dongia = float.Parse(txtDonGia.Text);
            t.Ctt_thanhtien = float.Parse(txtThanhTien.Text);
            return t;
        }


        private KHAM_BENH LayTTKB()
        {
            string kbid = daoKB.insertMaKB(txtMaBN2.Text);
            txtIdTT.Text = kbid;
            string tnid = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            DateTime htk = Convert.ToDateTime(DateTK.Text);
            string htk2 = htk.ToShortDateString();
            string ngay2 = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            //string ngay2 = ngay.ToLongDateString();
            int tt = 1;
            string kl = txtKetluan.Text;

            KHAM_BENH t = new KHAM_BENH(kbid, tnid, htk2, ngay2, tt, kl);
            return t;
        }

        private KHAM_BENH LayTTKB_SUA()
        {
            string kbid = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
            string tnid = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            DateTime htk = Convert.ToDateTime(DateTK.Text);
            string htk2 = htk.ToShortDateString();
            DateTime ngay = System.DateTime.Now;
            string ngay2 = ngay.ToLongDateString();
            int tt = 1;
            string kl = txtKetluan.Text;

            KHAM_BENH t = new KHAM_BENH(kbid, tnid, htk2, ngay2, tt, kl);
            return t;
        }

        private KHAM_BENH LayTTKB_HT()
        {
            string kbid = daoKB.insertMaKB(txtMaBN2.Text);
            string tnid = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            DateTime htk = Convert.ToDateTime(DateTK.Text);
            string htk2 = htk.ToShortDateString();
            DateTime ngay = System.DateTime.Now;
            string ngay2 = ngay.ToLongDateString();
            int tt = 2;
            string kl = txtKetluan.Text;

            KHAM_BENH t = new KHAM_BENH(kbid, tnid, htk2, ngay2, tt, kl);
            return t;
        }

        private PHIEU_TIEP_NHAN LayTTPTN_DK()
        {
            string ma = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            int idnv = 2;
            int idbn = int.Parse(txtMaBN2.Text);
            string idbs = "2";
            int idbs2 = int.Parse(idbs);
            int stt = int.Parse(txtSTT2.Text);
            string dvk = "";
            int tuoithang = int.Parse(txtTuoithang2.Text);
            int tuoinam = int.Parse(txtTuoinam2.Text);
            string ngaygio = System.DateTime.Now.ToShortDateString();
            //string ngaygio = DateNgayhen.Text;
            float mach = float.Parse(txtMach.Text);
            float nhietdo = float.Parse(txtNhietdo.Text);
            float nhiptho = float.Parse(txtNhiptho.Text);
            //float huyetap = float.Parse(txtHuyetap.Text);
            float chieucao = float.Parse(txtChieucao.Text);
            float cannang = float.Parse(txtCannang.Text);
            string huyetap = txtHuyetap.Text + "/" + txtHuyetap2.Text;
            float bmi = float.Parse(txtBMI.Text);
            int tt = 1;

            PHIEU_TIEP_NHAN t = new PHIEU_TIEP_NHAN(ma, idnv, idbn, stt, idbs2, dvk, tuoithang, tuoinam, ngaygio, mach, nhietdo, nhiptho, huyetap, chieucao, cannang, bmi, tt);

            return t;
        }

        private PHIEU_TIEP_NHAN LayTTPTN_KX()
        {
            string ma = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            int idnv = 2;
            int idbn = int.Parse(txtMaBN2.Text);
            string idbs = gridView3.GetFocusedRowCellValue("NV_ID").ToString();
            int idbs2 = int.Parse(idbs);
            int stt = int.Parse(txtSTT2.Text);
            string dvk = "";
            int tuoithang = int.Parse(txtTuoithang2.Text);
            int tuoinam = int.Parse(txtTuoinam2.Text);
            string ngaygio = System.DateTime.Now.ToShortDateString();
            //string ngaygio = DateNgayhen.Text;
            float mach = float.Parse(txtMach.Text);
            float nhietdo = float.Parse(txtNhietdo.Text);
            float nhiptho = float.Parse(txtNhiptho.Text);
            //float huyetap = float.Parse(txtHuyetap.Text);
            float chieucao = float.Parse(txtChieucao.Text);
            float cannang = float.Parse(txtCannang.Text);
            string huyetap = txtHuyetap.Text + "/" + txtHuyetap2.Text;
            float bmi = float.Parse(txtBMI.Text);
            int tt = 2;

            PHIEU_TIEP_NHAN t = new PHIEU_TIEP_NHAN(ma, idnv, idbn, stt, idbs2, dvk, tuoithang, tuoinam, ngaygio, mach, nhietdo, nhiptho, huyetap, chieucao, cannang, bmi, tt);

            return t;
        }

        private CT_BENHLY LayTTCTBL()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_bl = txtMaICD.Text;
            t.Id_kb = txtIdTT.Text;
            t.Ctbl_chuyenmon = txtChuyenmon.Text;
            t.Ctbl_mucdo = txtMucdo.Text;
            t.Ctbl_trangthai = 1;
            return t;
        }

        private CT_BENHLY LayTTCTBL_SUA()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_bl = txtMaICD.Text;
            t.Id_kb = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
            t.Ctbl_chuyenmon = txtChuyenmon.Text;
            t.Ctbl_mucdo = txtMucdo.Text;
            t.Ctbl_trangthai = 1;
            return t;
        }

        private CT_BENHLY LayTTCTBL_P()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_bl = txtMaBP.Text;
            t.Id_kb = txtIdTT.Text;
            t.Ctbl_chuyenmon = "";
            t.Ctbl_mucdo = "";
            t.Ctbl_trangthai = 2;
            return t;
        }

        private CT_BENHLY LayTTCTBL_P_SUA()
        {
            CT_BENHLY t = new CT_BENHLY();
            t.Id_bl = txtMaBP.Text;
            t.Id_kb = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
            t.Ctbl_chuyenmon = "";
            t.Ctbl_mucdo = "";
            t.Ctbl_trangthai = 2;
            return t;
        }

        private void btnKham_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(txtMaBN2.Text);
            KHAM_BENH t = LayTTKB();
            dieukien = true;
            string dk = dieukien.ToString();
            xuly(true);
            btnKetoa.Enabled = false;
            btnSua.Enabled = false;

            //if (daoKB.InsertKB(t))
            //{
            //    MessageBox.Show(txtIdTT.Text);
            //}

        }

        private void btnHuy2_Click(object sender, EventArgs e)
        {
            if (cbTT.Text == "Chờ khám")
            {
                btnKham.Enabled = true;
                btnSua.Enabled = false;
                //DateChonNgay.Enabled = false;
                loadPTN();
                reset();
            }
            else if (cbTT.Text == "Đang khám")
            {

                reset();
                //DateChonNgay.Enabled = true;
                loadKB_NGAY_DK();
                btnKham.Enabled = false;
                btnSua.Enabled = true;
                btnICD.Enabled = true;
                btnBP.Enabled = true;

            }
            else if (cbTT.Text == "Đã khám")
            {
                btnKham.Enabled = false;
                btnSua.Enabled = true;
                btnICD.Enabled = true;
                btnBP.Enabled = true;
                //DateChonNgay.Enabled = false;
                loadKB_NGAY_KX();
                reset();
            }
            else
            {
                loadKB_NGAY();
                reset();
            }
            
            //xuly(false);
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            KHAM_BENH t = LayTTKB();
            
            CT_BENHLY c = LayTTCTBL();
            CT_BENHLY cp = LayTTCTBL_P();
            btnKetoa.Enabled = true;
            
            PHIEU_TIEP_NHAN p = LayTTPTN_DK();
            if(dieukien == true)
            {
                if(daoKB.InsertKB(t))
                {
                    if(txtMaICD.Text == "" || txtICD.Text == "")
                    {
                        MessageBox.Show("Chưa nhập chuẩn đoán ICD");
                    }
                    else
                    {
                        daoCTBL.InsertCTBL(c);
                        daoCTBL.InsertCTBL(cp);
                        daoPTN.UpdatePTN_DK(p);
                        MessageBox.Show("Lưu thành công");
                        xuly(false);
                        btnKham.Enabled = true;
                    }
                }
            }
            else
            {
                KHAM_BENH s = LayTTKB_SUA();
                CT_BENHLY cs = LayTTCTBL_SUA();
                CT_BENHLY cps = LayTTCTBL_P_SUA();
                if (daoKB.UpdateKB(s))
                {
                    if (txtMaICD.Text == "" || txtICD.Text == "")
                    {
                        MessageBox.Show("Chưa nhập chuẩn đoán ICD");
                    }
                    else
                    {
                        daoCTBL.deleteCTBL(cs);
                        daoCTBL.InsertCTBL(cs);
                        daoCTBL.deleteCTBL(cps);
                        daoCTBL.InsertCTBL(cps);
                        daoPTN.UpdatePTN_DK(p);
                        MessageBox.Show("Lưu thành công");
                        btnLuu2.Enabled = false;
                        xuly(false);
                        btnKham.Enabled = false;
                        btnSua.Enabled = true;
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuly(true);
            btnKham.Enabled = false;
            btnSua.Enabled = false;
            dieukien = false;
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void txtMaICD_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if(txtMaICD.Text != "")
            {
                txtICD.Enabled = false;
                string tk = txtMaICD.Text;
                txtICD.Text = daoBL.TimBL(tk);
            }
            //else
            //{
            //    txtICD.Enabled = true;
            //}
        }

        private void txtICD_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            if(cbTT.Text == "Chờ khám")
            {
                txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
                txtMach.Text = gridView3.GetFocusedRowCellValue("TN_MACH").ToString();
                txtNhietdo.Text = gridView3.GetFocusedRowCellValue("TN_NHIETDO").ToString();
                txtNhiptho.Text = gridView3.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
                //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                string ha = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                string[] ha_split = ha.Split('/');
                txtHuyetap.Text = ha_split[0];
                txtHuyetap2.Text = ha_split[1];

                txtChieucao.Text = gridView3.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
                txtCannang.Text = gridView3.GetFocusedRowCellValue("TN_CANNANG").ToString();
                txtBMI.Text = gridView3.GetFocusedRowCellValue("TN_BMI").ToString();

                gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));
            }
            else if(cbTT.Text == "Đang khám")
            {
                txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
                txtMach.Text = gridView3.GetFocusedRowCellValue("TN_MACH").ToString();
                txtNhietdo.Text = gridView3.GetFocusedRowCellValue("TN_NHIETDO").ToString();
                txtNhiptho.Text = gridView3.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
                //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                string ha = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                string[] ha_split = ha.Split('/');
                txtHuyetap.Text = ha_split[0];
                txtHuyetap2.Text = ha_split[1];

                txtChieucao.Text = gridView3.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
                txtCannang.Text = gridView3.GetFocusedRowCellValue("TN_CANNANG").ToString();
                txtBMI.Text = gridView3.GetFocusedRowCellValue("TN_BMI").ToString();
                string kb = gridView3.GetFocusedRowCellValue("KB_ID").ToString();
                string icd = daoKB.getBL_ICD(kb);
                string[] icd_split = icd.Split('/');
                txtMaICD.Text = icd_split[0];
                txtICD.Text = icd_split[1];
                txtChuyenmon.Text = icd_split[2];
                txtMucdo.Text = icd_split[3];

                string bp = daoKB.getBL_PHU(kb);
                string[] bp_split = bp.Split('/');
                txtMaBP.Text = bp_split[0];
                txtBenhphu.Text = bp_split[1];

                gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));
            }
            else if(cbTT.Text == "Đã khám")
            {
                txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                //txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                //DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                //cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
                txtMach.Text = gridView3.GetFocusedRowCellValue("TN_MACH").ToString();
                txtNhietdo.Text = gridView3.GetFocusedRowCellValue("TN_NHIETDO").ToString();
                txtNhiptho.Text = gridView3.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
                //txtHuyetap.Text = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                string ha = gridView3.GetFocusedRowCellValue("TN_HUYETAP").ToString();
                string[] ha_split = ha.Split('/');
                txtHuyetap.Text = ha_split[0];
                txtHuyetap2.Text = ha_split[1];

                txtChieucao.Text = gridView3.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
                txtCannang.Text = gridView3.GetFocusedRowCellValue("TN_CANNANG").ToString();
                txtBMI.Text = gridView3.GetFocusedRowCellValue("TN_BMI").ToString();
                txtICD.Text = gridView3.GetFocusedRowCellValue("BL_TEN").ToString();
                txtMaICD.Text = gridView3.GetFocusedRowCellValue("BL_ID").ToString();

                gdToa.DataSource = daoTT.getTTbyBN(int.Parse(gridView3.GetFocusedRowCellValue("BN_ID").ToString()));
            }
            
        }

        private void btnKetoa_Click(object sender, EventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            showFormTT();
            if(themtt == false)
            {
                daoTT.InsertTT(t);
                themtt = true;
                MessageBox.Show(daoTT.getIDTT_MAX().ToString());
            }
        }

        private void txtTenThuoc_TextChanged(object sender, EventArgs e)
        {
            string tt = txtTenThuoc.Text;
            string dvt_cd = daoTHUOC.getDVT_CD_GIA(tt);
            string[] dvt_cd_split = dvt_cd.Split('/');
            txtDVT.Text = dvt_cd_split[0];
            txtCachDung.Text = dvt_cd_split[1];
            txtDonGia.Text = dvt_cd_split[2];
        }

        private void txtTenThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSoNgay.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {
                txtSoNgay.Focus();
            }
        }

        private void txtSoNgay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                txtSang.Focus();
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
            }

            if (e.KeyCode == Keys.Tab)
            {

                txtSang.Focus();
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
            }
        }

        private void txtSang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtTrua.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtTrua.Focus();
            }
        }

        private void txtTrua_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtChieu.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtChieu.Focus();
            }
        }

        private void txtChieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtToi.Focus();
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                int tt = slg * dg;

                txtSL.Text = slg.ToString();
                txtThanhTien.Text = tt.ToString();
                txtToi.Focus();
            }
        }

        private void txtToi_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void txtSoNgay_EditValueChanged(object sender, EventArgs e)
        {
            if(txtSoNgay.Text == "")
            {
                txtSoNgay.Text = "0";
            }
        }

        private void txtSang_EditValueChanged(object sender, EventArgs e)
        {
            if(txtSang.Text == "")
            {
                txtSang.Text = "0";
            }
        }

        private void txtTrua_EditValueChanged(object sender, EventArgs e)
        {
            if(txtTrua.Text == "")
            {
                txtTrua.Text = "0";
            }
        }

        private void txtChieu_EditValueChanged(object sender, EventArgs e)
        {
            if(txtChieu.Text == "")
            {
                txtChieu.Text = "0";
            }
        }

        private void txtToi_EditValueChanged(object sender, EventArgs e)
        {
            if(txtToi.Text == "")
            {
                txtToi.Text = "0";
            }
        }

        private void txtToi_KeyDown_1(object sender, KeyEventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            CT_TOATHUOC ct = LayCTTT();
            if (e.KeyCode == Keys.Enter)
            {
                
                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();
                txtSL.Focus();
                
                //daoCTTT.InsertCTTT(ct);
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                //MessageBox.Show("Thêm thành công");
                    
            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();
                txtSL.Focus();

                //daoCTTT.InsertCTTT(ct);
                //gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                //MessageBox.Show("Thêm thành công");

            }
        }

        private void txtSL_KeyDown(object sender, KeyEventArgs e)
        {
            TOA_THUOC t = LayTTTT();
            CT_TOATHUOC ct = LayCTTT();
            if (e.KeyCode == Keys.Enter)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();

                daoCTTT.InsertCTTT(ct);
                gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                //MessageBox.Show("Thêm thành công");

            }

            if (e.KeyCode == Keys.Tab)
            {

                int sn = int.Parse(txtSoNgay.Text);
                int sang = int.Parse(txtSang.Text);
                int trua = int.Parse(txtTrua.Text);
                int chieu = int.Parse(txtChieu.Text);
                int toi = int.Parse(txtToi.Text);
                int slg = sn * (sang + trua + chieu + toi);
                int dg = int.Parse(txtDonGia.Text);
                float ttien = slg * dg;
                txtSL.Text = slg.ToString();
                txtThanhTien.Text = ttien.ToString();

                daoCTTT.InsertCTTT(ct);
                gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                //MessageBox.Show("Thêm thành công");

            }
        }

        private void gridView5_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            delete = true;
        }

        private void gridView5_KeyDown(object sender, KeyEventArgs e)
        {
            if(delete == true)
            {
                try
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa thuốc '" + gridView5.GetFocusedRowCellValue("THUOC_TEN").ToString() + "' trong toa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        daoCTTT.xoaCT_TOATHUOC(gridView5.GetFocusedRowCellValue("THUOC_ID").ToString());
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(daoTT.getIDTT_MAX().ToString());
                    }
                }
                catch
                {
                    //MessageBox.Show("Không thể xóa loại bệnh lý '" + lbTen.Text + "' vì có bệnh lý thuộc loại bệnh lý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gdToa_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            gcThuoc.DataSource = daoCTTT.getCT_TOATHUOCbyID(gridView1.GetFocusedRowCellValue("TT_ID").ToString());
            showFormTT();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            intoathuoc();
        }

        

        void intoathuoc()
        {
            rptToaThuoc tt = new rptToaThuoc();
            tt.lbTenBN.Text = txtTen2.Text;
            tt.lbDiaChi.Text = txtDiachi2.Text;
            tt.lbICD.Text = txtICD.Text;
            tt.lbNgay.Text = DateTime.Now.Day.ToString();
            tt.lbThang.Text = DateTime.Now.Month.ToString();
            tt.lbNam.Text = DateTime.Now.Year.ToString();
            tt.lbTuoi.Text = txtTuoinam2.Text;
            tt.lbGioiTinh.Text = cbGioitinh2.Text;
            tt.lbTenBS.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
            tt.DataSource = gcThuoc.DataSource;
            tt.BindData();
            //printControl1.PrintingSystem = tt.PrintingSystem;
            tt.CreateDocument();
            tt.ShowPreviewDialog();
        }
    }
}
