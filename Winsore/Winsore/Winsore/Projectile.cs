using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Projectile : SpriteGameObject
    {
        int projectileSpeed = 200; //STC

        protected float angle;
        
        protected bool arrowOutsideRoom; // Boolean die false is als de arrow buiten de room is.
        protected Vector2 lastPositionInsideRoom; // This is used to prefent the player from leaving the view

        private bool shootingArrow;
        private bool enemyHit;

        public Projectile(string assetname) 
            : base(assetname)
        {
            //reset de arrow bij het starten van spel zodat je meteen kan schieten
            Reset();
        }

        //TODO Handle input voor schieten van projectile(arrow)
        public override void HandleInput(InputHelper input)
        {
            GameWorld pgw = GameWorld as GameWorld;

            if (input.IsKeyDown(Keys.Space) && !arrowOutsideRoom) //(!arrowOutsideRoom || !enemyHit))
                shootingArrow = true;
            else if (!input.IsKeyDown(Keys.Space))
                shootingArrow = false;

            /*double opposite = inputHelper.MousePosition.Y - position.Y;
            double adjacent = inputHelper.MousePosition.X - position.X;
            angle = (float)Math.Atan2(opposite, adjacent);*/
        }

        public override void Update(GameTime gameTime)
        {
            if (shootingArrow)
            {
                velocity.X += projectileSpeed;
                velocity.Y += projectileSpeed;
            }

            if (!arrowOutsideRoom || enemyHit)
            {
                //Reset();
            }

                base.Update(gameTime);

        }

        //TODO Reset methode die de arrow reset op de player zodra deze buiten scherm is of een enemy raakt.
        public override void Reset()
        {
            base.Reset();
            angle = 0f;
            velocity = Vector2.Zero;

            position = new Vector2(0, 0);
            // Reset naar positie van player
            //position = new Vector2(?, ?); player positie
            //position = Player.Position

            //shootingArrow = false;
        }
    
    }
}
