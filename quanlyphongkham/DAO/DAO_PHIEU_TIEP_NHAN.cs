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
    class DAO_PHIEU_TIEP_NHAN
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSPTN()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getPHIEU_TIEP_NHAN", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            //string query = " select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID order by THUOC_ID";
            //return connecDB.ExecuteQuery(query);
        }

        public DataTable getDSPTN_ALL()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getPHIEU_TIEP_NHAN_ALL", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            //string query = " select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID order by THUOC_ID";
            //return connecDB.ExecuteQuery(query);
        }

        public DataTable getDSPTN_DK()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getPHIEU_TIEP_NHAN_DK", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            //string query = " select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID order by THUOC_ID";
            //return connecDB.ExecuteQuery(query);
        }


        public DataTable getDSPTN_KX()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getPHIEU_TIEP_NHAN_KX", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            //string query = " select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID order by THUOC_ID";
            //return connecDB.ExecuteQuery(query);
        }

        public DataTable TimPTN(string tk)
        {
            string t = tk.ToLower();
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("timPTN", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tk", SqlDbType.NVarChar, 30);
            cmd.Parameters["@tk"].Value = t;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            
        }

        public DataTable getPTN_NGAY(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getPTN_NGAY", conn);
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

        public string insertMaPTN(string ngay)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("PTN_ID_auto", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ngay", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar, 15);
            cmd.Parameters["@ma_next"].Direction = ParameterDirection.Output;
            cmd.Parameters["@ngay"].Value = ngay;
            cmd.Parameters["@ma_next"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string ma = cmd.Parameters["@ma_next"].Value.ToString();
            conn.Close();

            return ma;
        }

        public bool InsertPTN(PHIEU_TIEP_NHAN t)
        {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("themPHIEU_TIEP_NHAN", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@TN_ID", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@NV_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@BN_ID", SqlDbType.Int);
                    cmd.Parameters.Add("@TN_STT", SqlDbType.Int);
                    cmd.Parameters.Add("@TN_BSKHAM", SqlDbType.Int);
                    cmd.Parameters.Add("@TN_DVKHAM", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@TN_TUOINAM", SqlDbType.Int);
                    cmd.Parameters.Add("@TN_TUOITHANG", SqlDbType.Int);
                    cmd.Parameters.Add("@TN_NGAYGIO", SqlDbType.Date);
                    cmd.Parameters.Add("@TN_MACH", SqlDbType.Float);
                    cmd.Parameters.Add("@TN_NHIETDO", SqlDbType.Float);
                    cmd.Parameters.Add("@TN_NHIPTHO", SqlDbType.Float);
                    cmd.Parameters.Add("@TN_HUYETAP", SqlDbType.NVarChar, 7);
                    cmd.Parameters.Add("@TN_CHIEUCAO", SqlDbType.Float);
                    cmd.Parameters.Add("@TN_CANNANG", SqlDbType.Float);
                    cmd.Parameters.Add("@TN_BMI", SqlDbType.Float);
                    cmd.Parameters.Add("@TN_TRANGTHAI", SqlDbType.Int);
                    cmd.Parameters["@TN_ID"].Value = t.Id_tn;
                    cmd.Parameters["@NV_ID"].Value = t.Id_nv;
                    cmd.Parameters["@BN_ID"].Value = t.Id_bn;
                    cmd.Parameters["@TN_STT"].Value = t.Tn_stt;
                    cmd.Parameters["@TN_BSKHAM"].Value = t.Tn_bsk;
                    cmd.Parameters["@TN_DVKHAM"].Value = t.Tn_dvk;
                    cmd.Parameters["@TN_TUOINAM"].Value = t.Tn_tuoinam;
                    cmd.Parameters["@TN_TUOITHANG"].Value = t.Tn_tuoithang;
                    cmd.Parameters["@TN_NGAYGIO"].Value = t.Tn_ngaygio;
                    cmd.Parameters["@TN_MACH"].Value = t.Tn_mach;
                    cmd.Parameters["@TN_NHIETDO"].Value = t.Tn_nhietdo;
                    cmd.Parameters["@TN_NHIPTHO"].Value = t.Tn_nhiptho;
                    cmd.Parameters["@TN_HUYETAP"].Value = t.Tn_huyetap;
                    cmd.Parameters["@TN_CHIEUCAO"].Value = t.Tn_chieucao;
                    cmd.Parameters["@TN_CANNANG"].Value = t.Tn_cannang;
                    cmd.Parameters["@TN_BMI"].Value = t.Tn_bmi;
                    cmd.Parameters["@TN_TRANGTHAI"].Value = t.Tn_trangthai;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
        }

        public bool UpdatePTN(PHIEU_TIEP_NHAN t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("suaPHIEU_TIEP_NHAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            cmd.Parameters.Add("@TN_ID", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@TN_STT", SqlDbType.Int);
            cmd.Parameters.Add("@TN_BSKHAM", SqlDbType.Int);
            cmd.Parameters.Add("@TN_DVKHAM", SqlDbType.NVarChar, 30);
            cmd.Parameters.Add("@TN_TUOINAM", SqlDbType.Int);
            cmd.Parameters.Add("@TN_TUOITHANG", SqlDbType.Int);
            cmd.Parameters.Add("@TN_NGAYGIO", SqlDbType.Date);
            cmd.Parameters.Add("@TN_MACH", SqlDbType.Float);
            cmd.Parameters.Add("@TN_NHIETDO", SqlDbType.Float);
            cmd.Parameters.Add("@TN_NHIPTHO", SqlDbType.Float);
            cmd.Parameters.Add("@TN_HUYETAP", SqlDbType.Float);
            cmd.Parameters.Add("@TN_CHIEUCAO", SqlDbType.Float);
            cmd.Parameters.Add("@TN_CANNANG", SqlDbType.Float);
            cmd.Parameters.Add("@TN_BMI", SqlDbType.Float);
            cmd.Parameters.Add("@TN_TRANGTHAI", SqlDbType.Int);

            cmd.Parameters["@TN_ID"].Value = t.Id_tn;
            cmd.Parameters["@TN_STT"].Value = t.Tn_stt;
            cmd.Parameters["@TN_BSKHAM"].Value = t.Tn_bsk;
            cmd.Parameters["@TN_DVKHAM"].Value = t.Tn_dvk;
            cmd.Parameters["@TN_TUOINAM"].Value = t.Tn_tuoinam;
            cmd.Parameters["@TN_TUOITHANG"].Value = t.Tn_tuoithang;
            cmd.Parameters["@TN_NGAYGIO"].Value = t.Tn_ngaygio;
            cmd.Parameters["@TN_MACH"].Value = t.Tn_mach;
            cmd.Parameters["@TN_NHIETDO"].Value = t.Tn_nhietdo;
            cmd.Parameters["@TN_NHIPTHO"].Value = t.Tn_nhiptho;
            cmd.Parameters["@TN_HUYETAP"].Value = t.Tn_huyetap;
            cmd.Parameters["@TN_CHIEUCAO"].Value = t.Tn_chieucao;
            cmd.Parameters["@TN_CANNANG"].Value = t.Tn_cannang;
            cmd.Parameters["@TN_BMI"].Value = t.Tn_bmi;
            cmd.Parameters["@TN_TRANGTHAI"].Value = t.Tn_trangthai;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }


        public bool UpdatePTN_DK(PHIEU_TIEP_NHAN t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("suaPHIEU_TIEP_NHAN_DK", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            cmd.Parameters.Add("@TN_ID", SqlDbType.NVarChar, 10);
            

            cmd.Parameters["@TN_ID"].Value = t.Id_tn;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public bool UpdatePTN_KX(PHIEU_TIEP_NHAN t)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("suaPHIEU_TIEP_NHAN_KX", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            //cmd.Parameters["@mathuoc"].Value = mt;
            cmd.Parameters.Add("@TN_ID", SqlDbType.NVarChar, 10);


            cmd.Parameters["@TN_ID"].Value = t.Id_tn;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }

        public void deletePTN(string mt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaPHIEU_TIEP_NHAN", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TN_ID", SqlDbType.NVarChar, 15);
            cmd.Parameters["@TN_ID"].Value = mt;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }


    }
}
