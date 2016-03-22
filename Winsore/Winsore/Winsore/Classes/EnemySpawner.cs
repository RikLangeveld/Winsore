using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Winsore.Classes
{
    class EnemySpawner : GameObjectList
    {
        private Enemy enemy;

        private List<Enemy> enemyList;

        float countDuration = 2f;
        float currentTime = 0f;

        public EnemySpawner()
        {
            //enemyList = new List<Enemy>(); //weet neit of dit nodig is
        }
        public override void Update(GameTime gameTime)
        {
            // telt ingame time op in currentime
            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            // als currentime groter is dan counduration (2sec) dan reset currentime naar 0 
            // en word er een enemy gespawned
            if (currentTime > countDuration)
            {
                currentTime -= countDuration;
                enemy = new Enemy("spr_enemy_idle@1x1", "spr_enemy_walking@2x1");
                Add(enemy);

                for (int i = gameObjects.Count - 1; i >= 0; --i)
                {
                    Enemy enemy = gameObjects[i] as Enemy;
                    if (enemy.CollidesWith(GW.Player))
                        Remove(gameObjects[i]);
                }
            }

            base.Update(gameTime);
        }

        public int Counter
        {
            get { return gameObjects.Count; }
        }
        // getter voor gameworld
        private GameWorld GW
        {
            get { return GameWorld as GameWorld; }
        }
    }
}
