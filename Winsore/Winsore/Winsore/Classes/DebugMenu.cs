﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Winsore
{
    class DebugMenu : GameObjectList
    {
        SpriteGameObject background;
        TextGameObject debugOverlayVersion;
        TextGameObject playerSpeed;
        TextGameObject mousePosition;
        TextGameObject money;

        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

        public DebugMenu()
        {
            Visible = false;

            background = new SpriteGameObject("debugmenu");
            background.Position = new Vector2(10, 10);

            debugOverlayVersion = new TextGameObject("DebugFont");
            debugOverlayVersion.Text = "DEBUG OVERLAY VERSION 0.1";
            debugOverlayVersion.Position = new Vector2(background.BoundingBox.Width / 2, 20);

            playerSpeed = new TextGameObject("DebugFontSmall");
            playerSpeed.Position = new Vector2(30, 60);

            mousePosition = new TextGameObject("DebugFontSmall");
            mousePosition.Position = new Vector2(30, 80);

            money = new TextGameObject("DebugFontSmall");
            money.Position = new Vector2(30, 100);

            Add(background);
            Add(debugOverlayVersion);
            Add(playerSpeed);
            Add(mousePosition);
            Add(money);
        }

        public override void Update(GameTime gameTime)
        {
            playerSpeed.Text = "Player.Speed: " + GW.Player.playerSpeed;

            mousePosition.Text = "Mouse Position: X: " + Mouse.GetState().X + ", Y: " + Mouse.GetState().Y;

            money.Text = "Money: " + GW.Player.Money;

            base.Update(gameTime);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

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
