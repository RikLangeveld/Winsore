using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Enemy : AnimatedGameObject
    {
        protected int health;           //Levenskracht van de enemy.
        protected int movementSpeed;    //Snelheid waarmee de enemy beweegt
        protected int dropAmount;       //Het aantal geld dat de enemy dropt. (Random?)

        protected float attackSpeed;    //De snelheid waarmee de enemy aanvalt.
        protected float damageToUnits;  //De aanvalskracht tegen units.
        protected float damageToWall;   //De aanvalskracht tegen de muur.

        protected float attackRange;    //De range waarop een enemy kan aanvallen, dus archer e.d. hebben hoge range, melee lage range
                                        //Stop met lopen door Wall collider - attackingRange
        protected float aggroRange;     //De range waarop een enemy de speler of zijn units achterna gaat in plaats van te focussen op de muur              

        public Enemy(string idleAnimation, string walkingAnimation) : base(0, "enemy")
        {
            LoadAnimation(idleAnimation, "idle", true);
            LoadAnimation(walkingAnimation, "walkingSide", true);
            PlayAnimation("walkingSide");

            Health = 100;
            CalculateRandomVelocity(50, 100);
            position = new Vector2(0, 300);
            attackRange = 25;
            aggroRange = 250;
            Mirror = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (velocity.X > 0 && GW.Player.Position.X > position.X)
            {
                PlayAnimation("walkingSide");
                Mirror = true;
            }
            else if (velocity.X > 0 && GW.Player.Position.X < position.X)
            {
                PlayAnimation("walkingSide");
                Mirror = false;
            }
            else if (velocity.X == 0 && GW.Player.Position.X > position.X)
            {
                PlayAnimation("idle");
                Mirror = true;
            }
            else if (velocity.X == 0 && GW.Player.Position.X < position.X)
            {
                PlayAnimation("idle");
                Mirror = false;
            }

            if (CollidesWith(GW.Player))
                velocity = Vector2.Zero;

            velocity = new Vector2(movementSpeed, 0);

            MoveTowardsUnit(GW.Player, AggroRange, AttackRange, gameTime);

            //If the enemy has a bad spawn position, reset the enemy.
            if (GW.IsOutsideRoomBelow(position.Y, Height) || GW.IsOutsideRoomAbove(position.Y, Height))
                Reset();

            //Replace with wall collision instead of room.
            if (GW.IsOutsideRoomRight(position.X + AttackRange.X, Width))
                velocity.X = 0;

            if (Health <= 0)
            {
                DropMoney(1, 2);
                //DELETE ENEMY
            }

            base.Update(gameTime);

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
        /// Move towards the target object when the target is within the aggro range
        /// Stop moving when the target object is within the attacking range
        /// </summary>
        /// <param name="target">The target object</param>
        /// <param name="range">The aggro range of the enemy</param>
        /// <param name="attackRange">The attacking range of the enemy</param>
        /// <param name="gameTime">Standard GameTime</param>
        public void MoveTowardsUnit(SpriteGameObject target, Vector2 range, Vector2 attackRange, GameTime gameTime)
        {
            Vector2 distanceToTarget = position - target.Position;
            Vector2 attackOffset = target.Position - position;

            if (Math.Abs(distanceToTarget.X) < range.X && Math.Abs(distanceToTarget.Y) < range.Y)
            {
                distanceToTarget.Normalize();

                if (Math.Abs(attackOffset.X) <= attackRange.X && Math.Abs(attackOffset.Y) <= attackRange.Y)
                    velocity = Vector2.Zero;
                else
                    velocity = new Vector2(movementSpeed / 2 / (float)gameTime.ElapsedGameTime.TotalMilliseconds,
                        movementSpeed / 2 / (float)gameTime.ElapsedGameTime.TotalMilliseconds);

                position -= distanceToTarget * velocity;
            }
            else
            {
                Mirror = true;
            }
        }

        /// <summary>
        /// Used to randomize drop amount to make the game a little bit more fun.
        /// </summary>
        /// <param name="minAmount">The minimal drop amount / 100. If you want to drop at least 200, set it to 2.</param>
        /// <param name="maxAmount">The maximal drop amount / 100. If you want to drop max 500, set it to 5.</param>
        /// <returns></returns>
        public void DropMoney(int minAmount, int maxAmount)
        {
            dropAmount = GameEnvironment.Random.Next(minAmount, maxAmount) * 100;
            GW.Player.Money += dropAmount;
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
                {
                    visible = false;
                }
            }
        }

        public int DamageToUnits
        {
            get { return (int)damageToUnits; }
        }

        public int DamageToWall
        {
            get { return (int)damageToWall; }
        }

        /// <summary>
        /// Maakt een Vector2 van de AttackRange zodat die makkelijker toe te passen is.
        /// </summary>
        private Vector2 AttackRange
        {
            get { return new Vector2(attackRange + BoundingBox.Width, attackRange + BoundingBox.Height); }
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
