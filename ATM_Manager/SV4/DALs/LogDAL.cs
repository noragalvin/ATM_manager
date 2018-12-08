
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
                throw;
                return;
            }
        }

        
    }
}
