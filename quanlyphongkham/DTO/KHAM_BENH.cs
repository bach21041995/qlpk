using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class KHAM_BENH
    {
        string id_kb;
        public string Id_kb
        {
            get { return id_kb; }
            set { id_kb = value; }
        }

        string id_tn;
        public string Id_tn
        {
            get { return id_tn; }
            set { id_tn = value; }
        }

        string ngay;
        public string Ngay_kb
        {
            get { return ngay; }
            set { ngay = value; }
        }

        string ngay_htk;
        public string Ngay_htk
        {
            get { return ngay_htk; }
            set { ngay_htk = value; }
        }

        int kb_trangthai;
        public int Kb_trangthai
        {
            get { return kb_trangthai; }
            set { kb_trangthai = value; }
        }

        string kb_ketluan;
        public string Kb_ketluan
        {
            get { return kb_ketluan; }
            set { kb_ketluan = value; }
        }

        public KHAM_BENH(string idkb, string idtn, string ngayhtk, string ngay, int trangthai, string ketluan)
        {
            this.Id_kb = idkb;
            this.Id_tn = idtn;
            this.Ngay_htk = ngayhtk;
            this.Ngay_kb = ngay;
            this.Kb_trangthai = trangthai;
            this.Kb_ketluan = ketluan;
        }
    }
}
