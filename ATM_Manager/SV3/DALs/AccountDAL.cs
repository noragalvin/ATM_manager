using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class AccountDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString());

        public void ChuyenKhoan(string stkChuyen, string stkNhan, int soTien)
        {
            try
            {
                conn.Open();
                string query = "SELECT Balance FROM tblAccount WHERE AccountNo=@stk";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("stk", stkChuyen);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int soTienConLai = int.Parse(dr["Balance"].ToString()) - soTien;
                    UpdateMoney(stkChuyen, soTienConLai);


                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("stk", stkNhan);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int soTienNhan = int.Parse(dr["Balance"].ToString()) + soTien;
                        UpdateMoney(stkNhan, soTienNhan);

                        LogDAL logDAL = new LogDAL();
                        string description = "";
                        string created_at = DateTime.Now.ToString();
                        logDAL.StoreLog(1, stkChuyen, created_at, soTien, description, stkNhan);
                    }
                }

                conn.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void UpdateMoney(string stk, int money)
        {
            try
            {
                string query = "UPDATE tblAccount SET Balance=@balance WHERE AccountNo=@stk";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("balance", money);
                cmd.Parameters.AddWithValue("stk", stk);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
