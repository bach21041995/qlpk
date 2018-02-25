using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using quanlyphongkham.Report;

namespace quanlyphongkham.Report
{
    public partial class rptToaThuoc : DevExpress.XtraReports.UI.XtraReport
    {
        public rptToaThuoc()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            lbThuocTen.DataBindings.Add("Text", DataSource, "THUOC_TEN");
            lbCttSang.DataBindings.Add("Text", DataSource, "CTT_SANG");
            lbCttTrua.DataBindings.Add("Text", DataSource, "CTT_TRUA");
            lbCttChieu.DataBindings.Add("Text", DataSource, "CTT_CHIEU");
            lbCttToi.DataBindings.Add("Text", DataSource, "CTT_TOI");
            lbCttSl.DataBindings.Add("Text", DataSource, "CTT_SOLUONG");
        }
    }
}
