using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CHUC_VU
    {
        string id_cv;
        public string Id_cv
        {
            get { return id_cv; }
            set { id_cv = value; }
        }

        string cv_ten;
        public string Cv_ten
        {
            get { return cv_ten; }
            set { cv_ten = value; }
        }

        public CHUC_VU(string id, string ten)
        {
            this.Id_cv = id;
            this.Cv_ten = ten;
        }
    }
}
