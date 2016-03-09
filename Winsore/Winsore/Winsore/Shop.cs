using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Shop
    {

        List<Upgrade> upgrades;

        public Shop()
        {
            upgrades = new List<Upgrade>();

            upgrades.Add(new Upgrade(new Player("spr_hero_placeholder")));
        }
    }
}
