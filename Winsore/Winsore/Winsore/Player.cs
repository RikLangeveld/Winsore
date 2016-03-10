using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Player : SpriteGameObject
    {
        protected Vector2 START_POSITION = new Vector2(600, 300);
        protected const int START_PLAYER_SPEED = 200;

        private bool movingRight = false;
        private bool movingLeft = false;
        private bool movingUp = false;
        private bool movingDown = false;

        public int playerSpeed;

        public Player(string assetname) : base(assetname)
            {
            position = START_POSITION;
            playerSpeed = START_PLAYER_SPEED;
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
            else if (input.IsKeyDown(Keys.S))
                movingDown = true;
            else
                movingDown = false;

            // check if in teh room before moving left
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
            if (movingUp && movingDown)
                velocity.Y = 0;
            else if (movingDown)
                velocity.Y = playerSpeed;
            else if (movingUp)
                velocity.Y = -playerSpeed;
            else if (!movingUp && !movingDown)
                velocity.Y = 0;

            if (movingLeft && movingRight)
                velocity.X = 0;
            else if (movingLeft)
                velocity.X = -playerSpeed;
            else if (movingRight)
                velocity.X = playerSpeed;
            else if (!movingRight && !movingLeft)
                velocity.X = 0;


            if (input.KeyPressed(Keys.U))
            {
                pgw.Shop.ActivateUpgrade();
            }

        }            
    }
}
