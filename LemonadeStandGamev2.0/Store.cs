using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Store
    {
        public Store()
        {

        }
        public void SellEachIngredients(Player player)
        {
            player.PrintPlayerStats();
            SellIngredients(player.inventory.AddCups(player), player);
            player.PrintPlayerStats();
            SellIngredients(player.inventory.AddLemons(player), player);
            player.PrintPlayerStats();
            SellIngredients(player.inventory.AddSugar(player), player);
            player.PrintPlayerStats();
            SellIngredients(player.inventory.AddIce(player), player);
            player.PrintPlayerStats();
        }
        public void SellIngredients(double totalSpent, Player player)
        {
            player.bank.SubtractMoney(totalSpent);
            player.bank.AddSpent(totalSpent);
        }
    }
}
