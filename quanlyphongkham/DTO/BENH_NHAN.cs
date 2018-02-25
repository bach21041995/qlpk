using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class BENH_NHAN
    {
        int id_bn;
        public int Id_bn
        {
            get { return id_bn; }
            set { id_bn = value; }
        }

        string hoten;
        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }

        int gioitinh;
        public int Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }

        string ngaysinh;
        public string Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        string cmt;
        public string Cmt
        {
            get { return cmt; }
            set { cmt = value; }
        }

        string sdt;
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }

        string diachi;
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        string nhommau;
        public string Nhommau
        {
            get { return nhommau; }
            set { nhommau = value; }
        }

        int trangthai;
        public int Trangthai
        {
            get { return trangthai; }
            set { trangthai = value; }
        }

        public BENH_NHAN(int id, string hoten, string cmt, string sdt, string diachi, string ngaysinh, int gioitinh, string nhommau, int trangthai)
        {
            this.Id_bn = id;
            this.Hoten = hoten;
            this.Cmt = cmt;
            this.Sdt = sdt;
            this.Diachi = diachi;
            this.Ngaysinh = ngaysinh;
            this.Gioitinh = gioitinh;
            this.Nhommau = nhommau;
            this.Trangthai = trangthai;
        }

    }
}
