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
    public class CardDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString()); 
        public CardDTO getValidCard(string pin)
        {
            try
            {
                conn.Open();
                string querry = "SELECT * FROM tblCard WHERE PIN=@mapin";
                SqlCommand cmd = new SqlCommand(querry, conn);
                cmd.Parameters.AddWithValue("mapin", pin);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                CardDTO card = new CardDTO(
                    dr["CardNO"].ToString(),
                    int.Parse(dr["Status"].ToString()),
                    int.Parse(dr["AccountID"].ToString()),
                    dr["PIN"].ToString(),
                    dr["StartDate"].ToString(),
                    dr["ExpiredDate"].ToString(),
                    int.Parse(dr["Attempt"].ToString()));
                return card;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
