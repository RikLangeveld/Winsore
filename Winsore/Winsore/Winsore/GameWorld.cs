using GameManagement.gameobjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        private Enemy enemy;

        public GameWorld()
        {
            background = new SpriteGameObject("grass");
            player = new Player("spr_hero_placeholder");
            enemy = new Enemy("spr_enemy_placeholder");
            
            // Add the grass background to the gameWorld
            Add(background);

            Add(player);
            Add(enemy);
        }
    }
}
