using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class Upgrade
    {
        protected SpriteGameObject isOfType;

        /// <summary>
        /// Constructor of Upgrade
        /// </summary>
        /// <param name="type">Type of object where the upgrade belongs to</param>
        /// <returns></returns>
        public Upgrade(SpriteGameObject type)
        {
            isOfType = type;
        }
    }
}
