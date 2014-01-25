using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Don_tGetStoned
{
    class GameMouse
    {
        public int X;
        public int Y;
        public int width;
        public int height;

        public Rectangle mousePointRect = new Rectangle();
        Rectangle positionRect = new Rectangle();

        Texture2D mouseTexture;

        MouseState currentState;
        MouseState previousState;

        Animation animation = new Animation();
        public void Initialize(int X, int Y, int width, int height, Texture2D mouseTexture, int totalFrame)
        {
            //initializes the game mouse object
            this.X = X;
            this.Y = Y;
            this.width = width;
            this.height = height;
            mousePointRect = new Rectangle(X, Y, 1, 1);
            positionRect = new Rectangle(X, Y, width, height);
            this.mouseTexture = mouseTexture;

            this.animation.Initialize(X, Y, width, height, mouseTexture, totalFrame, 15);

        }

        public void Update(GameTime gameTime)
        {
            //updates position?
            previousState = currentState;
            currentState = Mouse.GetState();
            X = currentState.X;
            Y = currentState.Y;
            positionRect.X = X;
            positionRect.Y = Y;
            mousePointRect.X = X;
            mousePointRect.Y = Y;
            animation.Update(positionRect, gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draws objects. already began in Game1.cs
            //spriteBatch.Draw(mouseTexture, positionRect, Color.White);
            animation.Draw(spriteBatch);
        }
        public bool LeftClick()
        {
            //checks whether the mouse is clicked
            if (currentState.LeftButton == ButtonState.Pressed && currentState.LeftButton != previousState.LeftButton)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RightClick()
        {
            //checks whether the mouse is clicked
            if (currentState.RightButton == ButtonState.Pressed && currentState.RightButton != previousState.RightButton)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MiddleClick()
        {
            //checks whether the mouse is clicked
            if (currentState.MiddleButton == ButtonState.Pressed && currentState.MiddleButton != previousState.MiddleButton)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LeftClickButton(GameButton buttonClicked)
        {
            //checks whether the mouse point is on the button when clicked
            if (LeftClick() && mousePointRect.Intersects(buttonClicked.positionRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RightClickButton(GameButton buttonClicked)
        {
            //checks whether the mouse point is on the button when clicked
            if (RightClick() && mousePointRect.Intersects(buttonClicked.positionRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool MiddleClickButton(GameButton buttonClicked)
        {
            //checks whether the mouse point is on the button when clicked
            if (MiddleClick() && mousePointRect.Intersects(buttonClicked.positionRect))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
