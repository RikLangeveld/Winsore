using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{

    enum UpgradeTypes
    {
        PlayerSpeed
    }

    class Shop : GameObjectList
    {

        SpriteGameObject shopSprite;
        TextGameObject shopText;

        Dictionary<UpgradeTypes, Upgrade> upgrades;

        public Shop(string assetname) : base()
        {
            // initializ variables
            shopSprite = new SpriteGameObject(assetname);
            shopText = new TextGameObject("shopFont");
            upgrades = new Dictionary<UpgradeTypes, Upgrade>();

            // set position
            shopSprite.Position = new Vector2(1700, 100);
            shopText.Position = new Vector2(300, 300);

            // add to GameObjectList
            Add(shopSprite);
            Add(shopText);
            
        }

        /// <summary>
        /// A function for adding a new upgrade
        /// </summary>
        /// <param name="gameObject">Type of object where the upgrade belongs to</param>
        /// <param name="upgradeID">identifier for the upgrade</param>
        /// <returns></returns>
        public void AddUpgrade(SpriteGameObject gameObject, UpgradeTypes upgradeID)
        {
            upgrades.Add(upgradeID, new PlayerUpgrade(gameObject, upgradeID));
        }

        /// <summary>
        /// A function for activating a specific upgrade
        /// </summary>
        /// <returns></returns>
        public void ActivateUpgrade(UpgradeTypes upgradeType)
        {
            upgrades[upgradeType].ActivateUpgrade();
        }

        public SpriteGameObject ShopSprite
        {
            get { return shopSprite; }
        }

        public string ShopText
        {
            get { return shopText.Text; }
            set { shopText.Text = value; }
        }
    }
}
