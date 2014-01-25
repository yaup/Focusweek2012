using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Don_tGetStoned
{
    class Player
    {
        public int health;
        public int maxHealth;
        public int maxHealthS = 100;
        public int money;
        public bool dead = false;
        public bool win = false;
        public int weaponRangeLvl;
        public int weaponRangeLvlS = 1;
        public int weaponSelected;
        public int sessionScore;
        public int totalScore;
        public int survivalScore;
        public double firedTime;
        public double reloadTime = 500;
        /*
        int cannonBall; //weapon # 1 (tougher), weapon # 0 are boulders, no limit.
        int net; //weapon # 2 (largest)
        int bomb;//weapon # 3 (explode)
        int fireBall;//weapon # 4 (larger explode)
        int brick;//weapon # 5 (super big/ subtract self health)
        int cat;//weapon # 6 (goes meow)
         */
        public List<int> weaponsList = new List<int>();


        public void Initialize(int health, int lvl, int weaponSelected)
        {
            //initializes the player
            this.health = health;
            this.maxHealth = health;
            this.maxHealthS = health;
            this.money = 0;
            this.weaponRangeLvl = lvl;
            this.weaponRangeLvlS = lvl;
            this.weaponSelected = weaponSelected;
            weaponsList.Clear();
            for (int i = 0; i <= 6; i++)
            {
                this.weaponsList.Add(2);
            }
            this.sessionScore = 0;
            this.totalScore = 0;
            this.survivalScore = 0;
            this.firedTime = 500;
            
        }
        public void Update(GameTime gameTime)
        { 
            //updates the player time
            firedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (health <= 0)
            {
                dead = true;
            }
        }
        public void NewPlayer()
        {
            Initialize(100, 1, 0);
        }
        public void NewSurvival()
        { 
            //replaces value for surviva
            maxHealthS = maxHealth;
            weaponRangeLvlS = weaponRangeLvl;
            maxHealth = 100;
            weaponRangeLvl = 1;
            NewSession();
        }
        public void EndSurvival()
        { 
            //restores player values
            maxHealth = maxHealthS;
            weaponRangeLvl = weaponRangeLvlS;
        }
        public void NewSession()
        {
            dead = false;
            win = false;
            health = maxHealth;
            weaponSelected = 0;
            sessionScore = 0;
        }
        public bool MouseInRange(Vector2 mouseVector)
        {
            double distance = Math.Pow(500 - mouseVector.Y, 2) + Math.Pow(235 - mouseVector.X, 2);
            distance = Math.Sqrt(distance);
            if (distance <= weaponRangeLvl * 60)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }
        public bool CatapultReady()
        {
            //is the catapult ready? check time
            if (firedTime >= reloadTime)
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
