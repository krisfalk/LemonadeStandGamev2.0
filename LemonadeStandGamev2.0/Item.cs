using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    public abstract class Item
    {
        protected string name;
        protected double cost;
        public abstract void SpoilRate();

        public string GetName()
        {
            return name;
        }
        public double GetCost()
        {
            return cost;
        }
    }
}
