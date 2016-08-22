using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Bank
    {
        double currentMoney;
        double totalIncome;
        double totalSpent;
        public Bank()
        {
            currentMoney = 20.00;
            totalIncome = 0;
            totalSpent = 0;
        }
        public bool CheckFunds(double cost)
        {
            if(cost <= currentMoney)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Not enough funds for that.");
                return false;
            }
        }
        public void SubtractMoney(double amount)
        {
            currentMoney -= amount;
        }
        public void AddMoney(double amount)
        {
            currentMoney += amount;
        }
        public void AddIncome(double amount)
        {
            totalIncome += amount;
        }
        public void AddSpent(double amount)
        {
            totalSpent += amount;
        }
        public double GetMoney()
        {
            return currentMoney;
        }
        public double GetIncome()
        {
            return totalIncome;
        }
        public double GetSpent()
        {
            return totalSpent;
        }
        public double GetLiquidated(Player player)
        {
            return (player.inventory.CountCups() * player.inventory.cups[0].GetCost()) + (player.inventory.CountLemons() * player.inventory.lemons[0].GetCost()) + (player.inventory.CountSugar() * player.inventory.sugars[0].GetCost());
        }
        public double GetProfitLoss(Player player)
        {
            return (player.bank.GetIncome() - player.bank.GetSpent()) + GetLiquidated(player);
        }
    }
}
