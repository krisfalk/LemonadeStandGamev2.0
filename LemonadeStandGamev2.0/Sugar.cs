using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Sugar : Item
    {
        public Sugar()
        {
            name = "cups of sugar";
            cost = .06;
        }
        public override void SpoilRate()
        {
            //every 10 days, 10 spoils
        }
    }
}
