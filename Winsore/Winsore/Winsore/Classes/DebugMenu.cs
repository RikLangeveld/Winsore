using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Winsore
{
    class DebugMenu : GameObjectList
    {
        SpriteGameObject background;
        TextGameObject debugOverlayVersion;
        TextGameObject performance;
        TextGameObject playerSpeed;
        TextGameObject mousePosition;
        TextGameObject money;
        TextGameObject enemyCount;

        KeyboardState currentKeyboardState;
        KeyboardState lastKeyboardState;

        int frameRate = 0;
        int frameCounter = 0;
        TimeSpan elapsedTime = TimeSpan.Zero;

        public DebugMenu()
        {
            Visible = false;

            background = new SpriteGameObject("debugmenu");
            background.Position = new Vector2(10, 10);

            debugOverlayVersion = new TextGameObject("DebugFont");
            debugOverlayVersion.Text = "DEBUG OVERLAY VERSION 0.1";
            debugOverlayVersion.Position = new Vector2(background.BoundingBox.Width / 2, 20);

            performance = new TextGameObject("DebugFontSmall");
            performance.Position = new Vector2(30, 60);

            playerSpeed = new TextGameObject("DebugFontSmall");
            playerSpeed.Position = new Vector2(30, 80);

            mousePosition = new TextGameObject("DebugFontSmall");
            mousePosition.Position = new Vector2(30, 100);

            money = new TextGameObject("DebugFontSmall");
            money.Position = new Vector2(30, 120);

            enemyCount = new TextGameObject("DebugFontSmall");
            enemyCount.Position = new Vector2(30, 140);

            Add(background);
            Add(debugOverlayVersion);
            Add(performance);
            Add(playerSpeed);
            Add(mousePosition);
            Add(money);
            Add(enemyCount);
        }

        public override void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                frameRate = frameCounter;
                frameCounter = 0;
            }

            if (gameTime.TotalGameTime.Milliseconds != 0)
                performance.Text = "FPS: " + frameRate;

            playerSpeed.Text = "Player.Speed: " + GW.Player.playerSpeed;

            mousePosition.Text = "Mouse Position: X: " + Mouse.GetState().X + ", Y: " + Mouse.GetState().Y;

            money.Text = "Money: " + GW.Player.Money;

            enemyCount.Text = "Enemys: " + GW.EnemySpawner.Counter;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            frameCounter++;

            base.Draw(gameTime, spriteBatch);
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
