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
        Vector2 START_POSITION = new Vector2(600, 300);
        int START_PLAYER_SPEED = 110;

        public int playerSpeed;
        protected Vector2 lastPositionInsideRoom; // This is used to prefent the player from leaving the view

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

            if (pgw.IsOutsideRoomAbove(position.Y, Height))
                position = new Vector2(position.X, 5);
            else if (input.IsKeyDown(Keys.W))
                velocity.Y = -playerSpeed;
            else if (pgw.IsOutsideRoomBelow(position.Y, Height))
                position = new Vector2(position.X, 1075 - Height);
            else if (input.IsKeyDown(Keys.S))
                velocity.Y = playerSpeed;
            else
                velocity.Y = 0;

            if (pgw.IsOutsideRoomLeft(position.X))
                position = new Vector2(5, Position.Y);
            else if (input.IsKeyDown(Keys.A))
                velocity.X = -playerSpeed;
            else if (pgw.IsOutsideRoomRight(position.X, Width))
                position = new Vector2(1915-Width, Position.Y);
            else if (input.IsKeyDown(Keys.D))
                velocity.X = playerSpeed;
            else
                velocity.X = 0;

            if (input.KeyPressed(Keys.U))
            {
                pgw.Shop.ActivateUpgrade();
            }

        }            
    }
}
