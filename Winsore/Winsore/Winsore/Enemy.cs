using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Enemy : SpriteGameObject
    {
        protected int health;
        protected int movementSpeed;
        protected float damageToUnits;
        protected float damageToWall;
        //TO-DO: Add Aggro Range for units and player

        public Enemy(string assetname) : base(assetname)
        {
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            GameWorld cgw = GameWorld as GameWorld;

            if (CollidesWith(cgw.Player))
                velocity.X = 0;
            else velocity.X = movementSpeed;

            //If the enemy has a bad spawn position, reset the enemy.
            if (cgw.IsOutsideRoomBelow(position.Y, Height) || cgw.IsOutsideRoomAbove(position.Y, Height))
                Reset();

            base.Update(gameTime);

        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Z))
                Reset();
        }

        public override void Reset()
        {
            base.Reset();

            Health = 100;
            CalculateRandomVelocity(25, 100);
            CalculateRandomStartingPosition(0, Winsore.Screen.Y);
        }

        /// <summary>
        /// Calculates a random horizontal velocity between the Minimum Value and Maximum Value provided.
        /// </summary>
        /// <param name="minValue">The minimal velocity of the enemy</param>
        /// <param name="maxValue">The maximal velocity of the enemy</param>
        public void CalculateRandomVelocity(int minValue, int maxValue)
        {
            movementSpeed = GameEnvironment.Random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Calculates a random starting position for the enemy..
        /// THIS SHOULD BE MOVED WHEN WE HAVE AN ENEMY SPAWNER CLASS/OBJECT.
        /// </summary>
        /// <param name="minValue">The minimal starting Y position of the enemy</param>
        /// <param name="maxValue">The maximal starting Y position of the enemy</param>
        public void CalculateRandomStartingPosition(int minValue, int maxValue)
        {
            position = new Vector2(-65, GameEnvironment.Random.Next(minValue, maxValue));
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
