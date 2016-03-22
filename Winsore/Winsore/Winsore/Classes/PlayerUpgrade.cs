using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class PlayerUpgrade : Upgrade
    {

        UpgradeTypes upgradeIdentifier;

        /// <summary>
        /// Constructor of PlayerUpgrade
        /// </summary>
        /// <param name="isOfType">Type of object where the upgrade belongs to</param>
        /// <param name="upgradeID">identifier for the upgrade</param>
        /// <returns></returns>
        public PlayerUpgrade(SpriteGameObject isOfType, UpgradeTypes upgradeID) : base(isOfType)
        {
            this.upgradeIdentifier = upgradeID;
        }

        /// <summary>
        /// A function which activates a specific upgrade based on the upgradeIdentifier
        /// </summary>
        /// <returns></returns>
        public override void ActivateUpgrade()
        {
            switch (upgradeIdentifier)
            {
                case UpgradeTypes.PlayerSpeed:
                    (isOfType as Player).playerSpeed += 20;
                    break;
                default:
                    break;
            }
        }
    }
}
