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

        public Enemy(string assetname) : base(assetname)
        {
            position = new Vector2(0, 600);
            CalculateRandomVelocity(25, 100);
            Health = 100;
        }

        public void CalculateRandomVelocity(int minValue, int maxValue)
        {
            velocity.X = GameEnvironment.Random.Next(minValue, maxValue);
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                if (health <= 0)
                    visible = false;
            }
        }
    }
}
