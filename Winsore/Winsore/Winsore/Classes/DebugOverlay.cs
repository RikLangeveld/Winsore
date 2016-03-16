using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class DebugOverlay : GameObjectList
    {
        SpriteGameObject background;
        TextGameObject debugOverlayVersion;
        TextGameObject playerSpeed;

        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

        public DebugOverlay()
        {
            Visible = false;

            background = new SpriteGameObject("debugmenu");
            background.Position = new Vector2(10, 10);

            debugOverlayVersion = new TextGameObject("DebugFont");
            debugOverlayVersion.Text = "DEBUG OVERLAY VERSION 0.001";
            debugOverlayVersion.Position = new Vector2(background.BoundingBox.Width / 2, 20);

            playerSpeed = new TextGameObject("DebugFontSmall");
            playerSpeed.Position = new Vector2(30, 60);

            Add(background);
            Add(debugOverlayVersion);
            Add(playerSpeed);
        }

        public override void Update(GameTime gameTime)
        {
            playerSpeed.Text = "Player.Speed: " + GW.Player.playerSpeed;

            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            lastKeyboardState = currentKeyboardState; // Set current state to last state, so we can compare states and see what has changed
            currentKeyboardState = Keyboard.GetState(); // This gets the current state of all buttons
            
            bool shiftIsDown = lastKeyboardState.IsKeyDown(Keys.LeftShift) && currentKeyboardState.IsKeyDown(Keys.LeftShift);
            bool f1Pressed = currentKeyboardState.IsKeyDown(Keys.F1) && lastKeyboardState.IsKeyUp(Keys.F1);

            if (shiftIsDown && f1Pressed)
            {
                if (Visible)
                    Visible = false;
                else Visible = true;
            }
        }

        public GameWorld GW
        {
            get { return GameWorld as GameWorld; }
        }
    }
}
