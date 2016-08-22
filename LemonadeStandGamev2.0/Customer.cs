using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Customer
    {
        int number;
        public Customer(int Number)
        {
            number = Number;
        }
        public int GetCustomerNumber()
        {
            return number;
        }
        public bool CheckBuyOrNot(Weather currentDay, Player player)
        {
            int chanceCounter = 1;
            Thread.Sleep((int)TimeSpan.FromSeconds(.2).TotalMilliseconds);
            Random random = new Random();

            chanceCounter += CheckWeatherAndCost(currentDay.CheckWeatherType(), player.recipe.GetSellPrice());
            chanceCounter += CheckRecipeRatio(player);
            chanceCounter += CheckIceAmount(player);
            chanceCounter += CheckForPerfectRecipe(player);

            if(random.Next(1, chanceCounter) == 1) { return true; } else { return false; }
        }
        public int CheckWeatherAndCost(int weather, double setPrice)
        {
            if(weather < 60 && setPrice <= .30 || weather < 70 && setPrice <= .45 || weather < 80 && setPrice <= .60 || weather < 90 && setPrice <= .75 || weather >= 90 && setPrice <= .90)
            {
                return 0;
            }else
            {
                return 10;
            }
        }
        public int CheckRecipeRatio(Player player)
        {
            if (player.recipe.GetLemonRecipe() - player.recipe.GetSugarRecipe() <= 3 && player.recipe.GetLemonRecipe() - player.recipe.GetSugarRecipe() >= -3)
            {
                return 0;
            }else
            {
                return 5;
            }
        }
        public int CheckIceAmount(Player player)
        {
            if (player.recipe.GetIceRecipe() >= 8 && player.recipe.GetIceRecipe() <= 12)
            {
                return 0;
            }
            else
            {
                return 3;
            }
        }
        public int CheckForPerfectRecipe(Player player)
        {
            if (player.recipe.GetLemonRecipe() == 8 && player.recipe.GetSugarRecipe() == 8 && player.recipe.GetIceRecipe() == 10)
            {
                return 0;
            }else
            {
                return 4;
            }
        }
    }
}
