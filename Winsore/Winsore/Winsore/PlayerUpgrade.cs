using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class PlayerUpgrade : Upgrade
    {

        string upgradeIdentifier;

        public PlayerUpgrade(SpriteGameObject isOfType, string upgradeID) : base(isOfType)
        {
            this.upgradeIdentifier = upgradeID;
        }

        public void ActivateUpgrade()
        {
            switch (upgradeIdentifier)
            {
                case "playerSpeed":
                    (isOfType as Player).playerSpeed += 20;
                    break;
                default:
                    break;
            }
        }
    }
}
