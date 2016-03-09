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
        protected int health;           //Levenskracht van de enemy.
        protected int movementSpeed;    //Snelheid waarmee de enemy beweegt
        protected float damageToUnits;  //De aanvalskracht tegen units.
        protected float damageToWall;   //De aanvalskracht tegen de muur.

        protected float attackRange;    //De range waarop een enemy kan aanvallen, dus archer e.d. hebben hoge range, melee lage range
                                        //Stop met lopen door Wall collider - attackingRange
        protected float aggroRange;     //De range waarop een enemy de speler of zijn units achterna gaat in plaats van te focussen op de muur                                    

        public Enemy(string assetname) : base(assetname)
        {
            Reset();
        }

        public override void Update(GameTime gameTime)
        {
            if (CollidesWith(GW.Player))
                velocity.X = 0;
            else velocity.X = movementSpeed;

            //If the enemy has a bad spawn position, reset the enemy.
            if (GW.IsOutsideRoomBelow(position, Height) || GW.IsOutsideRoomAbove(position, Height))
                Reset();

            //Replace with wall collision instead of room.
            if (GW.IsOutsideRoomRight(position + AttackRange, Width))
                velocity.X = 0;

            base.Update(gameTime);

        }
        
        /// <summary>
        /// Debugging only.
        /// </summary>
        /// <param name="inputHelper"></param>
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Z))
                Reset();
        }

        public override void Reset()
        {
            base.Reset();

            Health = 100;
            CalculateRandomVelocity(500, 500);
            CalculateRandomStartingPosition(0, Winsore.Screen.Y);
            attackRange = 200;
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

        /// <summary>
        /// Maakt een Vector2 van de AttackRange zodat die makkelijker toe te passen is.
        /// </summary>
        private Vector2 AttackRange
        {
            get { return new Vector2(attackRange, attackRange); }
        }

        /// <summary>
        /// Maakt een Vector2 van de AggroRange zodat die makkelijker toe te passen is.
        /// </summary>
        private Vector2 AggroRange
        {
            get { return new Vector2(aggroRange, aggroRange); }
        }

        /// <summary>
        /// Returns Something.... because null...
        /// </summary>
        private GameWorld GW
        {
            get { return GameWorld as GameWorld; }
        }
    }
}
