using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_THUOC
    {
        string id_thuoc;
        public string Id_thuoc
        {
            get { return id_thuoc; }
            set { id_thuoc = value; }
        }

        string id_lt;
        public string Id_lt
        {
            get { return id_lt; }
            set { id_lt = value; }
        }

        string thuoc_ten;
        public string Thuoc_ten
        {
            get { return thuoc_ten; }
            set { thuoc_ten = value; }
        }

        string thuoc_hdsd;
        public string Thuoc_hdsd
        {
            get { return thuoc_hdsd; }
            set { thuoc_hdsd = value; }
        }

        string thuoc_dvt;
        public string Thuoc_dvt
        {
            get { return thuoc_dvt; }
            set { thuoc_dvt = value; }
        }

        string thuoc_congdung;
        public string Thuoc_congdung
        {
            get { return thuoc_congdung; }
            set { thuoc_congdung = value; }
        }

        float thuoc_gia;
        public float Thuoc_gia
        {
            get { return thuoc_gia; }
            set { thuoc_gia = value; }
        }

        int thuoc_trangthai;
        public int Thuoc_trangthai
        {
            get { return thuoc_trangthai; }
            set { thuoc_trangthai = value; }
        }

        string thuoc_cachdung;
        public string Thuoc_cachdung
        {
            get { return thuoc_cachdung; }
            set { thuoc_cachdung = value; }
        }

        public DM_THUOC(string idthuoc, string idlthuoc, string ten, string hdsd, string dvt, string congdung, float gia, int trangthai, string cachdung)
        {
            this.Id_thuoc = idthuoc;
            this.Id_lt = idlthuoc;
            this.Thuoc_ten = ten;
            this.Thuoc_hdsd = hdsd;
            this.Thuoc_dvt = dvt;
            this.Thuoc_congdung = congdung;
            this.Thuoc_gia = gia;
            this.Thuoc_trangthai = trangthai;
            this.Thuoc_cachdung = cachdung;
        }
    }
}
