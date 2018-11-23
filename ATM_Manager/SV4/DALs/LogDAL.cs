
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

        public void GetLog(DataSet data)
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
            
            string query = "SELECT TOP 10 * FROM tblLog ORDER BY LogID DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(data, data.Tables[0].TableName);
        }
    }
}
