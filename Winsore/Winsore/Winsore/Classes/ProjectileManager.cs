using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore.Classes
{
    class ProjectileManager : GameObjectList
    {
        //List<Projectile> projectiles = new List<Projectile>();
        public Vector2 distance;
        public float rotation;

        public ProjectileManager()
        {

        }

        public override void HandleInput(InputHelper input)
        {
            GameWorld pgw = GameWorld as GameWorld;

            if (input.IsKeyDown(Keys.Space))
            {
                //empty
                Shoot();
            }
                
        }

        public void UpdateProjectile()
        {
            foreach(Projectile projectile in gameObjects)
            {
                projectile.position += projectile.velocity;

                //TODO
                //if statement met out of screen 
                // dan isVisible = false
                //if ()                                        
                //    projectile.isVisible = false;

                

                
            }

            for(int i = 0; i < gameObjects.Count; i++)
            {
                if (!(gameObjects[i] as Projectile).isVisible)
                {
                    gameObjects.RemoveAt(i);
                    //i--;
                }
            }
        }

        public void Shoot()
        {
            Projectile newProjectile = new Projectile("arrow_projectile");
            newProjectile.velocity = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation)) * 5f;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            GameWorld pgw = GameWorld as GameWorld;

            distance.X = mouse.X - pgw.Player.Position.X;
            distance.Y = mouse.Y - pgw.Player.Position.Y;

            rotation = (float)Math.Atan2(distance.Y, distance.X);
        }

    }
}
