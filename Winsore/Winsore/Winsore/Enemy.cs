using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Enemy : SpriteGameObject
    {
        protected int health;
        protected float damageToUnits;
        protected float damageToWall;
        //TO-DO: Add Aggro Range for units and player

        public Enemy(string assetname) : base(assetname)
        {
            position = new Vector2(0, 600);
            CalculateRandomVelocity(25, 100);
            Health = 100;
        }

        /// <summary>
        /// Calculates a random horizontal velocity between the Minimum Value and Maximum Value provided.
        /// </summary>
        /// <param name="minValue">The minimal velocity of the enemy</param>
        /// <param name="maxValue">The maximal velocity of the enemy</param>
        public void CalculateRandomVelocity(int minValue, int maxValue)
        {
            velocity.X = GameEnvironment.Random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Return the health of the enemy or Set the health to a certain amount.
        /// </summary>
        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                if (health <= 0)
                    visible = false;
            }
        }
    }
}
