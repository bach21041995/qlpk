using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class PHIEU_CHI_DINH
    {
        int id_pcd;
        public int Id_pcd
        {
            get { return id_pcd; }
            set { id_pcd = value; }
        }

        string id_kb;
        public string Id_kb
        {
            get { return id_kb; }
            set { id_kb = value; }
        }

        string pcd_ngaygio;
        public string Pcd_ngaygio
        {
            get { return pcd_ngaygio; }
            set { pcd_ngaygio = value; }
        }

        int pcd_trangthai;
        public int Pcd_trangthai
        {
            get { return pcd_trangthai; }
            set { pcd_trangthai = value; }
        }

        public PHIEU_CHI_DINH(int idpcd, string idkb, string ngaygio, int trangthai)
        {
            this.Id_pcd = idpcd;
            this.Id_kb = idkb;
            this.Pcd_ngaygio = ngaygio;
            this.Pcd_trangthai = trangthai;
        }
    }
}
