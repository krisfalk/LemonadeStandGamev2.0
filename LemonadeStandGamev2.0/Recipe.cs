using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Recipe
    {
        int lemonsRecipe;
        int sugarRecipe;
        int iceRecipe;
        double sellPrice;
        public Recipe()
        {

        }
        public void SetRecipe(string name)
        {
            Console.WriteLine("{0}, please set your recipe:", name);
            SetLemonRecipe();
            SetSugarRecipe();
            SetIceRecipe();
            SetSellPrice();
        }
        public void SetLemonRecipe()
        { 
            Console.WriteLine("How many lemons per pitcher?");
            lemonsRecipe = Convert.ToInt32(Console.ReadLine());
        }
        public void SetSugarRecipe()
        {
            Console.WriteLine("How many cups of sugar per pitcher?");
            sugarRecipe = Convert.ToInt32(Console.ReadLine());
        }
        public void SetIceRecipe()
        {
            Console.WriteLine("How many ice cubes per cup?");
            iceRecipe = Convert.ToInt32(Console.ReadLine());
        }
        public void SetSellPrice()
        {
            Console.WriteLine("What would you like to set the price of lemonade at for today? \n(Price should be no lower than $0.20 and no higher than $1.00)");
            double answer = Convert.ToDouble(Console.ReadLine());
            if (answer >= .2 && answer <= 1.00)
            {
                sellPrice = answer;
            }
            else { SetSellPrice(); }
        }
        public int GetLemonRecipe()
        {
            return lemonsRecipe;
        }
        public int GetSugarRecipe()
        {
            return sugarRecipe;
        }
        public int GetIceRecipe()
        {
            return iceRecipe;
        }
        public double GetSellPrice()
        {
            return sellPrice;
        }
    }
}
