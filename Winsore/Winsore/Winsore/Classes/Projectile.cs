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

        public Vector2 position;
        public Vector2 velocity;
        public Vector2 origin;

        public bool isVisible;

        public Projectile(string assetname)
            : base(assetname)
        {
            isVisible = false;
        }
    }
}
