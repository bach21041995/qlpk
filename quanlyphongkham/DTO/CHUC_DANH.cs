using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CHUC_DANH
    {
        string id_cd;
        public string Id_cd
        {
            get { return id_cd; }
            set { id_cd = value; }
        }

        string cd_ten;
        public string Cd_ten
        {
            get { return cd_ten; }
            set { cd_ten = value; }
        }

        public CHUC_DANH(string id,string ten)
        {
            this.Id_cd = id;
            this.Cd_ten = ten;
        }
    }
}
