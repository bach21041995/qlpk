using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class NHAN_VIEN
    {
        int id_nv;
        public int Id_nv
        {
            get { return id_nv; }
            set { id_nv = value; }
        }

        string id_cd;
        public string Id_cd
        {
            get { return id_cd; }
            set { id_cd = value; }
        }

        string id_cv;
        public string Id_cv
        {
            get { return id_cv; }
            set { id_cv = value; }
        }

        string nv_hoten;
        public string Nv_hoten
        {
            get { return nv_hoten; }
            set { nv_hoten = value; }
        }

        int nv_gioitinh;
        public int Nv_gioitinh
        {
            get { return nv_gioitinh; }
            set { nv_gioitinh = value; }
        }

        string nv_ngaysinh;
        public string Nv_ngaysinh
        {
            get { return nv_ngaysinh; }
            set { nv_ngaysinh = value; }
        }

        string nv_cmt;
        public string Nv_cmt
        {
            get { return nv_cmt; }
            set { nv_cmt = value; }
        }

        string nv_sdt;
        public string Nv_sdt
        {
            get { return nv_sdt; }
            set { nv_sdt = value; }
        }

        string nv_diachi;
        public string Nv_diachi
        {
            get { return nv_diachi; }
            set { nv_diachi = value; }
        }

        string nv_tk;
        public string Nv_tk
        {
            get { return nv_tk; }
            set { nv_tk = value; }
        }

        string nv_mk;
        public string Nv_mk
        {
            get { return nv_mk; }
            set { nv_mk = value; }
        }

        int nv_trangthai;
        public int Nv_trangthai
        {
            get { return nv_trangthai; }
            set { nv_trangthai = value; }
        }

        public NHAN_VIEN(string idcd, string idcv, string hoten, int gioitinh, string ngaysinh, string cmt, string sdt, string diachi, string tk, string mk, int trangthai)
        {
            //this.Id_nv = idnv;
            this.Id_cd = idcd;
            this.Id_cv = idcv;
            this.Nv_hoten = hoten;
            this.Nv_gioitinh = gioitinh;
            this.Nv_ngaysinh = ngaysinh;
            this.Nv_cmt = cmt;
            this.Nv_sdt = sdt;
            this.Nv_diachi = diachi;
            this.Nv_tk = tk;
            this.Nv_mk = mk;
            this.Nv_trangthai = trangthai;
        }
    }
}
