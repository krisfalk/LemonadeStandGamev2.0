using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Popularity
    {
        int popularityLevel;
        public Popularity()
        {
            popularityLevel = 0;
        }
        public int GetPopularityLevel()
        {
            return popularityLevel;
        }
        public int BonusCustomers()
        {
            if (popularityLevel < 10)
            {
                return 100;
            }
            else if (popularityLevel < 20)
            {
                return 105;
            }
            else if (popularityLevel < 30)
            {
                return 110;
            }
            else if (popularityLevel < 40)
            {
                return 115;
            }
            else if (popularityLevel < 50)
            {
                return 120;
            }
            else if (popularityLevel < 60)
            {
                return 125;
            }
            else if (popularityLevel < 70)
            {
                return 130;
            }
            else if (popularityLevel < 80)
            {
                return 135;
            }
            else if (popularityLevel < 90)
            {
                return 140;
            }
            else
            {
                return 145;
            }
        }
        public void AddToPopularity(int cupsBought)
        {
            if (cupsBought < 15)
            {
                if (popularityLevel > 20)
                {
                    popularityLevel -= 20;
                }
                else
                {
                    popularityLevel = 0;
                }
            }
            else if (cupsBought < 30)
            {
                if (popularityLevel <= 85)
                {
                    popularityLevel += 15;
                }
                else
                {
                    popularityLevel = 100;
                }
            }
            else if (cupsBought < 60)
            {
                if (popularityLevel <= 80)
                {
                    popularityLevel += 20;
                }
                else
                {
                    popularityLevel = 100;
                }
            }
            else
            {
                popularityLevel += 25;
            }
            Console.WriteLine("Your popularity level is at {0}%.", popularityLevel);
        }
        public void LoadPopularity(int number)
        {
            popularityLevel = number;
        }
    }
}
