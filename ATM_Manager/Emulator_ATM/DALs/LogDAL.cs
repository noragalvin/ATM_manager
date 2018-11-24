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

        public LogDTO GetLastLog(int cardNo)
        {
            conn.Open();
            string query = "SELECT TOP 1 * FROM tblLog ORDER BY LogID DESC";
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

        public void StoreLog(int atm_id, string cardNumber, string created_at, int amount, int type = 1, string description = null, string toCard = null)
        {
            conn.Open();
            string query = "INSERT INTO tblLog(LogTypeID, ATMID, CardNo, LogDate, Amout, Details, CardNoTo) VALUES(@type, @atmID, @cardNo, @logDate, @amout, @details, @cardNoTo)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("type", type);
            cmd.Parameters.AddWithValue("atmID", atm_id);
            cmd.Parameters.AddWithValue("cardNo", cardNumber);
            cmd.Parameters.AddWithValue("logDate", created_at);
            cmd.Parameters.AddWithValue("amout", amount);
            cmd.Parameters.AddWithValue("details", description);
            cmd.Parameters.AddWithValue("cardNoTo", toCard);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void GetLog(DataSet data, string cardNumber)
        {
            /*
            conn.Open();
            List<LogDTO> list = new List<LogDTO>();
            string query = "SELECT TOP 10 * FROM tblLog ORDER BY LogID DESC";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr =  cmd.ExecuteReader();
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
             * */

            try
            {
                string query = "SELECT TOP 10 * FROM tblLog WHERE CardNo=@card ORDER BY LogID DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("card", cardNumber);
                da.Fill(data, data.Tables[0].TableName);
            }
            catch (Exception)
            {
                //throw;
                return;
            }
        }
    }
}
