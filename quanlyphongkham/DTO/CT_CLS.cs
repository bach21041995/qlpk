using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyphongkham.DTO
{
    class CT_CLS
    {
        int id_pcd;
        public int Id_pcd
        {
            get { return id_pcd; }
            set { id_pcd = value; }
        }

        int id_cls;
        public int Id_cls
        {
            get { return id_cls; }
            set { id_cls = value; }
        }

        int ctcls_soluong;
        public int Ctcls_soluong
        {
            get { return ctcls_soluong; }
            set { ctcls_soluong = value; }
        }

        string ctcls_ketqua;
        public string Ctcls_ketqua
        {
            get { return ctcls_ketqua; }
            set { ctcls_ketqua = value; }
        }
    }
}
