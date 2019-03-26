using DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class LogDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString());

        public LogDTO GetLastLog(string cardNo)
        {
            try
            {
                conn.Open();
                string query = "SELECT TOP 1 * FROM tblLog WHERE CardNo=@cardNum ORDER BY LogID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("cardNum", cardNo);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return (new LogDTO(
                        int.Parse(dr["LogID"].ToString()),
                        int.Parse(dr["LogTypeID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        dr["CardNo"].ToString(),
                        dr["LogDate"].ToString(),
                        int.Parse(dr["amout"].ToString()),
                        dr["details"].ToString(),
                        dr["cardNoTo"].ToString()
                        ));
                }

                conn.Close();
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public void StoreLog(int atm_id, string cardNumber, string created_at, int amount, int type = 1, string description = null, string toCard = null)
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string query = "INSERT INTO tblLog(LogTypeID, ATMID, CardNo, LogDate, Amout, Details, CardNoTo) VALUES(@type, @atmID, @cardNo, @logDate, @amout, @des, @cardNoTo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("type", type);
                cmd.Parameters.AddWithValue("atmID", atm_id);
                cmd.Parameters.AddWithValue("cardNo", cardNumber);
                cmd.Parameters.AddWithValue("logDate", created_at);
                cmd.Parameters.AddWithValue("amout", amount);
                if (description == null)
                {
                    cmd.Parameters.AddWithValue("des", description).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("des", description);
                }
                if (toCard == null)
                {
                    cmd.Parameters.AddWithValue("cardNoTo", toCard).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.AddWithValue("cardNoTo", toCard);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void GetLog(DataSet data, string cardNumber)
        {

            try
            {
                string query = "SELECT TOP 5 * FROM tblLog WHERE CardNo=@card OR CardNoTo=@cardNoTo ORDER BY LogID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("card", cardNumber);
                da.SelectCommand.Parameters.AddWithValue("cardNoTo", cardNumber);
                da.Fill(data, data.Tables[0].TableName);
            }
            catch (Exception)
            {
                //throw;
                return;
            }
        }

        public List<LogDTO> GetLogToDay(string stk)
        {
            try
            {
                conn.Open();
                List<LogDTO> list = new List<LogDTO>();
                string query = "SELECT * FROM tblLog WHERE CardNo=@card AND CONVERT(DATE, LogDate)=CONVERT(DATE,GETDATE()) AND LogTypeID=1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("card", stk);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LogDTO log = new LogDTO(
                        int.Parse(dr["LogID"].ToString()),
                        int.Parse(dr["LogTypeID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        dr["CardNo"].ToString(),
                        dr["LogDate"].ToString(),
                        int.Parse(dr["Amout"].ToString()),
                        dr["Details"].ToString(),
                        dr["CardNoTo"].ToString()
                        );
                    list.Add(log);
                }
                conn.Close();
                return list;
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
        }

    }
}
