using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CT_TOATHUOC
    {
        int id_tt;
        public int Id_tt
        {
            get { return id_tt; }
            set { id_tt = value; }
        }

        string id_thuoc;
        public string Id_thuoc
        {
            get { return id_thuoc; }
            set { id_thuoc = value; }
        }

        string thuoc_ten;
        public string Thuoc_ten
        {
            get { return thuoc_ten; }
            set { thuoc_ten = value; }
        }

        int ctt_songayuong;
        public int Ctt_songayuong
        {
            get { return ctt_songayuong; }
            set { ctt_songayuong = value; }
        }

        string ctt_cachdung;
        public string Ctt_cachdung
        {
            get { return ctt_cachdung; }
            set { ctt_cachdung = value; }
        }

        int ctt_sang;
        public int Ctt_sang
        {
            get { return ctt_sang; }
            set { ctt_sang = value; }
        }

        int ctt_trua;
        public int Ctt_trua
        {
            get { return ctt_trua; }
            set { ctt_trua = value; }
        }

        int ctt_chieu;
        public int Ctt_chieu
        {
            get { return ctt_chieu; }
            set { ctt_chieu = value; }
        }

        int ctt_toi;
        public int Ctt_toi
        {
            get { return ctt_toi; }
            set { ctt_toi = value; }
        }

        int ctt_sl;
        public int Ctt_sl
        {
            get { return ctt_sl; }
            set { ctt_sl = value; }
        }

        float ctt_dongia;
        public float Ctt_dongia
        {
            get { return ctt_dongia; }
            set { ctt_dongia = value; }
        }

        float ctt_thanhtien;
        public float Ctt_thanhtien
        {
            get { return ctt_thanhtien; }
            set { ctt_thanhtien = value; }
        }
    }
}
