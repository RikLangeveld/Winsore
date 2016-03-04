using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameManagement.gameobjects
{
    class Player : SpriteGameObject
    {
        public Player(string assetname) : base(assetname)
            {
            position = new Vector2(100, 100);
            }
    }
}
