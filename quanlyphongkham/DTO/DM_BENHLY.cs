using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class DM_BENHLY
    {
        string id_bl;
        public string Id_bl
        {
            get { return id_bl; }
            set { id_bl = value; }
        }

        string id_lbl;
        public string Id_lbl
        {
            get { return id_lbl; }
            set { id_lbl = value; }
        }

        string bl_ten;
        public string Bl_ten
        {
            get { return bl_ten; }
            set { bl_ten = value; }
        }
        
        public DM_BENHLY(string idbl, string idlbl, string ten)
        {
            this.Id_bl = idbl;
            this.Id_lbl = idlbl;
            this.Bl_ten = ten;
        }
    }
}
