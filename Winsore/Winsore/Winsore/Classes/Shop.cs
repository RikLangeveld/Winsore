using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        GameObjectList shopBackground;

        SpriteGameObject shopBackgroundSprite;
        TextGameObject shopTitleText;
        TextGameObject shopUpgradeText;

        Dictionary<UpgradeTypes, Upgrade> upgrades;

        public Shop(string assetname) : base()
        {
            // initializ variables
            shopSprite = new SpriteGameObject(assetname);
            shopBackground = new GameObjectList();
            shopBackgroundSprite = new SpriteGameObject("shopBackground");
            shopTitleText = new TextGameObject("shopFont");
            shopUpgradeText = new TextGameObject("shopFont");
            upgrades = new Dictionary<UpgradeTypes, Upgrade>();

            // adding objects to shopBackground
            shopBackground.Add(shopBackgroundSprite);
            shopBackground.Add(shopTitleText);
            shopBackground.Add(shopUpgradeText);

            // set position
            shopSprite.Position = new Vector2(1700, 100);
            shopBackground.Position = new Vector2(1460, 40);


            shopTitleText.Text = "Upgrade Shop";
            shopTitleText.Position = new Vector2(100, 30);

            shopUpgradeText.Text = "Speed Upgrade";
            shopUpgradeText.Position = new Vector2(40, 200);

            // add to GameObjectList
            Add(shopSprite);

            shopBackground.Visible = false;

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

        public override void Update(GameTime gameTime)
        {
            if (GW.Player.Position.X > ShopSprite.Position.X
                    && GW.Player.Position.Y > ShopSprite.Position.Y
                    && GW.Player.Position.X < ShopSprite.Position.X + ShopSprite.Width
                    && GW.Player.Position.Y < ShopSprite.Position.Y + ShopSprite.Height)
            {
                shopBackground.Visible = true;
            } else
            {
                shopBackground.Visible = false;
            }

            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper)
        {

            if (shopBackground.Visible)
            {
                if (inputHelper.MouseLeftButtonPressed() 
                    && inputHelper.MousePosition.X > 1772 
                    && inputHelper.MousePosition.Y > 220
                    && inputHelper.MousePosition.X < 1835
                    && inputHelper.MousePosition.Y < 283
                    && GW.Player.Money >= 5)
                {
                    GW.Player.Money -= 5;
                    ActivateUpgrade(UpgradeTypes.PlayerSpeed);
                }
            }

        }

        public SpriteGameObject ShopSprite
        {
            get { return shopSprite; }
        }

        public GameObjectList ShopBackground
        {
            get { return shopBackground; }
        }

        public string ShopText
        {
            get { return shopTitleText.Text; }
            set { shopTitleText.Text = value; }
        }

        public GameWorld GW
        {
            get { return GameWorld as GameWorld; }
        }
    }
}
