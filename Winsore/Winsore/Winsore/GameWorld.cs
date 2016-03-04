using GameManagement.gameobjects;
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
    }
}
