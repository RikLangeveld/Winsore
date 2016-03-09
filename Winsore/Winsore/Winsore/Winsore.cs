using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Winsore
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Winsore : GameEnvironment
    {
        protected Vector2 screenSize;

        public Winsore()
        {
            Content.RootDirectory = "Content";

            // Zet het beeld naar fullscreen. 
            graphics.IsFullScreen = true;

            // zet de buffer hoogte naar 1080 en breedte naar 1920
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            base.LoadContent();

            // TODO: use this.Content to load your game content here
            // Adds a playingstate to the game
            gameStateManager.AddGameState("playingState", new GameWorld());

            // sets the gamestate to playing
            gameStateManager.SwitchTo("playingState");

            screen = new Point(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
        }
    }
}
