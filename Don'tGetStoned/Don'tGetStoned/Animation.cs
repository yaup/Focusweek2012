using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Don_tGetStoned
{
    class Animation
    {
        Texture2D spriteTexture;
        int elapsedTime = 0;
        int frameTime;
        int totalFrameCount;
        public int frameWidth;
        public int frameHeight;
        // The index of the current frame we are displaying
        int currentFrame;
        // The area of the image strip we want to display
        public Rectangle positionRect = new Rectangle();
        Rectangle spriteFrameRect = new Rectangle();
        
        public void Initialize(int x, int y, int width, int height, 
                                Texture2D spriteTexture, int totalFrameCount, int frameTime)
        {
            this.currentFrame = 0;
            this.elapsedTime = 0;
            this.frameWidth = width;
            this.frameHeight = height;
            this.positionRect = new Rectangle(x, y, width, height);
            this.spriteFrameRect = new Rectangle(0, 0, width, height);
            this.spriteTexture = spriteTexture;
            this.totalFrameCount = totalFrameCount;
            this.frameTime = frameTime;

        }
        public void Update(Rectangle positionRect, GameTime gametime)
        {
            elapsedTime += (int)gametime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime >= frameTime)
            { 
                //this frame stayed long enough, move on!
                elapsedTime = 0;
                currentFrame++;
                if (currentFrame == totalFrameCount)
                {
                    currentFrame = 0;
                }
            }
            this.positionRect = positionRect;
            spriteFrameRect.X = frameWidth * currentFrame;

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //draws our thing!
            spriteBatch.Draw(spriteTexture, positionRect, spriteFrameRect, Color.White);
        }
    }
}
