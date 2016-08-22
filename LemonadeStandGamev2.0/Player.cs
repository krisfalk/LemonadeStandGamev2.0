using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Player
    {
        public Inventory inventory;
        public Bank bank;
        public Recipe recipe;
        public Popularity popularity;
        string name;
        public Player(string Name)
        {
            this.name = Name;
            inventory = new Inventory();
            bank = new Bank();
            recipe = new Recipe();
            popularity = new Popularity();
        }
        public string GetName()
        {
            return name;
        }
        public void PrintFunds()
        {
            Console.WriteLine("{0} has ${1:0.00}.", name, bank.GetMoney());
        }
        public void PrintPlayerStats()
        {
            Console.Clear();
            Console.WriteLine("{0} has ${1:0.00}.\nCups: {2}\nLemons: {3}\nCups of Sugar: {4}\nIce Cubes: {5}",name,bank.GetMoney(),inventory.CountCups(),inventory.CountLemons(),inventory.CountSugar(),inventory.CountIce());
        }
        public void PrintPlayerBankFinal(Player player)
        {
            Console.WriteLine("{0}, your final total:\nTotal Income: {1:0.00}\nTotal Expenses: {2:0.00}\nLiquidated Inventory Value: {3:0.00}\nNet Profit/Loss: {4:0.00}\n", name, bank.GetIncome(), bank.GetSpent(), bank.GetLiquidated(player), bank.GetProfitLoss(player));
        }
    }
}
