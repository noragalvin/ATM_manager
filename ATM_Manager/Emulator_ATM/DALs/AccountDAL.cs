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
                LogDAL logDAL = new LogDAL();
                AccountDAL accountDAL = new AccountDAL();
                OverDrawftLimitDAL overDrawftDAL = new OverDrawftLimitDAL();
                string query = "SELECT Balance FROM tblAccount WHERE AccountNo=@stk";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("stk", stkChuyen);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    
                    LogDTO log = logDAL.GetLastLog(stkChuyen);
                    double phi = log.Amout * 0.05 / 100;
                    if (phi < 2000) phi = 2000;
                    if (phi > 20000) phi = 20000;
                    int currentMoney = accountDAL.GetAccount(stkChuyen).Balance;
                    int thauChi = overDrawftDAL.GetThauChi(stkChuyen).Value;
                    if (soTien <= currentMoney + thauChi)
                    {
                        int soTienConLai = int.Parse(dr["Balance"].ToString()) - soTien - Convert.ToInt32(phi) - 500;
                        UpdateMoney(stkChuyen, soTienConLai);


                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("stk", stkNhan);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            int soTienNhan = int.Parse(dr["Balance"].ToString()) + soTien;
                            UpdateMoney(stkNhan, soTienNhan);

                            string description = "Chuyển tiền";
                            string created_at = DateTime.Now.ToString();
                            logDAL.StoreLog(1, stkChuyen, created_at, soTien, 2, description, stkNhan);
                        }
                    }
                    else
                    {
                        conn.Close();
                        return;
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
