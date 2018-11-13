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
        public bool isValidCard(string pin)
        {
            conn.Open();
            string querry = "SELECT * FROM tblCard WHERE PIN=@pin";
            SqlCommand cmd = new SqlCommand(querry, conn);
            cmd.Parameters.AddWithValue("pin", pin);
            int isExist = (int)cmd.ExecuteScalar();
            conn.Close();

            if (isExist > 0)
                return true;
            return false;
        }
    }
}
