﻿using Microsoft.Xna.Framework;
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
        private Shop shop;

        public GameWorld()
        {
            background = new SpriteGameObject("grass");
            player = new Player("spr_hero_placeholder");
            enemy = new Enemy("spr_enemy_placeholder");
            shop = new Shop();

            //add upgrade
            shop.AddUpgrade(player, "playerSpeed");

            // Add the grass background to the gameWorld
            this.Add(background);
            // Add the player to the GameObjectList of gameWorld
            this.Add(player);
            this.Add(enemy);
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
            if (positionX + width > Winsore.Screen.X)
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
        public bool IsOutsideRoomLeft(float positionX)
        {
            if (positionX < 0)
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
            if (positionY + height > Winsore.Screen.Y)
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
            if (positionY <0 )
                return true;
            else
                return false;
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
