using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject background;
        private Player player;
        private Enemy enemy;
        private Projectile projectile;
        private Shop shop;
        private SpriteGameObject CastleSpriteTest;
        private DebugMenu debugMenu;



        protected Vector2 SCREEN_SIZE = new Vector2(1920, 1080);

        public GameWorld()
        {
            background = new SpriteGameObject("grass");
            player = new Player();
            enemy = new Enemy("spr_enemy_idle@1x1", "spr_enemy_walking@2x1");
            projectile = new Projectile("arrow_projectile");

            CastleSpriteTest = new SpriteGameObject("spr_castle");

            shop = new Shop("winkelwagen");

            //add upgrade
            shop.AddUpgrade(player, UpgradeTypes.PlayerSpeed);

            debugMenu = new DebugMenu();


            // Add the grass background to the gameWorld
            this.Add(background);
            this.Add(CastleSpriteTest);

            // Add shop to the GameObjectList of gameworld
            this.Add(shop);

            // Add the player to the GameObjectList of gameWorld
            this.Add(player);
            this.Add(enemy);
            this.Add(projectile);

            CastleSpriteTest.Position = new Vector2 (1300,0);

            Add(shop.ShopBackground);
            Add(debugMenu);
        }

        /// <summary>
        /// A function to check if a spriteGameobject is Outside The room
        /// </summary>
        /// <param name="position">The position of the game object</param>
        /// <param name="width"> The width of the SpriteObject</param>
        /// <param name="height">The heigth of the SpriteObject</param>
        /// <returns></returns>
        public bool IsOutsideRoom(Vector2 position, int width, int height)
        {

            if (position.X > 0 && position.X + width  < Winsore.Screen.X &&
                position.Y > 0 && position.Y + height < Winsore.Screen.Y)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Used to check if a object is out of the room on the right side
        /// </summary>
        /// <param name="position">position of the object</param>
        /// <param name="width">width of the object</param>
        /// <returns></returns>
        public bool IsOutsideRoomRight(float positionX, int width)
        {
            if (positionX + width/2 > 1920)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Used to check if a object is out of the room on the left side
        /// </summary>
        /// <param name="position">position of the object</param>
        /// <param name="width">width of the object</param>
        /// <returns></returns>
        public bool IsOutsideRoomLeft(float positionX, int width)
        {
            if (positionX - width/2 < 0)
                return true;
            else
                return false;            
        }

        /// <summary>
        /// Used to check if a object is below the view.
        /// </summary>
        /// <param name="position">position of the object</param>
        /// <param name="width">width of the object</param>
        /// <returns></returns>
        public bool IsOutsideRoomBelow(float positionY, int height)
        {
            if (positionY > 1080)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Used to check if a object is above the view.
        /// </summary>
        /// <param name="position">position of the object</param>
        /// <param name="width">width of the object</param>
        /// <returns></returns>
        public bool IsOutsideRoomAbove (float positionY, int height)
        {
            if (positionY - height < 0 )
                return true;
            else
                return false;
        }

        public Vector2 ScreenSize
        {
            get { return SCREEN_SIZE; }
        }

        

        public Player Player
        {
            get { return player; }
        }

        public Shop Shop
        {
            get { return shop; }
        }
    }
}
