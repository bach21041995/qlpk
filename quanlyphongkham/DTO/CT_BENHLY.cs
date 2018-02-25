using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CT_BENHLY
    {
        string id_bl;
        public string Id_bl
        {
            get { return id_bl; }
            set { id_bl = value; }
        }

        string id_kb;
        public string Id_kb
        {
            get { return id_kb; }
            set { id_kb = value; }
        }

        string ctbl_chuyenmon;
        public string Ctbl_chuyenmon
        {
            get { return ctbl_chuyenmon; }
            set { ctbl_chuyenmon = value; }
        }

        int ctbl_trangthai;
        public int Ctbl_trangthai
        {
            get { return ctbl_trangthai; }
            set { ctbl_trangthai = value; }
        }

        string ctbl_mucdo;
        public string Ctbl_mucdo
        {
            get { return ctbl_mucdo; }
            set { ctbl_mucdo = value; }
        }


    }
}
