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

        public int playerSpeed;

        protected int money;

        public Player() : base(0, "player")
        {
            this.LoadAnimation("spr_player_idle_down@1x1", "idle", true);
            this.LoadAnimation("spr_player_walking_down@2x1", "walkingDown", true);
            this.LoadAnimation("spr_player_walking_side@2x1", "walkingSide", true);
            this.LoadAnimation("spr_player_walking_up@2x1", "walkingUp", true);

            position = START_POSITION;
            playerSpeed = START_PLAYER_SPEED;
            Money = 0;
            this.PlayAnimation("idle");
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        // HandleInput functie voor de beweging van de Player. 
          public override void HandleInput(InputHelper input)
        {
            GameWorld pgw = GameWorld as GameWorld;

            // Check if is in the room before moving up.
             if (pgw.IsOutsideRoomAbove(position.Y, Height))
            {
                position = new Vector2(position.X, 0);
                movingUp = false;
            }
            else if (input.IsKeyDown(Keys.W))
                movingUp = true;
            else
                movingUp = false;

            // check if in the room before moving down
             if (pgw.IsOutsideRoomBelow(position.Y, Height))
            {
                position = new Vector2(position.X, pgw.ScreenSize.Y - Height);
                movingDown = false;
            } 
            else  if (input.IsKeyDown(Keys.S))
                movingDown = true;
            else
                movingDown = false;

             //check if in teh room before moving left
             if (pgw.IsOutsideRoomLeft(position.X))
             {
                position = new Vector2(0, Position.Y);
               movingDown = false;
             }
             else if (input.IsKeyDown(Keys.A))
                movingLeft = true;
            else
                movingLeft = false;

            // check if in the room before moving right
            if (pgw.IsOutsideRoomRight(position.X, Width))
             {
                position = new Vector2(pgw.ScreenSize.X - Height, Position.Y);
                movingRight = false;
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
            else if (movingDown)
            {
                velocity.Y = playerSpeed;
                if (!movingLeft && !movingRight)
                this.PlayAnimation("walkingDown");
            }
            // Moving upwards
            else if (movingUp)
            {
                velocity.Y = -playerSpeed;
                if (!movingRight && !movingLeft)
                this.PlayAnimation("walkingUp");
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
            else if (movingLeft)
            {
                velocity.X = -playerSpeed;
                this.PlayAnimation("walkingSide");
                Mirror = true;
            }
            // moving Right
            else if (movingRight)
            {
                velocity.X = playerSpeed;
                this.PlayAnimation("walkingSide");
                Mirror = false;
            }
            // not moving right or left
            else if (!movingRight && !movingLeft)
                velocity.X = 0;


            if (input.KeyPressed(Keys.U))
            {
                pgw.Shop.ActivateUpgrade();
            }

        }   
        
        public int Money
        {
            get { return money; }
            set { money = value; }
        }         
    }
}
