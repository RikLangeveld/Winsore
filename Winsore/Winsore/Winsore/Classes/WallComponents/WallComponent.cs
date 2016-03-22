using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class WallComponent : SpriteGameObject
    {
       protected int life;
       public WallComponent(string assetname): base(assetname)
       {
            life = 200;
        }
    }
}
