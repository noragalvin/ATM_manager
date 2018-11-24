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
            //return new WithDrawLimitDTO(int.Parse(dr["Value"].ToString()));
        }
    }
}
