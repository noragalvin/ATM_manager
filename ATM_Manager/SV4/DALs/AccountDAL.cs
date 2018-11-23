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
    }
}
