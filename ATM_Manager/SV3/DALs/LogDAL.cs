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

        public void StoreLog(int atm_id, string cardNumber, string created_at, int amount, string description = null, string toCard = null)
        {
            try
            {
                conn.Open();
                string query = "INSERT INTO tblLog(LogTypeID, ATMID, CardNo, LogDate, Amout, Details, CardNoTo) VALUES(2, @atmID, @cardNo, @logDate, @amout, @details, @cardNoTo)";
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
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
