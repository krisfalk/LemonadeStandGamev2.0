using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Day
    {
        int dayNumber;
        int totalDays;
        public Weather today;
        public Weather tomorrow;
        public Day()
        {
            dayNumber = 1;
            today = new Weather();
            Thread.Sleep(500);
            tomorrow = new Weather();
        }
        public int GetDayNumber()
        {
            return dayNumber;
        }
        public int GetTotalDays()
        {
            return totalDays;
        }
        public void AdvanceDay()
        {
            dayNumber++;
            today = tomorrow;
            tomorrow = new Weather();
        }
        public void AskNumberDays()
        {
            Console.WriteLine("How many days do you want to play?");
            totalDays = Convert.ToInt32(Console.ReadLine());
        }
        public void RunPlayerDay(Player player, Customer[] customers)
        {
            int cupsPurchased = 0;
            for (int i = 0; i < customers.Length; i+=0)
            {
                player.inventory.SetPitcher(player);
                if (player.inventory.GetPitcher() != 0 && player.inventory.CountCups() - 15 > 0 && player.inventory.CountIce() - 15 * player.recipe.GetIceRecipe() > 0)
                {
                    while (player.inventory.GetPitcher() > 0 && i < customers.Length)
                    {
                        if (customers[i].CheckBuyOrNot(today, player))
                        {
                            cupsPurchased++;
                            player.inventory.SubtractFromPitcher();
                            player.inventory.SubtractIce(player.recipe.GetIceRecipe());
                            player.inventory.SubtractCups(1);
                            Console.WriteLine("Customer {0} buys a cup of lemonade.", i + 1);
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Customer {0} passes by without buying.", i + 1);
                            i++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("SOLD OUT");
                    i++;
                }
            }
            double dailyEarnings = cupsPurchased * player.recipe.GetSellPrice();
            player.bank.AddIncome(dailyEarnings);
            player.bank.AddMoney(dailyEarnings);
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
            player.PrintPlayerStats();
            player.popularity.AddToPopularity(cupsPurchased);
            Console.WriteLine("On day {0} of {1}, you sold {2} cups of lemonade today and made ${3}.\nPress enter to continue.", dayNumber, totalDays, cupsPurchased, dailyEarnings);
            Console.ReadLine();
        }
        public void PrintDay()
        {
            Console.WriteLine("Today: {0} and {1} degrees.\nTomorrow's forcast: {2} and {3} degrees.", today.GetWeatherType(), today.GetTemperature(), tomorrow.GetWeatherType(), tomorrow.GetTemperature());
        }
        public void LoadDayNumber(int day)
        {
            dayNumber = day;
        }
        public void LoadTotalDays(int total)
        {
            totalDays = total;
        }
    }
}
