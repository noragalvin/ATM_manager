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

        public void StoreLog(int atm_id, string cardNumber, string created_at, int amount, string description = "", int toCard = 0)
        {
            conn.Open();
            string query = "INSERT INTO tblLog(LogTypeID, ATMID, CardNo, LogDate, Amout, Details, CardNoTo) VALUES(1, @atmID, @cardNo, @logDate, @amout, @details, @cardNoTo)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("atmID", atm_id);
            cmd.Parameters.AddWithValue("cardNo", cardNumber);
            cmd.Parameters.AddWithValue("logDate", created_at);
            cmd.Parameters.AddWithValue("amout", amount);
            cmd.Parameters.AddWithValue("details", description);
            cmd.Parameters.AddWithValue("cardNoTo", toCard);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
