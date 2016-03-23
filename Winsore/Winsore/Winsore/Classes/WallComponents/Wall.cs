using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Winsore
{
    class Wall : GameObjectList
    {
        private SpriteGameObject WallBase;
        private WallFront wallFront;

        public Wall()
        {
            WallBase = new SpriteGameObject("spr_castle");
            wallFront = new WallFront();

            WallBase.Position = new Vector2(1300, 0);

            this.Add(WallBase);
            this.Add(wallFront);

        }
    }
}
