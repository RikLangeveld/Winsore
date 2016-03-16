
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Player : AnimatedGameObject
    {
        protected Vector2 START_POSITION = new Vector2(600, 300);
        protected const int START_PLAYER_SPEED = 200;

        private bool movingRight = false;
        private bool movingLeft = false;
        private bool movingUp = false;
        private bool movingDown = false;

        private bool LastframeOutsideRoomAbove = false;
        private bool LastframeOutsideRoomBelow = false;
        private bool LastframeOutsideRoomRight = false;
        private bool LastframeOutsideRoomLeft = false;

        public int playerSpeed;

        private Vector2 lastFrameVelocity;

        protected int money;

        public Player() : base(0, "player")
        {
            this.LoadAnimation("spr_player_idle_down@1x1", "idleDown", true);
            this.LoadAnimation("spr_player_walking_down@2x1", "walkingDown", true);
            this.LoadAnimation("spr_player_walking_side@2x1", "walkingSide", true);
            this.LoadAnimation("spr_player_walking_up@2x1", "walkingUp", true);
            this.LoadAnimation("spr_player_idle_up", "idleUp", true);
            this.LoadAnimation("spr_player_side", "idleSide", true);

            position = START_POSITION;
            playerSpeed = START_PLAYER_SPEED;
            Money = 0;
            this.PlayAnimation("idleDown");
        }

        public override void Update(GameTime gameTime)
        {
            lastFrameVelocity = velocity;
            base.Update(gameTime);
        }

        // HandleInput functie voor de beweging van de Player. 
          public override void HandleInput(InputHelper input)
        {
            GameWorld pgw = GameWorld as GameWorld;

            // Check if is in the room before moving up.
             if (pgw.IsOutsideRoomAbove(position.Y, Height))
            {
                position = new Vector2(position.X, 0 + Height);
                movingUp = false;
                LastframeOutsideRoomAbove = true;
            }
            else if (input.IsKeyDown(Keys.W))
                movingUp = true;
            else
                movingUp = false;

            // check if in the room before moving down
             if (pgw.IsOutsideRoomBelow(position.Y, Height))
            {
                position = new Vector2(position.X, pgw.ScreenSize.Y);
                movingDown = false;
                LastframeOutsideRoomBelow = true;
            } 
            else  if (input.IsKeyDown(Keys.S))
                movingDown = true;
            else
                movingDown = false;

             //check if in teh room before moving left
             if (pgw.IsOutsideRoomLeft(position.X, Width))
             {
               position = new Vector2(0 + Width /2 , Position.Y);
               movingLeft = false;
                LastframeOutsideRoomLeft = true;
             }
             else if (input.IsKeyDown(Keys.A))
                movingLeft = true;
            else
                movingLeft = false;

            // check if in the room before moving right
            if (pgw.IsOutsideRoomRight(position.X, Width))
             {
                position = new Vector2(pgw.ScreenSize.X - Width / 2, Position.Y);
                movingRight = false;
                LastframeOutsideRoomRight = true;
             }
            else if (input.IsKeyDown(Keys.D))
                movingRight = true;
            else
                movingRight = false;

            // adjust the veloctiy on the directions you are moving.

            /* This part is to manage the y movement/ animation */

            //moving up and down on the same time
            if (movingUp && movingDown)
            {
                velocity.Y = 0;               
            }
            // Moving down
            else if (movingDown && !LastframeOutsideRoomBelow)
            {
                velocity.Y = playerSpeed;
                LastframeOutsideRoomAbove = false;
            }
            // Moving upwards
            else if (movingUp && !LastframeOutsideRoomAbove)
            {
                velocity.Y = -playerSpeed;
                LastframeOutsideRoomBelow = false;
            }
            // not moving up or down
            else if (!movingUp && !movingDown)
            {
                velocity.Y = 0;
            }

            // moving left and right on the same time
            if (movingLeft && movingRight)
                velocity.X = 0;

            // moving Left
            else if (movingLeft && !LastframeOutsideRoomLeft)
            {
                velocity.X = -playerSpeed;
                LastframeOutsideRoomRight = false;
            }
            // moving Right
            else if (movingRight && !LastframeOutsideRoomRight)
            {
                velocity.X = playerSpeed;
                LastframeOutsideRoomLeft = false;
            }
            // not moving right or left
            else if (!movingRight && !movingLeft)
                velocity.X = 0;


            /* Dit stuk van de code regeld dat de juiste animaties geladen worden 
            tijdens het lopen van de player */
            if (velocity == Vector2.Zero && input.MousePosition.Y > position.Y)
            {
                PlayAnimation("idleDown");
                Mirror = false;
            }
            if (velocity == Vector2.Zero && input.MousePosition.Y < position.Y)
            {
                PlayAnimation("idleUp");
                Mirror = false;
            }
            if (velocity == Vector2.Zero && input.MousePosition.X < position.X - 200)
            {
                PlayAnimation("idleSide");
                Mirror = true;
            }
            if (velocity == Vector2.Zero && input.MousePosition.X > position.X + 200)
            {
                PlayAnimation("idleSide");
                Mirror = false;
            }

            if (Math.Abs(velocity.X) > 0 && input.MousePosition.X > position.X)
            {
                PlayAnimation("walkingSide");
                Mirror = false;
            }
            if (Math.Abs(velocity.X) > 0 && input.MousePosition.X < position.X)
            {
                PlayAnimation("walkingSide");
                Mirror = true;
            }

            if (Math.Abs(velocity.Y) > 0 && input.MousePosition.Y > position.Y && velocity.X == 0)
            {
                PlayAnimation("walkingDown");
            }
            if (Math.Abs(velocity.Y) > 0 && input.MousePosition.Y < position.Y && velocity.X == 0)
            {
                PlayAnimation("walkingUp");
            }

            if (input.KeyPressed(Keys.U))
            {
                if (Position.X > pgw.Shop.ShopSprite.Position.X 
                    && Position.Y > pgw.Shop.ShopSprite.Position.Y 
                    && Position.X < pgw.Shop.ShopSprite.Position.X + pgw.Shop.ShopSprite.Width
                    && Position.Y < pgw.Shop.ShopSprite.Position.Y + pgw.Shop.ShopSprite.Height)
                {
                    pgw.Shop.ActivateUpgrade(UpgradeTypes.PlayerSpeed);
                    pgw.Shop.ShopText = "Player speed = " + playerSpeed;
                    Console.WriteLine("ActivateUpgrade() called");
                }


                
            }

        }   
        
        public int Money
        {
            get { return money; }
            set { money = value; }
        }         
    }
}
