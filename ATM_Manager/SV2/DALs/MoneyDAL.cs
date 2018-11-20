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
    public class MoneyDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString());

        public void UpdateMoney(int money)
        {
            try
            {
                conn.Open();
                string query = "UPDATE tblAccount SET Balance=@value WHERE AccountNO=45010005597808";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("value", money);
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
