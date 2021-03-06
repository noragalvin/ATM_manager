﻿using DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class StockDAL
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString());

        public List<StockDTO> GetListStock()
        {
            try
            {
                conn.Open();
                List<StockDTO> list = new List<StockDTO>();
                string query = "SELECT * FROM tblStock";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    StockDTO stock = new StockDTO(
                        int.Parse(dr["StockID"].ToString()),
                        int.Parse(dr["MoneyID"].ToString()),
                        int.Parse(dr["ATMID"].ToString()),
                        int.Parse(dr["Quantity"].ToString()));
                    list.Add(stock);
                }
                conn.Close();
                return list;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public WithDrawLimitDTO GetMinWithDraw(string stk)
        {
            try
            {
                conn.Open();
                string query = "SELECT *, tblWithDrawLimit.Value FROM tblWithDrawLimit, tblAccount WHERE AccountNo=@card AND tblAccount.WDID = tblWithDrawLimit.WDID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("card", stk);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    WithDrawLimitDTO widthDrawLimitDTO = new WithDrawLimitDTO(
                        int.Parse(dr["WDID"].ToString()),
                        int.Parse(dr["Value"].ToString()));
                    conn.Close();
                    return widthDrawLimitDTO;
                }
                conn.Close();
                return null;
            }
            catch (Exception)
            {
                //throw;
                return null;
            }
            //return new WithDrawLimitDTO(int.Parse(dr["Value"].ToString()));
        }

        public StockDTO GetNumberOfMoney(int moneyValue)
        {
            try
            {
                conn.Open();
                switch (moneyValue)
                {
                    case 20: moneyValue = 1; break;
                    case 50: moneyValue = 2; break;
                    case 100: moneyValue = 3; break;
                    case 200: moneyValue = 4; break;
                    case 500: moneyValue = 5; break;
                }
                string query = "SELECT Quantity FROM tblStock WHERE MoneyID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("id", moneyValue);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    StockDTO stock = new StockDTO(int.Parse(dr["Quantity"].ToString()));
                    conn.Close();
                    return stock;
                }
                conn.Close();
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public void UpdateNumberOfMoney(int value, int number)
        {
            try
            {
                conn.Open();
                string query = "UPDATE tblStock SET Quantity=@num WHERE MoneyID=@idMoney";
                int id = 0;
                switch (value)
                {
                    case 20: id = 1; break;
                    case 50: id = 2; break;
                    case 100: id = 3; break;
                    case 200: id = 4; break;
                    case 500: id = 5; break;
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("num", number);
                cmd.Parameters.AddWithValue("idMoney", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
