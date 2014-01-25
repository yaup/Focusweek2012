using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Don_tGetStoned
{
    class Projectile
    {
        //works for both friendly/enemy
        public bool removal = false;
        public Rectangle positionRect = new Rectangle();
        double velocityX;
        double velocityY;
        double elapsedTimeExplosion = 0;
        double elapsedTimeSmoke = 0;
        public int durability;
        public int projectileType;
        Texture2D projectileTexture;
        Animation projectileAnimation = new Animation();


        public Projectile(int X, int Y, int velX, int velY)
        { 
            //constructor that will choose different presets
            this.positionRect.X = X;
            this.positionRect.Y = Y;
            this.velocityX = velX;
            this.velocityY = velY;
        }
        //functions to set projectiles to self settings
        public void Initialize(int X, int Y, int width, int height, 
                                int projectileType, int durable,
                                Texture2D projectileTexture,
                                int totalFrameCount, int frameTime)
        { 
            //initializes the game object
            this.durability = durable;
            this.projectileTexture = projectileTexture;
            this.positionRect = new Rectangle(X-(width/2), Y-(height/2), width, height);
            this.projectileAnimation.Initialize(X, Y, width, height, projectileTexture,
                                                totalFrameCount, frameTime);
            this.projectileType = projectileType;
        }
        public void Update(GameTime gameTime)
        {
            if (removal == false)
            {
                if (projectileType == 9)//if it's an explosion
                {
                    //explosion update
                    this.elapsedTimeExplosion += gameTime.ElapsedGameTime.TotalMilliseconds;
                    projectileAnimation.Update(positionRect, gameTime);
                    if (elapsedTimeExplosion >= 400)
                    {
                        //explosion time is up
                        removal = true;

                    }
                }
                else if (projectileType == 8)//if'ts a pluff of smoke
                { 
                    //smoke update
                    elapsedTimeSmoke += gameTime.ElapsedGameTime.TotalMilliseconds;
                    projectileAnimation.Update(positionRect, gameTime);
                    if (elapsedTimeSmoke >= 500)
                    { 
                        //smoke time is up
                        removal = true;
                    }
                }
                else
                {
                    //updates the projectile object, includes gravity, if it's not set for removal
                    positionRect.X += (int)velocityX;
                    positionRect.Y += (int)velocityY;
                    velocityY += (gameTime.ElapsedGameTime.TotalMilliseconds / 1000) * 9.81;
                    projectileAnimation.Update(positionRect, gameTime);

                }
            }
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            projectileAnimation.Draw(spriteBatch);
        }
        //presets
        public void NewExplosion(Texture2D projectileTexture)
        { 
            //sets presets to explosion
            Initialize(positionRect.X, positionRect.Y, 80, 80,
                        9, 999, projectileTexture, 4, 100);
            
        }
        public void NewSmoke(Texture2D projectileTexture)
        { 
            //set values to smoke
            Initialize(positionRect.X, positionRect.Y, 80, 80, 8, 999, projectileTexture, 5, 100);
        }
        public void NewRock(Texture2D projectileTexture)
        { 
            //set values to rock
            Initialize(positionRect.X, positionRect.Y, 50, 50, 0, 1, projectileTexture, 5, 35);

        }
        public void NewCannonBall(Texture2D projectileTexture)
        { 
            //set values to Cannon Ball
            Initialize(positionRect.X, positionRect.Y, 30, 30, 1, 3, projectileTexture, 1, 35);
        }
        public void NewNet(Texture2D projectileTexture)
        { 
            //set values to Net
            Initialize(positionRect.X, positionRect.Y, 64, 100, 2, 2, projectileTexture, 4, 35);
        }
        public void NewBomb(Texture2D projectileTexture)
        { 
            //set values to bomb
            Initialize(positionRect.X, positionRect.Y, 40, 40, 3, 1, projectileTexture, 4, 35);
        }
        public void NewFireBall(Texture2D projectileTexture)
        { 
            //set values to Fireball
            Initialize(positionRect.X, positionRect.Y, 80, 80, 4, 1, projectileTexture, 5, 35);
        }
        public void NewBrick(Texture2D projectileTexture)
        { 
            //set values to brick
            Initialize(positionRect.X, positionRect.Y, 145, 145, 5, 4, projectileTexture, 4, 35);
        }
        public void NewCat(Texture2D projectileTexture)
        { 
            //set value to cat! 
        }
        public void NewTest(Texture2D projectileTexture)
        { 
            //set values to test projectile
            Initialize(positionRect.X, positionRect.Y, 50, 50, 1, 999, projectileTexture, 1, 1);
        }
        //set values to projectiles of enemy(only different in sizes)
        //update
        
    }
}
