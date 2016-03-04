using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class GameWorld : GameObjectList
    {
        private SpriteGameObject background = null;

        public GameWorld()
        {
            background = new SpriteGameObject("grass");

            // Add the grass background to the gameWorld
            this.Add(background);
        }
    }
}
