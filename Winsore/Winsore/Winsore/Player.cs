using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameManagement.gameobjects
{
    class Player : SpriteGameObject
    {
        Vector2 START_POSITION = new Vector2(600, 300);

        int playerSpeed = 80;
       // Vector2 screenSize = ;

        public Player(string assetname) : base(assetname)
            {
            position = START_POSITION;
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        // HandleInput functie voor de beweging van de Player. 
          public override void HandleInput(InputHelper input)
        {
            // De verticale beweging
            if (input.IsKeyDown (Keys.W))
                velocity.Y = -playerSpeed;
            else if (input.IsKeyDown(Keys.S))
                velocity.Y = playerSpeed;
            else 
                velocity.Y = 0;

            // De horizontale beweging
            if (input.IsKeyDown(Keys.A))
                velocity.X = -playerSpeed;
            else if (input.IsKeyDown(Keys.D))
                velocity.X = playerSpeed;
            else
                velocity.X = 0;

        }

        public bool ObjectInRoom(Vector2 screenSize)
        {
            if (position.X + Width < screenSize.X && position.X > 0)
                return true;
            else
                return false;
        }
        
              
    }
}
