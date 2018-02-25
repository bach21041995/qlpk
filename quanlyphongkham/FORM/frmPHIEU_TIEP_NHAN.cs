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
    public partial class frmPHIEU_TIEP_NHAN : Form
    {
        public frmPHIEU_TIEP_NHAN()
        {
            InitializeComponent();
        }

        DAO_PHIEU_TIEP_NHAN daoPTN = new DAO_PHIEU_TIEP_NHAN();
        DAO_BENH_NHAN daoBN = new DAO_BENH_NHAN();
        DAO_NHAN_VIEN daoNV = new DAO_NHAN_VIEN();
        //DAO_NGAY daoNgay = new DAO_NGAY();
        ConnectionDatabase connecDB = new ConnectionDatabase();
        bool dieukien = true;

        bool dieukien2 = true;

        void loadPTN()
        {
            DateTime ht = System.DateTime.Now;
            string ngay = ht.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoPTN.getPTN_NGAY(ngay);

            //gdPTN.DataSource = daoPTN.getDSPTN();
        }

        void loadPTN_DL()
        {
            DateTime dt = Convert.ToDateTime(DateChonNgay.Text);
            string ngay = dt.ToShortDateString();
            ngay = ngay.Replace("/", "");

            gdPTNH.DataSource = daoPTN.getPTN_NGAY(ngay);
        }
        void loadPTNH()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN();
        }

        void loadPTN_ALL()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN_ALL();
        }


        void loadPTN_DK()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN_DK();
        }

        void loadPTN_KX()
        {
            gdPTNH.DataSource = daoPTN.getDSPTN_KX();
        }


        public void loadData2()
        {
            //cbLT.DataSource = daoThuoc.getLT();
            //cbLT.DisplayMember = "LT_TEN";
            //cbLT.ValueMember = "LT_ID";
            //cbLT.Items.Insert(0, "Tất cả");
            //cbLT.SelectedIndex = 0;
            cbBSK2.DataSource = daoNV.getDSBS();
            cbBSK2.DisplayMember = "NV_HOTEN";
            cbBSK2.ValueMember = "NV_ID";

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

            items3.Add(new KeyValuePair<string, string>("TT", "Trực tiếp"));
            items3.Add(new KeyValuePair<string, string>("DL", "Đặt lịch"));
            items3.Add(new KeyValuePair<string, string>("DK", "Đang khám"));
            items3.Add(new KeyValuePair<string, string>("KX", "Đã khám"));
            items3.Add(new KeyValuePair<string, string>("TC", "Tất cả"));

            cbTT.DataSource = items3;
            cbTT.ValueMember = "Key";
            cbTT.DisplayMember = "Value";
        }

        void binding()
        {
            //cbLT.DataBindings.Clear();
            //cbLT.DataBindings.Add("SelectedValue", gcThuoc.DataSource, "LT_ID");
        }

        

        void xuLyControl(bool b)
        {
            btnLap.Enabled = !b;
            btnDat.Enabled = !b;
            btnSua.Enabled = !b;
            btnXoa.Enabled = !b;
            //btnXoa.Enabled = !b;
            //pnEdit.Enabled = b;
           // btnLuu.Visible = b;
           // btnHuy.Visible = b;

           
            //btnThemTiep.Visible = b;
        }

        void btnCapnhat(bool b)
        {
            btnSua.Enabled = b;
        }

        void xuly2(bool b)
        {
            txtTen2.Enabled = b;
            txtSDT2.Enabled = b;
            txtCMT2.Enabled = b;
            txtDiachi2.Enabled = b;
            txtTen2.Enabled = b;
            txtTuoinam2.Enabled = b;
            txtTuoithang2.Enabled = b;
            DateNS2.Enabled = b;
            //DateNgayGio.Enabled = b;
            cbBSK2.Enabled = b;
            cbGioitinh2.Enabled = b;
            cbNhommau.Enabled = b;
            txtMach.Enabled = b;
            txtNhietdo.Enabled = b;
            txtNhiptho.Enabled = b;
            txtHuyetap.Enabled = b;
            txtChieucao.Enabled = b;
            txtCannang.Enabled = b;
            txtHuyetap2.Enabled = b;
            txtBMI.Enabled = b;
            

        }

        void xulyBtn(bool b)
        {
            btnLuu2.Enabled = b;
            btnHuy2.Enabled = b;
        }



        

        void resetText2()
        {
            txtMa2.Text = "";
            txtSTT2.Text = "";
            txtTen2.Text = "";
            txtCMT2.Text = "";
            txtSDT2.Text = "";
            txtDiachi2.Text = "";
            txtTuoithang2.Text = "";
            txtTuoinam2.Text = "";
            txtMach.Text = "";
            txtNhiptho.Text = "";
            txtNhietdo.Text = "";
            txtHuyetap.Text = "";
            txtHuyetap2.Text = "";
            txtChieucao.Text = "";
            txtCannang.Text = "";
            txtBMI.Text = "";
        }



        //private NGAY LayNgay()
        //{
        //    DateTime dt = Convert.ToDateTime(DateNgayhen.Text);
        //    string ngayid = dt.ToShortDateString();
        //    ngayid = ngayid.Replace("/", "");
        //    DateTime dt2 = Convert.ToDateTime(DateNgayhen.Text);
        //    string ngay = dt2.ToShortDateString();

        //    NGAY n = new NGAY(ngayid, ngay);
        //    return n;
        //}

        private BENH_NHAN LayTTBN_DAT()
        {
            int id = int.Parse(txtMaBN2.Text);
            string ht = txtTen2.Text;
            string cmt = txtCMT2.Text;
            string sdt = txtSDT2.Text;
            string dc = txtDiachi2.Text;
            DateTime dt = Convert.ToDateTime(DateNS2.Text);
            string ngaysinh = dt.ToShortDateString();
            int gioitinh = (cbGioitinh2.Text == "Nam") ? 1 : 0;
            string nhommau = "";
            int tt = 1;

            BENH_NHAN t = new BENH_NHAN(id, ht, cmt, sdt, dc, ngaysinh, gioitinh, nhommau, tt);
            return t;
        }

        private BENH_NHAN LayTTBN()
        {
            int id = int.Parse(txtMaBN2.Text);
            string ht = txtTen2.Text;
            string cmt = txtCMT2.Text;
            string sdt = txtSDT2.Text;
            string dc = txtDiachi2.Text;
            DateTime dt = Convert.ToDateTime(DateNS2.Text);
            string ngaysinh = dt.ToShortDateString();
            int gioitinh = (cbGioitinh2.Text == "Nam") ? 1 : 0;
            string nhommau = cbNhommau.Text;
            int tt = 1;

            BENH_NHAN t = new BENH_NHAN(id, ht, cmt, sdt, dc, ngaysinh, gioitinh, nhommau, tt);
            return t;
        }

        private PHIEU_TIEP_NHAN LayTTPTN_DAT()
        {
            string ma = txtMa2.Text;
            int idnv = frmDANG_NHAP.idnv;
            int idbn = int.Parse(txtMaBN2.Text);
            string idbs = cbBSK2.SelectedValue.ToString();
            int idbs2 = int.Parse(idbs);
            int stt = int.Parse(txtSTT2.Text);
            string dvk = "";
            int tuoithang = int.Parse(txtTuoithang2.Text);
            int tuoinam = int.Parse(txtTuoinam2.Text);
            DateTime dt = Convert.ToDateTime(DateNgayhen.Text);
            string ngaygio = dt.ToShortDateString();
            //string ngaygio = DateNgayhen.Text;
            float mach = 0;
            float nhietdo = 0;
            float nhiptho = 0;
            string huyetap = "0";
            float chieucao = 0;
            float cannang = 0;
            float bmi = 0;
            int tt = 0;

            PHIEU_TIEP_NHAN t = new PHIEU_TIEP_NHAN(ma, idnv, idbn, stt, idbs2, dvk, tuoithang, tuoinam, ngaygio, mach, nhietdo, nhiptho, huyetap, chieucao, cannang, bmi, tt);

            return t;
        }

        private PHIEU_TIEP_NHAN LayTTPTN()
        {
            string ma = txtMa2.Text;
            int idnv = 1;
            int idbn = int.Parse(txtMaBN2.Text);
            string idbs = cbBSK2.SelectedValue.ToString();
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
            int tt = 0;

            PHIEU_TIEP_NHAN t = new PHIEU_TIEP_NHAN(ma, idnv, idbn, stt, idbs2, dvk, tuoithang, tuoinam, ngaygio, mach, nhietdo, nhiptho, huyetap, chieucao, cannang, bmi, tt);

            return t;
        }

        Form frm = null;
        public void showFormThongTin_DAT()
        {
            //DateNS_ValueChanged(null, null);
            //DateNgayhen_ValueChanged_1(null, null);
            //cbGioiTinh.SelectedIndex = 0;
            //cbLT2_SelectedIndexChanged(null, null);
            //cbbDT_SelectedIndexChanged(null, null);
            //if (frm == null)
            //{
            //    frm = new Form();
            //    frm.Text = "THÔNG TIN ĐẶT LỊCH HẸN KHÁM";
            //    frm.MaximizeBox = false;
            //    frm.MinimizeBox = false;
            //    frm.BackColor = Color.White;
            //    frm.FormClosing += frm_Closing;
            //    frm.StartPosition = FormStartPosition.CenterScreen;
            //    frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //    pnEdit.Dock = DockStyle.Top | DockStyle.Left;
            //    frm.Controls.Add(pnEdit);
            //    frm.Size = new System.Drawing.Size(672, 400);
            //}
            //pnEdit.Visible = true;
            //frm.ShowDialog();
        }

        
        public void showFormThongTin()
        {
            //DateNS2_ValueChanged(null, null);
            //DateNgayhen_ValueChanged_1(null, null);
            //cbGioiTinh.SelectedIndex = 0;
            //cbLT2_SelectedIndexChanged(null, null);
            //cbbDT_SelectedIndexChanged(null, null);
            if (dieukien == true)
            {
                string ngay = System.DateTime.Now.ToShortDateString();
                ngay = ngay.Replace("/", "");

                txtMa2.Text = daoPTN.insertMaPTN(ngay);
                string stt = txtMa2.Text.Substring(8);
                txtSTT2.Text = stt;
            }
            

            
        }

        //Form frm3 = null;
        //public void showFormThongTin_SUA()
        //{
        //    //DateNgayhen_ValueChanged_1(null, null);
        //    //cbGioiTinh.SelectedIndex = 0;
        //    //cbLT2_SelectedIndexChanged(null, null);
        //    //cbbDT_SelectedIndexChanged(null, null);
        //    if (frm3 == null)
        //    {
        //        frm3 = new Form();
        //        frm3.Text = "THÔNG TIN ĐẶT PHIẾU TIẾP NHẬN";
        //        frm3.MaximizeBox = false;
        //        frm3.MinimizeBox = false;
        //        frm3.BackColor = Color.White;
        //        frm3.FormClosing += frm3_Closing;
        //        frm3.StartPosition = FormStartPosition.CenterScreen;
        //        frm3.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        //        pnEdit4.Dock = DockStyle.Top | DockStyle.Left;
        //        frm3.Controls.Add(pnEdit);
        //        frm3.Size = new System.Drawing.Size(857, 400);
        //    }
        //    pnEdit4.Visible = true;
        //    frm3.ShowDialog();
        //}

        void loadMaBN()
        {
            string mabn2 = daoBN.getIDBN_max();
            int mabn2_int = int.Parse(mabn2) + 1;
            string mabn2_next = mabn2_int.ToString();
            txtMaBN2.Text = mabn2_next;
        }
        
        

        private void frmPHIEU_TIEP_NHAN_Load(object sender, EventArgs e)
        {
            loadPTNH();
            DateNgayhen.Enabled = false;
            DateChonNgay_ValueChanged(null, null);

            loadMaBN();
            xuly2(false);
            xulyBtn(false);
            loadPTN();
            
            loadData2();
            btnCapnhat(false);
            //xuly(false);
            //string mabn = daoBN.getIDBN_max();
            //int mabn_int = int.Parse(mabn) + 1;
            //string mabn_next = mabn_int.ToString();
            //txtMaBN.Text = mabn_next;



            //string mabn2 = daoBN.getIDBN_max();
            //int mabn2_int = int.Parse(mabn2) + 1;
            //string mabn2_next = mabn2_int.ToString();
            //txtMaBN2.Text = mabn2_next;
            

            //gridView2_FocusedRowChanged(null, null);
            gridView3_FocusedRowChanged(null, null);

        }

        

        

        private void btnDat_Click_1(object sender, EventArgs e)
        {
            lbPTN.Text = "ĐẶT LỊCH KHÁM BỆNH";
            resetText2();
            DateNgayhen.Enabled = true;
            xuly2(false);
            btnLuu2.Enabled = false;
            btnHuy2.Enabled = true;
            xuLyControl(true);
            dieukien = true;
            dieukien2 = false;
            //btnThemTiep.Enabled = true;
            //cbBSK.Enabled = true;
            showFormThongTin_DAT();
            
            loadMaBN();
            //BMI();

            //cbLT2_SelectedIndexChanged(sender, e);
            //DateNgayhen_ValueChanged_1(sender, e);
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            xuLyControl(false);
            dieukien2 = false;
            //DateNgayhen_ValueChanged_1(sender, e);
            //sua(true);
            //resetText();
            frm.Visible = false;
        }

        //private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        //{
        //    try
        //    {
                
        //            lbMa.Text = gridView2.GetFocusedRowCellValue("TN_ID").ToString();
        //            txtMa2.Text = gridView2.GetFocusedRowCellValue("TN_ID").ToString();
        //            txtSTT2.Text = gridView2.GetFocusedRowCellValue("TN_STT").ToString();
        //            txtMaBN2.Text = gridView2.GetFocusedRowCellValue("BN_ID").ToString();
        //            txtTen2.Text = gridView2.GetFocusedRowCellValue("BN_HOTEN").ToString();
        //            txtCMT2.Text = gridView2.GetFocusedRowCellValue("BN_CMT").ToString();
        //            txtSDT2.Text = gridView2.GetFocusedRowCellValue("BN_SDT").ToString();
        //            txtDiachi2.Text = gridView2.GetFocusedRowCellValue("BN_DIACHI").ToString();
        //            DateNS2.Text = gridView2.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
        //            cbGioitinh2.Text = gridView2.GetFocusedRowCellValue("BN_GIOITINH").ToString();
        //            txtTuoithang2.Text = gridView2.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
        //            txtTuoinam2.Text = gridView2.GetFocusedRowCellValue("TN_TUOINAM").ToString();
        //            cbBSK2.Text = gridView2.GetFocusedRowCellValue("TN_BSKHAM").ToString();
        //            txtMach.Text = gridView2.GetFocusedRowCellValue("TN_MACH").ToString();
        //            txtNhietdo.Text = gridView2.GetFocusedRowCellValue("TN_NHIETDO").ToString();
        //            txtNhiptho.Text = gridView2.GetFocusedRowCellValue("TN_NHIPTHO").ToString();
        //            txtHuyetap.Text = gridView2.GetFocusedRowCellValue("TN_HUYETAP").ToString();
        //            txtChieucao.Text = gridView2.GetFocusedRowCellValue("TN_CHIEUCAO").ToString();
        //            txtCannang.Text = gridView2.GetFocusedRowCellValue("TN_CANNANG").ToString();
                
                
        //    }
        //    catch
        //    {

        //    }

        //}

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //if(dieukien == false)
                //{
                    lbMa.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
                    txtMa2.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
                    txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
                    txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
                    txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
                    txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
                    txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
                    txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
                    DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
                    cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
                    cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
                    txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
                    txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
                    cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
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
                //}

            }
            catch
            {

            }

        }

        private void DateNgayhen_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(DateNgayhen.Text);
                string ngay = dt.ToShortDateString();
                ngay = ngay.Replace("/", "");

                if (dt >= DateTime.Now)
                {
                    //if (dieukien == true)
                    //{
                    txtMa2.Text = daoPTN.insertMaPTN(ngay);
                    string stt = txtMa2.Text.Substring(8);
                    txtSTT2.Text = stt;
                       
                    xuly2(true);
                    xulyBtn(true);
                    //}
                    //else
                    //{
                    //    txtMa2.Text = gridView2.GetFocusedRowCellValue("TN_ID").ToString();
                    //    txtMa2.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
                    //}
                }
                else
                {
                    MessageBox.Show("Ngày đặt phải lớn hơn ngày hiện tại!!");
                    
                    //resetText();
                }
            }
            catch
            {
            }
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            BENH_NHAN b = LayTTBN_DAT();
            PHIEU_TIEP_NHAN t = LayTTPTN_DAT();
            if (dieukien)
            {
                if(daoBN.InsertBN(b))
                {
                    if (daoPTN.InsertPTN(t))
                    {
                        MessageBox.Show("Thêm thành công");
                        loadPTNH();
                        loadPTN();
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                        frm.Visible = false;
                        //resetText();
                    }
                }
                else
                {
                    
                }
                
            }
            else
            {
                //if (daoPTN.UpdatePTN(t))
                //{
                //    MessageBox.Show("Sửa thành công");
                //    loadThuoc();
                //    xuLyControl(false);
                //    //txtMa.Enabled = true;
                //    frm.Visible = false;
                //    resetText();
                //    //sua(true);
                //}
            }
        }

        private void DateChonNgay_ValueChanged(object sender, EventArgs e)
        {
            loadPTN_DL();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            lbPTN.Text = "LẬP PHIẾU TIẾP NHẬN";
            resetText2();
            xuly2(true);
            xulyBtn(true);
            xuLyControl(true);
            dieukien = true;
            dieukien2 = true;
            DateNgayhen.Enabled = false;
            showFormThongTin();
            loadData2();
            loadMaBN();
        }

        private void btnHuy2_Click(object sender, EventArgs e)
        {
            lbPTN.Text = "THÔNG TIN PHIẾU TIẾP NHẬN";
            gridView3_FocusedRowChanged(null, null);
            xuLyControl(false);
            //sua(true);
            xuly2(false);
            xulyBtn(false);
            btnCapnhat(false);
            DateNgayhen.Enabled = false;
            //frm2.Visible = false;
            if (dieukien==true)
            {
                resetText2();
            }
            else
            {

            }
           
        }

        private void btnLuu2_Click(object sender, EventArgs e)
        {
            BENH_NHAN b = LayTTBN();
            PHIEU_TIEP_NHAN t = LayTTPTN();
            if (dieukien == true)
            {
                if (daoBN.InsertBN(b))
                {
                    if (daoPTN.InsertPTN(t))
                    {
                        MessageBox.Show("Thêm thành công");
                        loadPTN();
                        //loadPTNH();
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                        //frm2.Visible = false;
                        //resetText();
                        xuly2(false);
                        xulyBtn(false);
                        btnCapnhat(false);
                    }
                }

            }
     
            else
            {
                if (daoBN.UpdateBN(b))
                {
                    if (daoPTN.UpdatePTN(t))
                    {
                        MessageBox.Show("Sửa thành công");
                        loadPTN();
                        loadPTNH();
                        DateChonNgay_ValueChanged(null, null);
                        
                        xuLyControl(false);
                        //txtMa.Enabled = true;
                        //frm2.Visible = false;
                        //resetText();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
            }
        }

        void timKiem()
        {
            string s = txtTimKiem.Text;


            if (s.Length > 0)
            {
                gdPTNH.DataSource = daoPTN.TimPTN(s);
                //gdPTN.DataSource = daoPTN.TimPTN(s);
                //gcCLS.DataSource = daoCLS.TimCLS(s);

            }
            else if (s.Length == 0)
            {
                loadPTN();
                loadPTNH();
            }
        }

        private void textEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            timKiem();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lbPTN.Text = "CẬP NHẬT PHIẾU TIẾP NHẬN";
            xuLyControl(true);
            xuly2(true);
            xulyBtn(true);
            dieukien = false;
            showFormThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn xóa phiếu tiếp nhận '" + lbMa.Text + "' ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    daoPTN.deletePTN(lbMa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xuLyControl(false);
                    loadPTN();
                    loadPTNH();
                    DateChonNgay_ValueChanged(null, null);
                }
            }
            catch
            {
                //MessageBox.Show("Không thể xóa loại bệnh lý '" + lbTen.Text + "' vì có bệnh lý thuộc loại bệnh lý này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DateNS2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = Convert.ToDateTime(DateNS2.Text);
            int namsn = int.Parse(dt.Year.ToString());
            int thangsn = int.Parse(dt.Month.ToString());

            DateTime ht = System.DateTime.Now;
            int namht = int.Parse(ht.Year.ToString());
            int thanght = int.Parse(ht.Month.ToString());

            if (namht > namsn)
            {
                int tuoinam = namht - namsn;
                string tn = tuoinam.ToString();
                txtTuoinam2.Text = tn;
                txtTuoithang2.Text = "0";
            }
            else if(namht == namsn)
            {
                int tuoithang = thanght - thangsn;
                string tt = tuoithang.ToString();
                txtTuoithang2.Text = tt;
                txtTuoinam2.Text = "0";
            }
           
        }

        void BMI()
        {
            string cn = txtCannang.Text;
            string cc = txtChieucao.Text;

            int can = int.Parse(cn);
            int cao = int.Parse(cc);
            int cao2 = cao / 100;
            int bmi;

            if(cn != ""  &&  cc != "")
            {
                bmi = can / (cao2 * cao2);
                txtBMI.Text = bmi.ToString();
            }
        }

        

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            lbPTN.Text = "THÔNG TIN PHIẾU TIẾP NHẬN";
            btnCapnhat(true);
            lbMa.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            txtMa2.Text = gridView3.GetFocusedRowCellValue("TN_ID").ToString();
            txtSTT2.Text = gridView3.GetFocusedRowCellValue("TN_STT").ToString();
            txtMaBN2.Text = gridView3.GetFocusedRowCellValue("BN_ID").ToString();
            txtTen2.Text = gridView3.GetFocusedRowCellValue("BN_HOTEN").ToString();
            txtCMT2.Text = gridView3.GetFocusedRowCellValue("BN_CMT").ToString();
            txtSDT2.Text = gridView3.GetFocusedRowCellValue("BN_SDT").ToString();
            txtDiachi2.Text = gridView3.GetFocusedRowCellValue("BN_DIACHI").ToString();
            DateNS2.Text = gridView3.GetFocusedRowCellValue("BN_NGAYSINH").ToString();
            cbGioitinh2.Text = gridView3.GetFocusedRowCellValue("BN_GIOITINH").ToString();
            cbNhommau.Text = gridView3.GetFocusedRowCellValue("BN_NHOMMAU").ToString();
            txtTuoithang2.Text = gridView3.GetFocusedRowCellValue("TN_TUOITHANG").ToString();
            txtTuoinam2.Text = gridView3.GetFocusedRowCellValue("TN_TUOINAM").ToString();
            cbBSK2.Text = gridView3.GetFocusedRowCellValue("NV_HOTEN").ToString();
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
        }

        private void cbTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTT.Text == "Trực tiếp")
            {
                DateChonNgay.Enabled = false;
                loadPTN();
            }
            else if(cbTT.Text == "Đặt lịch")
            {
                DateChonNgay.Enabled = true;
                loadPTN_DL();
            }
            else if(cbTT.Text == "Tất cả")
            {
                DateChonNgay.Enabled = false;
                loadPTN_ALL();
            }
            else if(cbTT.Text == "Đang khám")
            {
                DateChonNgay.Enabled = false;
                loadPTN_DK();
            }
            else
            {
                DateChonNgay.Enabled = false;
                loadPTN_KX();
            }
        }
    }
}
