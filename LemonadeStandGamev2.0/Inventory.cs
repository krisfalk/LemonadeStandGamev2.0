using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Inventory
    {
        public List<Cup> cups;
        public List<Lemon> lemons;
        public List<Sugar> sugars;
        public List<Ice> iceCubes;
        int pitcher;
        public Inventory()
        {
            pitcher = 0;
            cups = new List<Cup>();
            lemons = new List<Lemon>();
            sugars = new List<Sugar>();
            iceCubes = new List<Ice>();
        }
        public void SetPitcher(Player player)
        {
            if (lemons.Count - player.recipe.GetLemonRecipe() >= 0 && sugars.Count - player.recipe.GetSugarRecipe() >= 0)
            {
                SubtractLemons(player.recipe.GetLemonRecipe());
                SubtractSugar(player.recipe.GetSugarRecipe());
                pitcher = 15;
            }
            else
            {
                pitcher = 0;
            }
        }
        public int GetPitcher()
        {
            return pitcher;
        }
        public void SubtractFromPitcher()
        {
            pitcher--;
        }
        public double AddCups(Player player)
        {
            Cup cup = new Cup();
            int number = CheckNumber(cup.GetName(), cup.GetCost(), player);
            for (int i = 0; i < number; i++)
            {
                cups.Add(new Cup());
            }
            return CountCups() * cup.GetCost();
        }
        public double AddLemons(Player player)
        {
            Lemon lemon = new Lemon();
            int number = CheckNumber(lemon.GetName(), lemon.GetCost(), player);
            for (int i = 0; i < number; i++)
            {
                lemons.Add(new Lemon());
            }
            return CountLemons() * lemon.GetCost();
        }
        public double AddSugar(Player player)
        {
            Sugar sugar = new Sugar();
            int number = CheckNumber(sugar.GetName(), sugar.GetCost(), player);
            for (int i = 0; i < number; i++)
            {
                sugars.Add(new Sugar());
            }
            return CountSugar() * sugar.GetCost();
        }
        public double AddIce(Player player)
        {
            Ice ice = new Ice();
            int number = CheckNumber(ice.GetName(), ice.GetCost(), player);
            for (int i = 0; i < number; i++)
            {
                iceCubes.Add(ice = new Ice());
            }
            return CountIce() * ice.GetCost();
        }
        public void SubtractCups(int number)
        {
            for (int i = 0; i < number; i++)
            {
                cups.RemoveAt(0);
            }

        }
        public void SubtractLemons(int number)
        {
            for (int i = 0; i < number; i++)
            {
                lemons.RemoveAt(0);
            }
        }
        public void SubtractSugar(int number)
        {
            for (int i = 0; i < number; i++)
            {
                sugars.RemoveAt(0);
            }
        }
        public void SpoilIce(int number)
        {
            Console.WriteLine("At the end of day, all your ice has melted.\nPress enter to continue.");
            for (int i = 0; i < number; i++)
            {
                iceCubes.RemoveAt(0);
            }
            Console.ReadLine();
        }
        public void SubtractIce(int number)
        {
            for (int i = 0; i < number; i++)
            {
                iceCubes.RemoveAt(0);
            }
        }
        public int CountCups()
        {
            return cups.Count;
        }
        public int CountLemons()
        {
            return lemons.Count;
        }
        public int CountSugar()
        {
            return sugars.Count;
        }
        public int CountIce()
        {
            return iceCubes.Count;
        }
        public int CheckNumber(string name, double cost, Player player)
        {
            bool stillBuying = true;
            int total = 0;
            while (stillBuying)
            {
                player.PrintFunds();
                Console.WriteLine("{0}, how many {1} do you want to buy at ${2} each? Or enter '0' to continue.", player.GetName(), name, cost);
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer != 0 && player.bank.CheckFunds(answer * cost))
                {
                    player.bank.SubtractMoney(answer * cost);

                    total += answer;
                }
                else if(answer == 0)
                {
                    stillBuying = false;
                }
            }
            return total;
        }
        public void LoadCups(int number)
        {
            for (int i = 0; i < number; i++)
            {
                cups.Add(new Cup());
            }
        }
        public void LoadLemons(int number)
        {
            for (int i = 0; i < number; i++)
            {
                lemons.Add(new Lemon());
            }
        }
        public void LoadSugar(int number)
        {
            for (int i = 0; i < number; i++)
            {
                sugars.Add(new Sugar());
            }
        }
    }
}
