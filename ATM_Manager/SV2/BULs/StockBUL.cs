using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class StockBUL
    {
        StockDAL stockDAL = new StockDAL();
        AccountDAL accountDAL = new AccountDAL();
        MoneyDAL moneyDAL = new MoneyDAL();

        public int GetTotalMoney()
        {
            List<StockDTO> stock = new List<StockDTO>();
            stock = stockDAL.GetListStock();
            int total = 0;
            foreach (StockDTO item in stock)
            {
                if(item.MoneyID == 1)
                    total += item.Quantity * 20000;
                if (item.MoneyID == 2)
                    total += item.Quantity*50000;
                if (item.MoneyID == 3)
                    total += item.Quantity*100000;
                if (item.MoneyID == 4)
                    total += item.Quantity*200000;
                if (item.MoneyID == 5)
                    total += item.Quantity*500000;
            }
            return total;
        }

        public int GetMinWithDraw()
        {
            WithDrawLimitDTO minDraw = new WithDrawLimitDTO();
            minDraw = stockDAL.GetMinWithDraw();
            return minDraw.Value;
        }

        public int GetNumberOfMoney(int moneyValue)
        {
            StockDTO stock = new StockDTO();
            stock = stockDAL.GetNumberOfMoney(moneyValue);
            return stock.Quantity;
        }

        public void UpdateNumberOfMoney(int value, int number)
        {
            stockDAL.UpdateNumberOfMoney(value, number);
        }

        public int GetCurrentMoney()
        {
            AccountDTO accountDTO = new AccountDTO();
            accountDTO = accountDAL.GetCurrentMoney();
            return accountDTO.Balance;
        }

        public void UpdateMoney(int money)
        {
            moneyDAL.UpdateMoney(money);
        }

        public int WithDraw(int money)
        {
            int totalMoney = GetTotalMoney();
            int minMoney = GetMinWithDraw();
            int currentMoney = GetCurrentMoney();
            int requiredMoney = money;
            if (money % 50000 != 0)
                return 0; //So tien khong chia het cho 50000
            if (money > currentMoney)
            {
                return 1; //So tien trong tai khoan khong du
            }
            if (money > minMoney)
            {
                return 2; //Chi duoc rut toi da 5000000
            }

            if (money > totalMoney)
            {
                return 3; //So tien trong cay ATM khong du
            }

            int number20 = GetNumberOfMoney(20);
            int number50 = GetNumberOfMoney(50);
            int number100 = GetNumberOfMoney(100);
            int number200 = GetNumberOfMoney(200);
            int number500 = GetNumberOfMoney(500);
            if (money / 500000 > 0 && number500 > 0)
            {
                int soToTienTieuThu = money / 500000;
                if (soToTienTieuThu >= number500)
                {
                    money = money - number500 * 500000;
                    UpdateNumberOfMoney(500, 0);
                }
                else
                {
                    number500 = number500 - soToTienTieuThu;
                    money = money - soToTienTieuThu * 500000;
                    UpdateNumberOfMoney(500, number500);
                }
            }
            if (money / 200000 > 0 && number200 > 0)
            {
                int soToTienTieuThu = money / 200000;
                if (soToTienTieuThu >= number200)
                {
                    money = money - number200 * 200000;
                    UpdateNumberOfMoney(200, 0);
                }
                else
                {
                    number200 = number200 - soToTienTieuThu;
                    money = money - soToTienTieuThu * 200000;
                    UpdateNumberOfMoney(200, number200);
                }
            }
            if (money / 100000 > 0 && number100 > 0)
            {
                int soToTienTieuThu = money / 100000;
                if (soToTienTieuThu >= number100)
                {
                    money = money - number100 * 100000;
                    UpdateNumberOfMoney(100, 0);
                }
                else
                {
                    number100 = number100 - soToTienTieuThu;
                    money = money - soToTienTieuThu * 100000;
                    UpdateNumberOfMoney(100, number100);
                }
            }
            if (money / 50000 > 0 && number50 > 0)
            {
                int soToTienTieuThu = money / 50000;
                if (soToTienTieuThu >= number50)
                {
                    money = money - number50 * 50000;
                    UpdateNumberOfMoney(50, 0);
                }
                else
                {
                    number50 = number50 - soToTienTieuThu;
                    money = money - soToTienTieuThu * 50000;
                    UpdateNumberOfMoney(50, number50);
                }
            }
            if (money / 50000 > 0 && number20 > 0)
            {
                int soToTienTieuThu = money / 20000;
                if (soToTienTieuThu >= number50)
                {
                    money = money - number20 * 20000;
                    UpdateNumberOfMoney(20, 0);
                }
                else
                {
                    number20 = number20 - soToTienTieuThu;
                    money = money - soToTienTieuThu * 20000;
                    UpdateNumberOfMoney(20, number20);
                }
            }

            UpdateMoney(currentMoney - requiredMoney);

            return 4; //Thanh cong
        }
    }
}
