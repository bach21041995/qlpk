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
    class DAO_DM_THUOC
    {
        ConnectionDatabase connecDB = new ConnectionDatabase();

        public DataTable getDSThuoc()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getDM_THUOC", conn);
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

        public string insertMaThuoc(string malt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("THUOC_ID_auto", conn);
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@malt", SqlDbType.NVarChar, 20);
            cmd.Parameters.Add("@ma_next", SqlDbType.NVarChar, 20);
            cmd.Parameters["@ma_next"].Direction = ParameterDirection.Output;
            cmd.Parameters["@malt"].Value = malt;
            cmd.Parameters["@ma_next"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string mathuoc = cmd.Parameters["@ma_next"].Value.ToString();
            conn.Close();

            return mathuoc;
        }

        public string getIDTHUOCbyTEN(string ten)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getIDTHUOCbyTEN", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 20);
            cmd.Parameters["@id"].Direction = ParameterDirection.Output;
            cmd.Parameters["@ten"].Value = ten;
            cmd.Parameters["@id"].Value = "";
            conn.Open();
            cmd.ExecuteNonQuery();
            string mathuoc = cmd.Parameters["@id"].Value.ToString();
            conn.Close();

            return mathuoc;
        }

        public DataTable TimThuoc(string tk)
        {
            string t = tk.ToLower();
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("timDM_THUOC", conn);
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

            //string query = "select MaHV, TenHV, (CASE GioiTinh when 'true' then N'Nam' else N'Nữ' end) as GioiTinh, NgaySinhHV, DiaChi, DienThoai, a.MaLop, a.MaDT, TenDT, TenLop"
            //+ " from hocvien a , lop b, doituong c where a.MaLop = b.MaLop and a.MaDT = c.MaDT and " + tk + "";
            //string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
            //+ " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and (lower(THUOC_TEN) like N'%" + tk.ToLower() + "%' or lower(THUOC_ID) like N'%" + tk.ToLower() + "%' or lower(LT_TEN) like N'%" + tk.ToLower() + "%')";
            //return connecDB.ExecuteQuery(query);
        }

        public DataTable getLT()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getLOAI_THUOC", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;

            //string query = " select LT_ID, LT_TEN from LOAI_THUOC where LT_TRANGTHAI = '1'";
            //return connecDB.ExecuteQuery(query);
        }

        /*public DataTable getThuocByLT(string lt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getLOAI_THUOC", conn);
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            return dt;
            string query = "select THUOC_ID, THUOC_TEN, THUOC_HDSD, THUOC_CONGDUNG, THUOC_DVT, THUOC_GIA, LT_TEN"
                            + " from DM_THUOC a, LOAI_THUOC b where a.LT_ID = b.LT_ID and a.LT_ID = '" + lt + "'";
            return connecDB.ExecuteQuery(query);
        }*/

        public void deleteThuoc(string mt)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("xoaDM_THUOC", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
            cmd.Parameters["@mathuoc"].Value = mt;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            /*string query = "Update DM_THUOC set THUOC_TRANGTHAI = '1' where THUOC_ID = '" + mathuoc + "'";
            int result = connecDB.ExecuteNonQuery(query);

            return result > 0;*/
        }

        public bool InsertThuoc(DM_THUOC t)
        {
            if (KiemTraNhapLieu(t))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                    SqlCommand cmd = new SqlCommand("themDM_THUOC", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                    //cmd.Parameters["@mathuoc"].Value = mt;
                    cmd.Parameters.Add("@THUOC_ID", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@LT_ID", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@THUOC_TEN", SqlDbType.NVarChar, 30);
                    cmd.Parameters.Add("@THUOC_HDSD", SqlDbType.NVarChar, 50);
                    cmd.Parameters.Add("@THUOC_DVT", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@THUOC_CONGDUNG", SqlDbType.NVarChar, 50);
                    cmd.Parameters.Add("@THUOC_GIA", SqlDbType.Float);
                    cmd.Parameters.Add("@THUOC_TRANGTHAI", SqlDbType.Int);
                    cmd.Parameters.Add("@THUOC_CACHDUNG", SqlDbType.NVarChar, 60);
                    cmd.Parameters["@THUOC_ID"].Value = t.Id_thuoc;
                    cmd.Parameters["@LT_ID"].Value = t.Id_lt;
                    cmd.Parameters["@THUOC_TEN"].Value = t.Thuoc_ten;
                    cmd.Parameters["@THUOC_HDSD"].Value = t.Thuoc_hdsd;
                    cmd.Parameters["@THUOC_DVT"].Value = t.Thuoc_dvt;
                    cmd.Parameters["@THUOC_CONGDUNG"].Value = t.Thuoc_congdung;
                    cmd.Parameters["@THUOC_GIA"].Value = t.Thuoc_gia;
                    cmd.Parameters["@THUOC_TRANGTHAI"].Value = t.Thuoc_trangthai;
                    cmd.Parameters["@THUOC_CACHDUNG"].Value = t.Thuoc_cachdung;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    return result > 0;
                    

                    /*string query = string.Format("Insert DM_THUOC (THUOC_ID, LT_ID, THUOC_TEN, THUOC_HDSD, THUOC_DVT, THUOC_CONGDUNG, THUOC_GIA, THUOC_TRANGTHAI) values ('{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', '{7}')",
                                    t.Id_thuoc, t.Id_lt, t.Thuoc_ten, t.Thuoc_hdsd, t.Thuoc_dvt, t.Thuoc_congdung, t.Thuoc_gia, t.Thuoc_trangthai);
                    int result = connecDB.ExecuteNonQuery(query);
                    return result > 0;*/
                }
                catch
                {
                    if (KiemTraTrungTenThuoc(t).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do tên thuốc đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                
                    /*if(KiemTraTrungSDT(nv).Rows.Count == 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm không thành công do Số điện thoại của giáo viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }*/
                }
            }
            return false;
        }



        public bool KiemTraNhapLieu(DM_THUOC t)
        {
            if (t.Thuoc_ten.Equals(""))
            {
                MessageBox.Show("Tên thuốc không được trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        public DataTable KiemTraTrungTenThuoc(DM_THUOC t)
        {
            string query = "select * from DM_THUOC where THUOC_TEN = '" + t.Thuoc_ten + "' and THUOC_TRANGTHAI = '1'";
            DataTable dt = connecDB.ExecuteQuery(query);
            return dt;
        }

        public bool UpdateThuoc(DM_THUOC t)
        {
            if (KiemTraNhapLieu(t))
            {
                SqlConnection conn = new SqlConnection(connecDB.connectionStr);
                SqlCommand cmd = new SqlCommand("suaDM_THUOC", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@mathuoc", SqlDbType.NVarChar, 20);
                //cmd.Parameters["@mathuoc"].Value = mt;
                cmd.Parameters.Add("@THUOC_ID", SqlDbType.NVarChar, 20);
                cmd.Parameters.Add("@LT_ID", SqlDbType.NVarChar, 10);
                cmd.Parameters.Add("@THUOC_TEN", SqlDbType.NVarChar, 30);
                cmd.Parameters.Add("@THUOC_HDSD", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@THUOC_DVT", SqlDbType.NVarChar, 10);
                cmd.Parameters.Add("@THUOC_CONGDUNG", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@THUOC_GIA", SqlDbType.Float);
                cmd.Parameters.Add("@THUOC_TRANGTHAI", SqlDbType.Int);
                cmd.Parameters["@THUOC_ID"].Value = t.Id_thuoc;
                cmd.Parameters["@LT_ID"].Value = t.Id_lt;
                cmd.Parameters["@THUOC_TEN"].Value = t.Thuoc_ten;
                cmd.Parameters["@THUOC_HDSD"].Value = t.Thuoc_hdsd;
                cmd.Parameters["@THUOC_DVT"].Value = t.Thuoc_dvt;
                cmd.Parameters["@THUOC_CONGDUNG"].Value = t.Thuoc_congdung;
                cmd.Parameters["@THUOC_GIA"].Value = t.Thuoc_gia;
                cmd.Parameters["@THUOC_TRANGTHAI"].Value = t.Thuoc_trangthai;
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                return result > 0;
            }
            return true;
        }


        public AutoCompleteStringCollection getDSTHUOC_TOA()
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getTHUOC", conn);
            AutoCompleteStringCollection auto2 = new AutoCompleteStringCollection();
            cmd.CommandType = CommandType.StoredProcedure;
            
            conn.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    auto2.Add(reader["THUOC_TEN"].ToString());
                }
            }
            //cmd.ExecuteNonQuery();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(dt);
            conn.Close();
            return auto2;

            //string query = " select LT_ID, LT_TEN from LOAI_THUOC where LT_TRANGTHAI = '1'";
            //return connecDB.ExecuteQuery(query);
        }

        public string getDVT_CD_GIA(string tk)
        {
            SqlConnection conn = new SqlConnection(connecDB.connectionStr);
            SqlCommand cmd = new SqlCommand("getDVT_CD_GIA", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tt", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@dvt", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@cd", SqlDbType.NVarChar, 60);
            cmd.Parameters.Add("@dg", SqlDbType.Float);
            cmd.Parameters["@dvt"].Direction = ParameterDirection.Output;
            cmd.Parameters["@cd"].Direction = ParameterDirection.Output;
            cmd.Parameters["@dg"].Direction = ParameterDirection.Output;
            cmd.Parameters["@tt"].Value = tk;
            cmd.Parameters["@dvt"].Value = "";
            cmd.Parameters["@cd"].Value = "";
            cmd.Parameters["@dg"].Value = 0;
            conn.Open();
            cmd.ExecuteNonQuery();
            string dvt = cmd.Parameters["@dvt"].Value.ToString();
            string cd = cmd.Parameters["@cd"].Value.ToString();
            string dg = cmd.Parameters["@dg"].Value.ToString();
            string dvt_cd_dg = dvt + "/" + cd + "/" + dg;
            conn.Close();
            return dvt_cd_dg;
        }
    }
}
