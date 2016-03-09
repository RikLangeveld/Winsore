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

            
        }

        public void AddUpgrade(SpriteGameObject gameObject, string upgradeID)
        {
            upgrades.Add(new PlayerUpgrade(gameObject, upgradeID));
        }

        public void ActivateUpgrade()
        {
            (upgrades[0] as PlayerUpgrade).ActivateUpgrade();
        }
    }
}
