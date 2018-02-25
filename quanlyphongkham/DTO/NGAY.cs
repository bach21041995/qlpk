using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class NGAY
    {
        string id_ngay;
        public string Id_ngay
        {
            get { return id_ngay; }
            set { id_ngay = value; }
        }

        string ngay;
        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        public NGAY(string id, string ngay)
        {
            this.Id_ngay = id;
            this.Ngay = ngay;
        }
    }
}
