using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class LOAI_THUOC
    {
        string id_lt;
        public string Id_lt
        {
            get { return id_lt; }
            set { id_lt = value; }
        }

        string lt_ten;
        public string Lt_ten
        {
            get { return lt_ten; }
            set { lt_ten = value; }
        }

        int lt_trangthai;
        public int Lt_trangthai
        {
            get { return lt_trangthai; }
            set { lt_trangthai = value; }
        }

        public LOAI_THUOC(string id, string ten, int trangthai)
        {
            this.Id_lt = id;
            this.Lt_ten = ten;
            this.Lt_trangthai = trangthai;
        }
    }
}
