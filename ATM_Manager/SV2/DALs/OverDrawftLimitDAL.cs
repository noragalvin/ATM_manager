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
    public class OverDrawftLimitDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString());
        
        public OverDrawftLimitDTO GetThauChi(string stk)
        {
            try
            {
                conn.Open();
                string query = "SELECT *, tblOverDrawftLimit.Value FROM tblOverDrawftLimit, tblAccount WHERE AccountNo=@card AND tblAccount.ODID = tblOverDrawftLimit.ODID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("card", stk);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    OverDrawftLimitDTO overDrawftLimit = new OverDrawftLimitDTO(
                        int.Parse(dr["ODID"].ToString()),
                        int.Parse(dr["Value"].ToString()));
                    conn.Close();
                    return overDrawftLimit;
                }
                conn.Close();
                return null;
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
        }
    }
}
