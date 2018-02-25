using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlyphongkham.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace quanlyphongkham.DAO
{
    class DAO_KHAM_BENH
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public string insertMaKB(string mabn)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("KB_ID_auto", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mabn", SqlDbType.NVarChar, 8);
            cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar, 15);
            cmd.Parameters["@ma_next"].Direction = ParameterDirection.Output;
            cmd.Parameters["@mabn"].Value = mabn;
            cmd.Parameters["@ma_next"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string ma = cmd.Parameters["@ma_next"].Value.ToString();
            conn.Close();

            return ma;
        }

        public bool InsertKB(KHAM_BENH t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("themKHAM_BENH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 15);
            cmd.Parameters.Add("@TN_ID", SqlDbType.NVarChar, 15);
            cmd.Parameters.Add("@KB_NGAYHENTAIKHAM", SqlDbType.Date);
            cmd.Parameters.Add("@KB_NGAY", SqlDbType.Date);
            cmd.Parameters.Add("@KB_TRANGTHAI", SqlDbType.Int);
            cmd.Parameters.Add("@KB_KETLUAN", SqlDbType.NVarChar, 100);
            
            cmd.Parameters["@KB_ID"].Value = t.Id_kb;
            cmd.Parameters["@TN_ID"].Value = t.Id_tn;
            cmd.Parameters["@KB_NGAYHENTAIKHAM"].Value = t.Ngay_htk;
            cmd.Parameters["@KB_NGAY"].Value = t.Ngay_kb;
            cmd.Parameters["@KB_TRANGTHAI"].Value = t.Kb_trangthai;
            cmd.Parameters["@KB_KETLUAN"].Value = t.Kb_ketluan;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public bool UpdateKB(KHAM_BENH t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("suaKHAM_BENH", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            cmd.Parameters.Add("@KB_ID", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@KB_NGAYHENTAIKHAM", SqlDbType.Date);
            cmd.Parameters.Add("@KB_TRANGTHAI", SqlDbType.Int);
            cmd.Parameters.Add("@KB_KETLUAN", SqlDbType.NVarChar, 100);

            cmd.Parameters["@KB_ID"].Value = t.Id_kb;
            cmd.Parameters["@KB_NGAYHENTAIKHAM"].Value = t.Ngay_htk;
            cmd.Parameters["@KB_TRANGTHAI"].Value = t.Kb_trangthai;
            cmd.Parameters["@KB_KETLUAN"].Value = t.Kb_ketluan;

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }


        public DataTable getKB()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getKB_NGAY", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable getKB_NGAY(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getKB_NGAY", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ngay", SqlDbType.NVarChar, 30);
            cmd.Parameters["@ngay"].Value = tk;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            //string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and (lower(THUOC_TEN) like N'%" + tk.ToLower() + "%' or lower(THUOC_ID) like N'%" + tk.ToLower() + "%' or lower(LT_TEN) like N'%" + tk.ToLower() + "%')";
            //return connecDB.ExecuteQuery(query);
        }


        public DataTable getKB_NGAY_DK(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getKB_NGAY_DK", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ngay", SqlDbType.NVarChar, 30);
            cmd.Parameters["@ngay"].Value = tk;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            //string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and (lower(THUOC_TEN) like N'%" + tk.ToLower() + "%' or lower(THUOC_ID) like N'%" + tk.ToLower() + "%' or lower(LT_TEN) like N'%" + tk.ToLower() + "%')";
            //return connecDB.ExecuteQuery(query);
        }

        public DataTable getKB_NGAY_KX(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getKB_NGAY_KX", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ngay", SqlDbType.NVarChar, 30);
            cmd.Parameters["@ngay"].Value = tk;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            //string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and (lower(THUOC_TEN) like N'%" + tk.ToLower() + "%' or lower(THUOC_ID) like N'%" + tk.ToLower() + "%' or lower(LT_TEN) like N'%" + tk.ToLower() + "%')";
            //return connecDB.ExecuteQuery(query);
        }


        public string getBL_ICD(string tk)
        {

            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getBL_ICD", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@tenbl", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@idbl", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@cm", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@md", SqlDbType.NVarChar, 10);
            cmd.Parameters["@tenbl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@idbl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@cm"].Direction = ParameterDirection.Output;
            cmd.Parameters["@md"].Direction = ParameterDirection.Output;
            cmd.Parameters["@tk"].Value = tk;
            cmd.Parameters["@idbl"].Value = "";
            cmd.Parameters["@tenbl"].Value = "";
            cmd.Parameters["@cm"].Value = "";
            cmd.Parameters["@md"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string idbl = cmd.Parameters["@idbl"].Value.ToString();
            string tenbl = cmd.Parameters["@tenbl"].Value.ToString();
            string cm = cmd.Parameters["@cm"].Value.ToString();
            string md = cmd.Parameters["@md"].Value.ToString();
            string bl = idbl + "/" + tenbl + "/" + cm + "/" + md;
            conn.Close();
            return bl;
        }


        public string getIDKB_MAX()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getIDKB_MAX", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@last", SqlDbType.NVarChar, 20);
            cmd.Parameters["@last"].Direction = ParameterDirection.Output;
            cmd.Parameters["@last"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string ma = cmd.Parameters["@last"].Value.ToString();
            conn.Close();

            return ma;
        }


        public string getBL_PHU(string tk)
        {

            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getBL_PHU", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@tenbl", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@idbl", SqlDbType.NVarChar, 20);
            cmd.Parameters["@tenbl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@idbl"].Direction = ParameterDirection.Output;
            cmd.Parameters["@tk"].Value = tk;
            cmd.Parameters["@idbl"].Value = "";
            cmd.Parameters["@tenbl"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string idbl = cmd.Parameters["@idbl"].Value.ToString();
            string tenbl = cmd.Parameters["@tenbl"].Value.ToString();
            string bl = idbl + "/" + tenbl;
            conn.Close();
            return bl;
        }
    }
}
