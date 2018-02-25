using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class PHIEU_TIEP_NHAN
    {
        string id_tn;
        public string Id_tn
        {
            get { return id_tn; }
            set { id_tn = value; }
        }

        int id_nv;
        public int Id_nv
        {
            get { return id_nv; }
            set { id_nv = value; }
        }

        int id_bn;
        public int Id_bn
        {
            get { return id_bn; }
            set { id_bn = value; }
        }

        int tn_stt;
        public int Tn_stt
        {
            get { return tn_stt; }
            set { tn_stt = value; }
        }

        int tn_bsk;
        public int Tn_bsk
        {
            get { return tn_bsk; }
            set { tn_bsk = value; }
        }

        string tn_dvk;
        public string Tn_dvk
        {
            get { return tn_dvk; }
            set { tn_dvk = value; }
        }

        int tn_tuoithang;
        public int Tn_tuoithang
        {
            get { return tn_tuoithang; }
            set { tn_tuoithang = value; }
        }

        int tn_tuoinam;
        public int Tn_tuoinam
        {
            get { return tn_tuoinam; }
            set { tn_tuoinam = value; }
        }

        string tn_ngaygio;
        public string Tn_ngaygio
        {
            get { return tn_ngaygio; }
            set { tn_ngaygio = value; }
        }

        float tn_mach;
        public float Tn_mach
        {
            get { return tn_mach; }
            set { tn_mach = value; }
        }

        float tn_nhietdo;
        public float Tn_nhietdo
        {
            get { return tn_nhietdo; }
            set { tn_nhietdo = value; }
        }

        float tn_nhiptho;
        public float Tn_nhiptho
        {
            get { return tn_nhiptho; }
            set { tn_nhiptho = value; }
        }

        string tn_huyetap;
        public string Tn_huyetap
        {
            get { return tn_huyetap; }
            set { tn_huyetap = value; }
        }

        float tn_chieucao;
        public float Tn_chieucao
        {
            get { return tn_chieucao; }
            set { tn_chieucao = value; }
        }

        float tn_cannang;
        public float Tn_cannang
        {
            get { return tn_cannang; }
            set { tn_cannang = value; }
        }

        float tn_bmi;
        public float Tn_bmi
        {
            get { return tn_bmi; }
            set { tn_bmi = value; }
        }

        int tn_trangthai;
        public int Tn_trangthai
        {
            get { return tn_trangthai; }
            set { tn_trangthai = value; }
        }

        public PHIEU_TIEP_NHAN(string idtn, int idnv, int idbn, int stt, int bsk, string dvk, int tthang, int tnam, string ngaygio, float mach, float nhietdo, float nhiptho, string huyetap, float chieucao, float cannang, float bmi, int trangthai)
        {
            this.Id_tn = idtn;
            this.Id_nv = idnv;
            this.Id_bn = idbn;
            this.Tn_stt = stt;
            this.Tn_bsk = bsk;
            this.Tn_dvk = dvk;
            this.Tn_tuoithang = tthang;
            this.Tn_tuoinam = tnam;
            this.Tn_ngaygio = ngaygio;
            this.Tn_mach = mach;
            this.Tn_nhietdo = nhietdo;
            this.Tn_nhiptho = nhiptho;
            this.Tn_huyetap = huyetap;
            this.Tn_chieucao = chieucao;
            this.Tn_cannang = cannang;
            this.Tn_bmi = bmi;
            this.Tn_trangthai = trangthai;
        }
    }
}
