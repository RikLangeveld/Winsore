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
        GameWorld pgw;

        public int playerSpeed;
        protected Vector2 lastPositionInsideRoom; // This is used to prefent the player from leaving the view
        protected bool playerOutsideRoom; // Boolean die false is als de player buiten de room is.

        public Player(string assetname) : base(assetname)
            {
            position = START_POSITION;
            playerSpeed = START_PLAYER_SPEED;
            pgw = GameWorld as GameWorld;
        }

        public override void Update(GameTime gameTime)
        {
            //pgw = GameWorld as GameWorld;

            if (!playerOutsideRoom)
                lastPositionInsideRoom = position;

            base.Update(gameTime);
        }

        // HandleInput functie voor de beweging van de Player. 
          public override void HandleInput(InputHelper input)
        {
            GameWorld pgw = GameWorld as GameWorld;

            if (input.IsKeyDown(Keys.W) && !playerOutsideRoom)
                velocity.Y = -playerSpeed;
            else if (input.IsKeyDown(Keys.S) && !playerOutsideRoom)
                velocity.Y = playerSpeed;
            else if (pgw.IsOutsideRoom(position,Width,Height))
                velocity.Y = 0;


            if (input.IsKeyDown(Keys.A) && !playerOutsideRoom)
                velocity.X = -playerSpeed;
            else if (input.IsKeyDown(Keys.D) && !playerOutsideRoom)
                velocity.X = playerSpeed;
            else if (pgw.IsOutsideRoom(position, Width, Height))
                velocity.X = 0;

            if (input.KeyPressed(Keys.U))
            {
                pgw.Shop.ActivateUpgrade();
            }

        }            
    }
}
