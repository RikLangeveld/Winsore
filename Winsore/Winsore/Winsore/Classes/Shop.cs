using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{

    enum upgradeTypes
    {
        PlayerSpeed
    }

    class Shop
    {

        List<Upgrade> upgrades;

        public Shop()
        {
            upgrades = new List<Upgrade>();

            
        }

        /// <summary>
        /// A function for adding a new upgrade
        /// </summary>
        /// <param name="gameObject">Type of object where the upgrade belongs to</param>
        /// <param name="upgradeID">identifier for the upgrade</param>
        /// <returns></returns>
        public void AddUpgrade(SpriteGameObject gameObject, string upgradeID)
        {
            upgrades.Add(new PlayerUpgrade(gameObject, upgradeID));
        }

        /// <summary>
        /// A function for activating a specific upgrade
        /// </summary>
        /// <returns></returns>
        public void ActivateUpgrade()
        {
            (upgrades[0] as PlayerUpgrade).ActivateUpgrade();
        }
    }
}
