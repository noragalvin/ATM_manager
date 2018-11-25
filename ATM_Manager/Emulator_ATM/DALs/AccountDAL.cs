using DTOs;
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

        public AccountDTO GetCurrentMoney()
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM tblAccount";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    AccountDTO accountDTO = new AccountDTO(
                        int.Parse(dr["Balance"].ToString()));
                    conn.Close();
                    return accountDTO;
                }
                conn.Close();
                return null;
            }
            catch (Exception)
            {

                return null;
            }
            //return new WithDrawLimitDTO(int.Parse(dr["Value"].ToString()));
        }

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
                        logDAL.StoreLog(1, stkChuyen, created_at, soTien, 2, description, stkNhan);
                    }
                }

                conn.Close();
            }
            catch (Exception)
            {

                return;
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
                return;
            }
        }

        public AccountDTO VanTinSoDu(string accountNo)
        {
            try
            {
                conn.Open();
                string query = "SELECT * FROM tblAccount WHERE AccountNo=@accNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("accNo", accountNo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    AccountDTO acc = new AccountDTO(
                        dr["AccountNo"].ToString(),
                        int.Parse(dr["Balance"].ToString()));
                    conn.Close();
                    return acc;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AccountDTO GetAccount(string accountNo)
        {
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tblAccount WHERE AccountNo=@accNo";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("accNo", accountNo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        AccountDTO accountDTO = new AccountDTO(
                            int.Parse(dr["Balance"].ToString()));
                        conn.Close();
                        return accountDTO;
                    }
                    conn.Close();
                    return null;
                }
                catch (Exception)
                {

                    return null;
                }
                //return new WithDrawLimitDTO(int.Parse(dr["Value"].ToString()));
            }
        }
    }
}
