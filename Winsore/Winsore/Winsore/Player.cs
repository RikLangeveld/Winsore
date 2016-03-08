using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winsore;

namespace GameManagement.gameobjects
{
    class Player : SpriteGameObject
    {
        Vector2 START_POSITION = new Vector2(600, 300);
        int START_PLAYER_SPEED = 110;

        int playerSpeed;
        protected Vector2 lastPositionInsideRoom;

        protected bool playerOutsideRoom;

        public Player(string assetname) : base(assetname)
            {
            position = START_POSITION;
            playerSpeed = START_PLAYER_SPEED;

        }

        public override void Update(GameTime gameTime)
        {
            // Hoe kom ik in de gameWorld?
            GameWorld pgw = GameWorld as GameWorld;
            playerOutsideRoom = pgw.IsOutsideRoom(this.position, Width, Height);

            if (!playerOutsideRoom)
                lastPositionInsideRoom = position;

            base.Update(gameTime);
        }

        // HandleInput functie voor de beweging van de Player. 
          public override void HandleInput(InputHelper input)
        {

            if (input.IsKeyDown(Keys.W) && !playerOutsideRoom)
                velocity.Y = -playerSpeed;
            else if (input.IsKeyDown(Keys.S) && !playerOutsideRoom)
                velocity.Y = playerSpeed;
            else
                velocity.Y = 0;


            if (input.IsKeyDown(Keys.A) && !playerOutsideRoom)
                velocity.X = -playerSpeed;
            else if (input.IsKeyDown(Keys.D) && !playerOutsideRoom)
                velocity.X = playerSpeed;
            else velocity.X = 0;

            if (playerOutsideRoom)
                position = lastPositionInsideRoom;


        }            
    }
}
