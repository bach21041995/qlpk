using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class LOAI_BENHLY
    {
        string id_lbl;
        public string Id_lbl
        {
            get { return id_lbl; }
            set { id_lbl = value; }
        }

        string lbl_ten;
        public string Lbl_ten
        {
            get { return lbl_ten; }
            set { lbl_ten = value; }
        }

        public LOAI_BENHLY(string id, string ten)
        {
            this.Id_lbl = id;
            this.Lbl_ten = ten;
        }
    }
}
