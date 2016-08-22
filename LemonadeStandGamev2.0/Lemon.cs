using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Lemon : Item
    {
        public Lemon()
        {
            this.name = "lemons";
            cost = .06;
        }
        public override void SpoilRate()
        {
            //every 3 days, 5 lemons spoil
        }
    }
}
