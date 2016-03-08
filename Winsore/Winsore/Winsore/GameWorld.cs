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
        private Enemy enemy, enemy2, enemy3;

        public GameWorld()
        {
            background = new SpriteGameObject("grass");
            player = new Player("spr_hero_placeholder");
            enemy = new Enemy("spr_enemy_placeholder");
            enemy2 = new Enemy("spr_enemy_placeholder");
            enemy3 = new Enemy("spr_enemy_placeholder");
            
            // Add the grass background to the gameWorld
            this.Add(background);

            this.Add(player);
            Add(enemy);
            Add(enemy2);
            Add(enemy3);
            enemy2.Position = new Vector2(0, 500);
            enemy3.Position = new Vector2(0, 400);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.A))
            {
                enemy.Health -= 20;
                Console.WriteLine(enemy.Health);
            }
        }
    }
}
