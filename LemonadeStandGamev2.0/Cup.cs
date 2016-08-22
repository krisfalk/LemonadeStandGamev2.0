using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Cup : Item
    {
        public Cup()
        {
            name = "cups";
            cost = .03;
        }
        public override void SpoilRate()
        {
            //none
        }
    }
}
