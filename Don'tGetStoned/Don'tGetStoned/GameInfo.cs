using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Don_tGetStoned
{
    class GameInfo
    {
        public bool survival;
        public int level;
        public int enemyMax;
        public double enemySpawnTime;
        public double lastFired;
        public double elapsedTime;
        public double totalGameTime;
        public Texture2D levelClueTexture;

        public void Initialize(bool survival, int level, int enemyMax, double spawnTime, Texture2D levelClueTexture)
        { 
            //initialize the game info class
            this.survival = survival; 
            this.level = level;
            this.elapsedTime = 0;
            this.totalGameTime = 20000 * level;
            this.enemyMax = enemyMax;
            this.enemySpawnTime = spawnTime;
            this.levelClueTexture = levelClueTexture;
        }
        public void Update(GameTime gameTime)
        {
            //updates the Info
            lastFired += gameTime.ElapsedGameTime.TotalMilliseconds;
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
        }
        public bool CatapultReady()
        {
            if (lastFired >= enemySpawnTime)
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
