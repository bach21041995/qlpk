using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_CANLAMSAN
    {
        string id_cls;
        public string Id_cls
        {
            get { return id_cls; }
            set { id_cls = value; }
        }

        string cls_ten;
        public string Cls_ten
        {
            get { return cls_ten; }
            set { cls_ten = value; }
        }

        string cls_mota;
        public string Cls_mota
        {
            get { return cls_mota; }
            set { cls_mota = value; }
        }

        float cls_dongia;
        public float Cls_dongia
        {
            get { return cls_dongia; }
            set { cls_dongia = value; }
        }

        int cls_trangthai;
        public int Cls_trangthai
        {
            get { return cls_trangthai; }
            set { cls_trangthai = value; }
        }

        public DM_CANLAMSAN(string id, string ten, string mota, float dongia, int trangthai)
        {
            this.Id_cls = id;
            this.Cls_ten = ten;
            this.Cls_mota = mota;
            this.Cls_dongia = dongia;
            this.Cls_trangthai = trangthai;
        }
    }
}
