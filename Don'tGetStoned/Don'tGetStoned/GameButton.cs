using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Don_tGetStoned
{
    class GameButton
    {
        int X;
        int Y;
        int width;
        int height;
        public Rectangle positionRect = new Rectangle();

        Texture2D normalTexture;
        Texture2D hoverTexture;

        bool hover;

        public void Initialize(int X, int Y, int width, int height,
                                Texture2D normalTexture, Texture2D hoverTexture)
        {
            this.X = X;
            this.Y = Y;
            this.width = width;
            this.height = height;
            this.normalTexture = normalTexture;
            this.hoverTexture = hoverTexture;
            this.hover = false;
            //create button
            positionRect = new Rectangle(X, Y, this.width, this.height);
        }

        public void Update(Rectangle mouseRect)
        {
            //updates the texture        
            if (this.positionRect.Intersects(mouseRect))
            {
                this.hover = true;
            }
            else
            {
                this.hover = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draws the spites

            if (hover)
            {
                spriteBatch.Draw(hoverTexture, positionRect, Color.White);
            }
            else
            {
                spriteBatch.Draw(normalTexture, positionRect, Color.White);
            }

        }
    }
}
