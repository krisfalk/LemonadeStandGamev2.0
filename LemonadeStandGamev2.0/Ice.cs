using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Ice : Item
    {
        public Ice()
        {
            name = "ice cubes";
            cost = .008;
        }
        public override void SpoilRate()
        {
            //everyday
        }
    }
}
