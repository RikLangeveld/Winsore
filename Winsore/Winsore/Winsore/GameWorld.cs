using GameManagement.gameobjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject background = null;
        private Player player;

        public GameWorld()
        {
            background = new SpriteGameObject("grass");
            player = new Player("spr_hero_placeholder");

            // Add the grass background to the gameWorld
            this.Add(background);

            this.Add(player);
        }

        public bool IsOutsideRoom(Vector2 position, int width, int height)
        {

            if (position.X > 0 && position.X + width  < Winsore.Screen.X &&
                position.Y > 0 && position.Y + height < Winsore.Screen.Y)
                return false;
            else
                return true;
        }
    }
}
