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

    }
}
