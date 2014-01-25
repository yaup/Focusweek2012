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

namespace Don_tGetStoned
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //creating fonts
        SpriteFont font14;
        SpriteFont font24;
        SpriteFont font34;
        //creating random
        Random random = new Random();
        //creates game mouse
        GameMouse gameMouse = new GameMouse();
        //keyboard states
        KeyboardState currentKeyState;
        KeyboardState previousKeyState;
        //creates gamestate
        int gameState = 0;
        int blackFade = 2;
        int fadeIncrement = 10;
        int fadeTargetState = 10;
        //creates pauseState
        bool pauseState;
        bool showClue = true;
        bool clueDisplayed = false;
        Color overlayAlpha = new Color(0, 0, 0, 128);
        //creating rectangles
        Rectangle bgRect = new Rectangle(0, 0, 800, 600);
        //Creating Animated Objects
        Animation castle = new Animation();
        Animation catapult = new Animation();
        //creating vectors
        Vector2 weaponValueVector;
        Vector2 moneyVector;
        Vector2 endScoreVector;
        Vector2 clueVector;
        Vector2 directionVector;

        //creating background textures
        Texture2D menuBgTexture;
        Texture2D levelSelectBgTexture;
        Texture2D optionsBgTexture;
        Texture2D shopBgTexture;
        Texture2D gameBgTexture;
        Texture2D gameOverBgTexture;
        Texture2D title1Texture;
        Texture2D title2Texture;
        Texture2D title3Texture;
        Texture2D title4Texture;
        Texture2D bgTexture;
        Texture2D blackOverlayTexture;
        Texture2D fadeTargetTexture;
        //creating pause screen textures
        Texture2D pauseTexture;
        Texture2D gamePausedTexture;
        Texture2D winTexture;
        Texture2D level1Clue;
        Texture2D level2Clue;
        Texture2D level3Clue;
        Texture2D levelSClue;
        //creates mouse texture
        Texture2D mouseTexture;
        //creates button textures
        //menu Start Button
        Texture2D startButtonNTexture;
        Texture2D startButtonHTexture;
        //menu Quit Button
        Texture2D quitButtonNTexture;
        Texture2D quitButtonHTexture;
        //menu options button
        Texture2D optionsButtonNTexture;
        Texture2D optionsButtonHTexture;
        //options back button
        Texture2D backButtonNTexture;
        Texture2D backButtonHTexture;
        //pause quit levelbutton
        Texture2D quitLevelTextureN;
        Texture2D quitLevelTextureH;
        //check out Button
        Texture2D checkOutNTexture;
        Texture2D checkOutHTexture;
        //level selection button
        Texture2D level1NTexture;
        Texture2D level1HTexture;
        Texture2D level2NTexture;
        Texture2D level2HTexture;
        Texture2D level3NTexture;
        Texture2D level3HTexture;
        Texture2D levelSNTexture;
        Texture2D levelSHTexture;
        //toggleClue
        Texture2D ClueNTexture;
        Texture2D ClueHTexture;
        //shop buy textures
        Texture2D goldTexture;
        Texture2D buyCannonTextureN;
        Texture2D buyCannonTextureH;
        Texture2D buyNetTextureN;
        Texture2D buyNetTextureH;
        Texture2D buyBombTextureN;
        Texture2D buyBombTextureH;
        Texture2D buyFireBallTextureN;
        Texture2D buyFireBallTextureH;
        Texture2D buyBrickTextureN;
        Texture2D buyBrickTextureH;
        Texture2D buyRangeTextureN;
        Texture2D buyRangeTextureH;
        Texture2D buyCastleTextureN;
        Texture2D buyCastleTextureH;
        //castle + weapon
        Texture2D castleIconTexture;
        Texture2D castleHealthTexture;
        Texture2D castleHealthBoxTexture;
        Texture2D castleTexture;
        Texture2D catapultTexture;
        Texture2D rangeTexture;
        Texture2D level1RangeTexture;
        Texture2D level2RangeTexture;
        Texture2D level3RangeTexture;
        //porjectile icons
        Texture2D rockIcon;
        Texture2D cannonIcon;
        Texture2D netIcon;
        Texture2D bombIcon;
        Texture2D fireBallIcon;
        Texture2D brickIcon;
        //projectile textures
        Texture2D rockTexture;
        Texture2D cannonTexture;
        Texture2D netTexture;
        Texture2D bombTexture;
        Texture2D fireBallTexture;
        Texture2D brickTexture;
        Texture2D enemyRockTexture;
        Texture2D enemyFireBallTexture;
        Texture2D enemyBrickTexture;
        Texture2D smokeTexture;
        Texture2D explosionTexture;
        //creating buttons
        GameButton menuStartButton = new GameButton();
        GameButton menuOptionsButton = new GameButton();
        GameButton menuQuitButton = new GameButton();
        GameButton optionsBackButton = new GameButton();
        GameButton quitlevelButton = new GameButton();
        GameButton ClueButton = new GameButton();
        //shop Buttons
        GameButton shopCheckOutButton = new GameButton();
        GameButton buyCannonButton = new GameButton();
        GameButton buyNetButton = new GameButton();
        GameButton buyBombButton = new GameButton();
        GameButton buyFireBallButton = new GameButton();
        GameButton buyBrickButton = new GameButton();
        GameButton buyRangeButton = new GameButton();
        GameButton buyCastleButton = new GameButton();
        //levelButtons
        GameButton level1Button = new GameButton();
        GameButton level2Button = new GameButton();
        GameButton level3Button = new GameButton();
        GameButton levelSButton = new GameButton();
        //creating projectile list
        List<Projectile> selfProjectiles = new List<Projectile>();
        List<Projectile> enemyProjectiles =  new List<Projectile>();
        List<Texture2D> iconList = new List<Texture2D>();
        //creating level info file
        GameInfo levelInfo = new GameInfo();
        Player player = new Player();



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //initializing fonts
            font14 = Content.Load<SpriteFont>("font/font14");
            font24 = Content.Load<SpriteFont>("font/font24");
            font34 = Content.Load<SpriteFont>("font/font34");
            //initializing textures
            mouseTexture = Content.Load<Texture2D>("texture/mouse");
            menuBgTexture = Content.Load<Texture2D>("texture/menuBG");
            levelSelectBgTexture = Content.Load<Texture2D>("texture/levelSelectBG");
            optionsBgTexture = Content.Load<Texture2D>("texture/optionsBG");
            gameBgTexture = Content.Load<Texture2D>("texture/gameBG");
            shopBgTexture = Content.Load<Texture2D>("texture/shopBG");
            gameOverBgTexture = Content.Load<Texture2D>("texture/defeat");
            blackOverlayTexture = Content.Load<Texture2D>("texture/blackOverlay");
            title1Texture = Content.Load<Texture2D>("texture/title/title1");
            title2Texture = Content.Load<Texture2D>("texture/title/title2");
            title3Texture = Content.Load<Texture2D>("texture/title/title3");
            title4Texture = Content.Load<Texture2D>("texture/title/title4");
            bgTexture = blackOverlayTexture;
            fadeTargetTexture = blackOverlayTexture;
            //pause screen textures
            gamePausedTexture = Content.Load<Texture2D>("texture/gamePaused");
            winTexture = Content.Load<Texture2D>("texture/win");
            level1Clue = Content.Load<Texture2D>("texture/level1Clue");
            level2Clue = Content.Load<Texture2D>("texture/level2Clue");
            level3Clue = Content.Load<Texture2D>("texture/level3Clue");
            levelSClue = Content.Load<Texture2D>("texture/levelSClue");

            pauseTexture = gamePausedTexture;
            //menu start button
            startButtonNTexture = Content.Load<Texture2D>("texture/button/startButtonN");
            startButtonHTexture = Content.Load<Texture2D>("texture/button/startButtonH");
            //menu quit button
            quitButtonNTexture = Content.Load<Texture2D>("texture/button/quitButtonN");
            quitButtonHTexture = Content.Load<Texture2D>("texture/button/quitButtonH");
            //shop check out button
            checkOutNTexture = Content.Load<Texture2D>("texture/button/shopGoN");
            checkOutHTexture = Content.Load<Texture2D>("texture/button/shopGoH");
            //menu options button
            optionsButtonNTexture = Content.Load<Texture2D>("texture/button/optionsButtonN");
            optionsButtonHTexture = Content.Load<Texture2D>("texture/button/optionsButtonH");
            //options back button
            backButtonNTexture = Content.Load<Texture2D>("texture/button/backButtonN");
            backButtonHTexture = Content.Load<Texture2D>("texture/button/backButtonH");
            //quit level
            quitLevelTextureN = Content.Load<Texture2D>("texture/button/quitLevelN");
            quitLevelTextureH = Content.Load<Texture2D>("texture/button/quitLevelH");
            //level selection button
            level1NTexture = Content.Load<Texture2D>("texture/button/level1N");
            level1HTexture = Content.Load<Texture2D>("texture/button/level1H");
            level2NTexture = Content.Load<Texture2D>("texture/button/level2N");
            level2HTexture = Content.Load<Texture2D>("texture/button/level2H");
            level3NTexture = Content.Load<Texture2D>("texture/button/level3N");
            level3HTexture = Content.Load<Texture2D>("texture/button/level3H");
            levelSNTexture = Content.Load<Texture2D>("texture/button/levelSurvivalN");
            levelSHTexture = Content.Load<Texture2D>("texture/button/levelSurvivalH");
            //clue button
            ClueNTexture = Content.Load<Texture2D>("texture/button/showClueN");
            ClueHTexture = Content.Load<Texture2D>("texture/button/showClueH");
            //shop Textures
            goldTexture = Content.Load<Texture2D>("texture/coin");
            buyCannonTextureN = Content.Load<Texture2D>("texture/button/buyCannonN");
            buyCannonTextureH = Content.Load<Texture2D>("texture/button/buyCannonH");
            buyNetTextureN = Content.Load<Texture2D>("texture/button/buyNetN");
            buyNetTextureH = Content.Load<Texture2D>("texture/button/buyNetH");
            buyBombTextureN = Content.Load<Texture2D>("texture/button/buyBombN");
            buyBombTextureH = Content.Load<Texture2D>("texture/button/buyBombH");
            buyFireBallTextureN = Content.Load<Texture2D>("texture/button/buyFireBallN");
            buyFireBallTextureH = Content.Load<Texture2D>("texture/button/buyFireBallH");
            buyBrickTextureN = Content.Load<Texture2D>("texture/button/buyBrickN");
            buyBrickTextureH = Content.Load<Texture2D>("texture/button/buyBrickH");
            buyRangeTextureN = Content.Load<Texture2D>("texture/button/buyRangeN");
            buyRangeTextureH = Content.Load<Texture2D>("texture/button/buyRangeH");
            buyCastleTextureN = Content.Load<Texture2D>("texture/button/buyCastleN");
            buyCastleTextureH = Content.Load<Texture2D>("texture/button/buyCastleH");
            //castle texture
            castleIconTexture = Content.Load<Texture2D>("texture/castle");
            castleHealthTexture = Content.Load<Texture2D>("texture/castleHealth");
            castleHealthBoxTexture = Content.Load<Texture2D>("texture/castleHealthFrame");
            castleTexture = Content.Load<Texture2D>("texture/castleSprite");
            catapultTexture = Content.Load<Texture2D>("texture/catapult");
            level1RangeTexture = Content.Load<Texture2D>("texture/level1Range");
            level2RangeTexture = Content.Load<Texture2D>("texture/level2Range");
            level3RangeTexture = Content.Load<Texture2D>("texture/level3Range");
            rangeTexture = level1RangeTexture;
            //icons
            rockIcon = Content.Load<Texture2D>("texture/projectile/icon/rockIcon");
            cannonIcon = Content.Load<Texture2D>("texture/projectile/icon/cannonBallIcon");
            netIcon = Content.Load<Texture2D>("texture/projectile/icon/netIcon");
            bombIcon = Content.Load<Texture2D>("texture/projectile/icon/bombIcon");
            fireBallIcon = Content.Load<Texture2D>("texture/projectile/icon/fireBallIcon");
            brickIcon = Content.Load<Texture2D>("texture/projectile/icon/brickIcon");
            iconList.Add(rockIcon);
            iconList.Add(cannonIcon);
            iconList.Add(netIcon);
            iconList.Add(bombIcon);
            iconList.Add(fireBallIcon);
            iconList.Add(brickIcon);
            //projectile sprites
            rockTexture = Content.Load<Texture2D>("texture/projectile/rockSprite");
            cannonTexture = Content.Load<Texture2D>("texture/projectile/cannonBallSprite");
            brickTexture = Content.Load<Texture2D>("texture/projectile/brickSprite");
            netTexture = Content.Load<Texture2D>("texture/projectile/netSprite");
            bombTexture = Content.Load<Texture2D>("texture/projectile/bombSprite");
            fireBallTexture = Content.Load<Texture2D>("texture/projectile/fireBallSprite");
            enemyRockTexture = Content.Load<Texture2D>("texture/projectile/enemyRockSprite");
            enemyFireBallTexture = Content.Load<Texture2D>("texture/projectile/enemyFireBallSprite");
            enemyBrickTexture = Content.Load<Texture2D>("texture/projectile/enemyBrickSprite");
            //sprites
            explosionTexture = Content.Load<Texture2D>("texture/explosionSprite");
            smokeTexture = Content.Load<Texture2D>("texture/smokeSprite");

            //initializing objects
            castle.Initialize(0, 298, 310, 270, castleTexture, 2, 300);
            catapult.Initialize(180, 480, 100, 80, catapultTexture, 1, 100);
            player.NewPlayer();
            //initializing buttons
            gameMouse.Initialize(400, 320, 30, 30, mouseTexture, 1);
            menuStartButton.Initialize(353, 360, 140, 55, startButtonNTexture, startButtonHTexture);
            menuOptionsButton.Initialize(335, 418, 160, 50, optionsButtonNTexture, optionsButtonHTexture);
            menuQuitButton.Initialize(335, 470, 130, 55, quitButtonNTexture, quitButtonHTexture);
            shopCheckOutButton.Initialize(480, 470, 120, 80, checkOutNTexture, checkOutHTexture);
            optionsBackButton.Initialize(510, 410, 150, 65, backButtonNTexture, backButtonHTexture);
            quitlevelButton.Initialize(450, 440, 200, 50, quitLevelTextureN, quitLevelTextureH);
            level1Button.Initialize(180, 240, 100, 100, level1NTexture, level1HTexture);
            level2Button.Initialize(290, 240, 100, 100, level2NTexture, level2HTexture);
            level3Button.Initialize(400, 240, 100, 100, level3NTexture, level3HTexture);
            levelSButton.Initialize(520, 240, 100, 100, levelSNTexture, levelSHTexture);
            ClueButton.Initialize(140, 180, 225, 50, ClueNTexture, ClueHTexture);
            //initializing shopbuttons
            buyCannonButton.Initialize(40, 170, 110, 150, buyCannonTextureN, buyCannonTextureH);
            buyNetButton.Initialize(150, 170, 110, 150, buyNetTextureN, buyNetTextureH);
            buyBombButton.Initialize(260, 170, 110, 150, buyBombTextureN, buyBombTextureH);
            buyFireBallButton.Initialize(40, 330, 110, 150, buyFireBallTextureN, buyFireBallTextureH);
            buyBrickButton.Initialize(150, 330, 110, 150, buyBrickTextureN, buyBrickTextureH);
            buyRangeButton.Initialize(460, 170, 120, 150, buyRangeTextureN, buyRangeTextureH);
            buyCastleButton.Initialize(570, 170, 120, 150, buyCastleTextureN, buyCastleTextureH);
            //initializing vectors
            weaponValueVector.X = 70;
            weaponValueVector.Y = 65;
            clueVector.X = 350;
            clueVector.Y = 188;
            moneyVector.X = 670;
            moneyVector.Y = 490;
            endScoreVector.X = 300;
            endScoreVector.Y = 370;
            directionVector.X = 500;
            directionVector.Y = 550;
            //end
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            gameMouse.Update(gameTime);
            previousKeyState = currentKeyState;
            currentKeyState = Keyboard.GetState();
            switch(gameState)
            {
                case 0:
                    FadeUpdate(fadeTargetState, fadeTargetTexture);
                    break;
                case 1:
                    //menu state
                    //updating menu objects
                    menuOptionsButton.Update(gameMouse.mousePointRect);
                    menuStartButton.Update(gameMouse.mousePointRect);
                    menuQuitButton.Update(gameMouse.mousePointRect);
                    //taking input
                    if (gameMouse.LeftClickButton(menuStartButton))
                    {
                        //move to 'game' game state
                        NewFade(2, levelSelectBgTexture);
                    }
                    if (gameMouse.LeftClickButton(menuOptionsButton))
                    {
                        NewFade(5, optionsBgTexture);
                    }
                    if (gameMouse.LeftClickButton(menuQuitButton))
                    {
                        //quits the game!
                        this.Exit();
                    }
                    break;

                case 2:
                    //lvl selection menu
                    level1Button.Update(gameMouse.mousePointRect);
                    level2Button.Update(gameMouse.mousePointRect);
                    level3Button.Update(gameMouse.mousePointRect);
                    levelSButton.Update(gameMouse.mousePointRect);
                    optionsBackButton.Update(gameMouse.mousePointRect);
                    if (gameMouse.LeftClickButton(optionsBackButton))
                    { 
                        //back
                        gameState = 0;
                        blackFade = 2;
                        fadeTargetState = 1;
                        fadeTargetTexture = menuBgTexture;
                    }
                    if (gameMouse.LeftClickButton(level1Button))
                    {
                        //lvl1 button
                        NewFade(3, gameBgTexture);
                        selfProjectiles.Clear();
                        levelInfo.Initialize(false, 1, 3, 1000, level1Clue);
                        player.NewSession();
                        enemyProjectiles.Clear();
                        pauseState = false;
                        if (showClue)
                        {
                            pauseState = true;
                            clueDisplayed = false;
                        }
                    }
                    if (gameMouse.LeftClickButton(level2Button))
                    {
                        //lv2 button
                        NewFade(3, gameBgTexture);
                        selfProjectiles.Clear();
                        levelInfo.Initialize(false, 2, 5, 700, level2Clue);
                        enemyProjectiles.Clear();
                        player.NewSession();
                        pauseState = false;
                        if (showClue)
                        {
                            pauseState = true;
                            clueDisplayed = false;
                        }
                    }
                    if (gameMouse.LeftClickButton(level3Button))
                    {
                        //lv3 button
                        NewFade(3, gameBgTexture);
                        selfProjectiles.Clear();
                        levelInfo.Initialize(false, 3, 8, 600, level3Clue);
                        enemyProjectiles.Clear();
                        player.NewSession();
                        pauseState = false;
                        if (showClue)
                        {
                            pauseState = true;
                            clueDisplayed = false;
                        }
                    }
                    if (gameMouse.LeftClickButton(levelSButton))
                    {
                        //survival button
                        NewFade(3, gameBgTexture);
                        selfProjectiles.Clear();
                        levelInfo.Initialize(true, 1, 5, 800, levelSClue);
                        player.NewSurvival();
                        enemyProjectiles.Clear();
                        pauseState = false;
                        if (showClue)
                        {
                            pauseState = true;
                            clueDisplayed = false;
                        }
                    }
                    break;
                case 3:
                    //game state
                    //check if player is dead
                    if (player.win)
                    { 
                        //you won!
                        pauseState = true;
                    }
                    if (player.dead)
                    {
                        NewFade(6, gameOverBgTexture);
                    }
                    else
                    {
                        //checks if game is paused
                        if (pauseState)
                        {
                            //the game is paused
                            if (player.win)
                            {
                                pauseTexture = winTexture;
                                player.totalScore += player.sessionScore;
                                player.sessionScore = 0;
                                if (IsKeyPressed(Keys.Enter))
                                {
                                    NewFade(4, shopBgTexture);
                                }
                            }
                            else if (showClue && clueDisplayed == false)
                            {
                                pauseTexture = levelInfo.levelClueTexture;
                                if (IsKeyPressed(Keys.Enter))
                                {
                                    clueDisplayed = true;
                                    pauseState = false;
                                }
                            }
                            else
                            {
                                pauseTexture = gamePausedTexture;
                                quitlevelButton.Update(gameMouse.mousePointRect);
                                if (gameMouse.LeftClickButton(quitlevelButton))
                                {
                                    NewFade(2, levelSelectBgTexture);
                                }
                                if (currentKeyState.IsKeyDown(Keys.Enter) && previousKeyState.IsKeyDown(Keys.Enter) == false)
                                {
                                    pauseState = false;
                                }
                            }
                        }
                        else
                        {
                            //game is running
                            //take input
                            castle.Update(castle.positionRect, gameTime);
                            catapult.Update(catapult.positionRect, gameTime);
                            //adding projectiles
                            //pause game
                            if (IsKeyPressed(Keys.Enter))
                            {
                                pauseState = true;
                            }
                            if (gameMouse.LeftClick())
                            {
                                if (player.MouseInRange(new Vector2(gameMouse.mousePointRect.X, gameMouse.mousePointRect.Y)) &&
                                    player.CatapultReady())
                                {
                                    if (player.weaponsList[player.weaponSelected] > 0 || player.weaponSelected == 0)
                                    {
                                        AddProjectile(player.weaponSelected);
                                        player.weaponsList[player.weaponSelected] -= 1;
                                        if (player.weaponSelected == 5)
                                        {
                                            player.health -= 10;
                                        }
                                        player.firedTime = 0;
                                    }
                                }
                            }
                            if (gameMouse.RightClick() && levelInfo.survival == false)
                            {
                                //switches weapon
                                player.weaponSelected += 1;
                                if (player.weaponSelected >= 6)
                                {
                                    player.weaponSelected = 0;
                                }
                            }
                            //checks for quick switch
                            ToggleKey();
                            //testing input
                            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                            {
                                //move game to shop, temp only
                                NewFade(4, shopBgTexture);

                            }
                            //Updating things
                            player.Update(gameTime);
                            UpdateEnemy(gameTime);
                            UpdateProjectiles(gameTime);
                            if (enemyProjectiles.Count != 0)
                            {
                                // only update collision if there is enemy
                                UpdateCollision();
                            }
                            //checks if the time is up unless in survival
                            if (levelInfo.elapsedTime >= levelInfo.totalGameTime && levelInfo.survival == false)
                            {
                                player.win = true;
                            }
                        }
                    }
                    break;
                case 4:
                    //shop state
                    //close this please!
                    buyCannonButton.Update(gameMouse.mousePointRect);
                    buyNetButton.Update(gameMouse.mousePointRect);
                    buyBombButton.Update(gameMouse.mousePointRect);
                    buyFireBallButton.Update(gameMouse.mousePointRect);
                    buyBrickButton.Update(gameMouse.mousePointRect);
                    buyRangeButton.Update(gameMouse.mousePointRect);
                    buyCastleButton.Update(gameMouse.mousePointRect);
                    shopCheckOutButton.Update(gameMouse.mousePointRect);
                    if (gameMouse.LeftClickButton(buyCannonButton) && player.money >= 3)
                    {
                        //buy that!
                        player.money -= 3;
                        player.weaponsList[1] += 4;
                    }
                    if (gameMouse.LeftClickButton(buyNetButton) && player.money >= 5)
                    {
                        //buy that!
                        player.money -= 5;
                        player.weaponsList[2] += 4;
                    }
                    if (gameMouse.LeftClickButton(buyBombButton) && player.money >= 3)
                    {
                        //buy that!
                        player.money -= 3;
                        player.weaponsList[3] += 4;
                    }
                    if (gameMouse.LeftClickButton(buyFireBallButton) && player.money >= 6)
                    {
                        //buy that!
                        player.money -= 6;
                        player.weaponsList[4] += 4;
                    }
                    if (gameMouse.LeftClickButton(buyBrickButton) && player.money >= 10)
                    {
                        //buy that!
                        player.money -= 10;
                        player.weaponsList[5] += 3;
                    }
                    if (gameMouse.LeftClickButton(buyRangeButton) && player.money >= 10 && player.weaponRangeLvl <3)
                    {
                        //buy that!
                        player.money -= 10;
                        player.weaponRangeLvl += 1;
                    }
                    if (gameMouse.LeftClickButton(buyCastleButton) && player.money >= 15)
                    {
                        //buy that!
                        player.money -= 15;
                        player.maxHealth += 50;
                    }
                    if (gameMouse.LeftClickButton(shopCheckOutButton))
                    {
                        //go back to menu
                        NewFade(2, levelSelectBgTexture);
                    }
                    break;
                case 5:
                    //options menu
                    optionsBackButton.Update(gameMouse.mousePointRect);
                    ClueButton.Update(gameMouse.mousePointRect);
                    if (gameMouse.LeftClickButton(optionsBackButton))
                    {
                        NewFade(1, menuBgTexture);
                    }
                    if(gameMouse.LeftClickButton(ClueButton))
                    {
                        if (showClue)
                        {
                            showClue = false;
                        }
                        else
                        {
                            showClue = true;
                        }
                    }
                    gameMouse.Update(gameTime);
                    break;
                case 6:
                    //dead screen
                    if (levelInfo.survival)
                    {
                        
                        if (gameMouse.LeftClick())
                        {
                            NewFade(2, levelSelectBgTexture);
                            player.sessionScore = 0;
                            player.EndSurvival();
                        }
                    }
                    else
                    {
                        player.totalScore += player.sessionScore;
                        player.sessionScore = 0;
                        if (gameMouse.LeftClick())
                        {
                            NewFade(1, menuBgTexture);
                            player.NewPlayer();
                        }
                    }                   
                    
                    break;
                case 10:
                    NewFade(11,title1Texture, 3);
                    break;
                case 11:
                    NewFade(12, title2Texture, 3);
                    break;
                case 12:
                    NewFade(13, title3Texture, 3);
                    break;
                case 13:
                    NewFade(14, title4Texture, 2);
                    break;
                case 14:
                    NewFade(1, menuBgTexture, 3);
                    break;


            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(bgTexture, bgRect, Color.White);
            switch (gameState)
            {
                case 0:
                    //fade screen
                    FadeDraw(spriteBatch);
                    break;
                case 1:
                    //menu state
                    menuStartButton.Draw(spriteBatch);
                    menuOptionsButton.Draw(spriteBatch);
                    menuQuitButton.Draw(spriteBatch);
                    gameMouse.Draw(spriteBatch);
                    break;
                case 2:
                    //level select menu
                    level1Button.Draw(spriteBatch);
                    level2Button.Draw(spriteBatch);
                    level3Button.Draw(spriteBatch);
                    levelSButton.Draw(spriteBatch);
                    optionsBackButton.Draw(spriteBatch);
                    gameMouse.Draw(spriteBatch);
                    break;
                case 3:
                    //game state
                    castle.Draw(spriteBatch);
                    catapult.Draw(spriteBatch);
                    //draw the circle
                    spriteBatch.Draw(rangeTexture, new Rectangle(235-(60*player.weaponRangeLvl), 500 - (60*player.weaponRangeLvl), 120*player.weaponRangeLvl, 120*player.weaponRangeLvl), Color.White);
                    DrawProjectiles(spriteBatch);
                    DrawGameInfo(spriteBatch);
                    //debug mouse position
                    //spriteBatch.DrawString(gameFont, gameMouse.X + "," + gameMouse.Y, weaponValueVector, Color.White);
                    if (pauseState)
                    {
                        //show the pause screen/clue
                        spriteBatch.Draw(blackOverlayTexture, bgRect, overlayAlpha);
                        spriteBatch.Draw(pauseTexture, bgRect, Color.White);
                        if (player.win == false && clueDisplayed == true)
                        {
                            quitlevelButton.Draw(spriteBatch);
                        }
                        spriteBatch.DrawString(font14, "Press Enter to Continue", directionVector, Color.White);
                    }
                    gameMouse.Draw(spriteBatch);
                    break;
                case 4:
                    //shop state
                    buyCannonButton.Draw(spriteBatch);
                    buyNetButton.Draw(spriteBatch);
                    buyBombButton.Draw(spriteBatch);
                    buyFireBallButton.Draw(spriteBatch);
                    buyBrickButton.Draw(spriteBatch);
                    buyRangeButton.Draw(spriteBatch);
                    buyCastleButton.Draw(spriteBatch);
                    shopCheckOutButton.Draw(spriteBatch);
                    spriteBatch.Draw(goldTexture, new Rectangle(620, 480, 50, 50), Color.White);
                    spriteBatch.DrawString(font24, player.money.ToString(), moneyVector, Color.Black);
                    gameMouse.Draw(spriteBatch);
                    break;

                case 5:
                    //options
                    optionsBackButton.Draw(spriteBatch);
                    ClueButton.Draw(spriteBatch);
                    if (showClue)
                    {
                        spriteBatch.DrawString(font24, "........................On", clueVector, Color.Black);
                    }
                    else
                    {
                        spriteBatch.DrawString(font24, ".......................Off", clueVector, Color.Black);
                    }
                    gameMouse.Draw(spriteBatch);
                    break;
                case 6:
                    //gave over
                    string scoreDisplayed;
                    if (levelInfo.survival)
                    {
                        scoreDisplayed = "Score:" + player.sessionScore.ToString();
                    }
                    else 
                    {
                        scoreDisplayed = "Score:" + player.totalScore.ToString();
                    }
                    spriteBatch.DrawString(font34,scoreDisplayed, endScoreVector, Color.Black);
                    gameMouse.Draw(spriteBatch);
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        //Draw
        public void UpdateProjectiles(GameTime gameTime)
        {
            //update self projectiles
            if (selfProjectiles != null)
            {
                //only runs if the list isn't empty
                for (int i = selfProjectiles.Count - 1; i >= 0; i--)
                {
                    //loop through projectile list to update projectiles
                    selfProjectiles[i].Update(gameTime);
                    //checks if it hit the ground/out of bounds
                    /*if (selfProjectiles[i].positionRect.Y >= (555 - selfProjectiles[i].positionRect.Height)
                        || selfProjectiles[i].positionRect.X > 800
                        || selfProjectiles[i].positionRect.X < -selfProjectiles[i].positionRect.Width)
                    */
                    if (selfProjectiles[i].positionRect.Y >= 555
                    || selfProjectiles[i].positionRect.X > 800
                    || selfProjectiles[i].positionRect.X < -selfProjectiles[i].positionRect.Width)
                    {
                        selfProjectiles[i].NewSmoke(smokeTexture);
                    }
                    //checks if it should be removed
                    if (selfProjectiles[i].removal)
                    {
                        //removes the object
                        selfProjectiles.RemoveAt(i);
                    }
                }
            }
            //updates enemy projectiles
            if (enemyProjectiles.Count >= 1)
            {
                //only runs if the list isn't empty
                for (int i = enemyProjectiles.Count - 1; i >= 0; i--)
                {
                    //loop through projectile list to update projectiles
                    enemyProjectiles[i].Update(gameTime);
                    //checks if it hit the ground/out of bounds
                    if (enemyProjectiles[i].positionRect.Y >= (555 - enemyProjectiles[i].positionRect.Height)
                        || enemyProjectiles[i].positionRect.X > 800
                        || enemyProjectiles[i].positionRect.X < -enemyProjectiles[i].positionRect.Width)
                    {
                        enemyProjectiles[i].NewSmoke(smokeTexture);
                    }
                    //checks if it should be removed
                    if (enemyProjectiles[i].removal)
                    {
                        //removes the object
                        enemyProjectiles.RemoveAt(i);
                    }
                }
            }
        }
        //update projectiles
        public void UpdateCollision()
        {
            //update collision of my objects
            for (int i = selfProjectiles.Count - 1; i >= 0; i--)
            {
                for (int e = enemyProjectiles.Count - 1; e >= 0; e--)
                {
                    if (selfProjectiles[i].positionRect.Intersects(enemyProjectiles[e].positionRect))
                    {
                        //checks if it's smoke/explosion
                        if (selfProjectiles[i].projectileType == 8 || enemyProjectiles[e].projectileType == 8)
                        { 
                            //its smoke
                            continue;
                        }
                        else
                        {
                            int durableTest = selfProjectiles[i].durability - enemyProjectiles[e].durability;
                            //checks if it's a bomb/fireball//explosion
                            if (selfProjectiles[i].projectileType == 3 || selfProjectiles[i].projectileType == 4
                                || enemyProjectiles[e].projectileType == 3 || enemyProjectiles[e].projectileType == 4)
                            {
                                //it is!
                                enemyProjectiles[e].removal = true;
                                selfProjectiles[i].NewExplosion(explosionTexture);
                                player.sessionScore += 1;
                                if (levelInfo.survival == false)
                                {
                                    player.money += 1;
                                }
                            }
                            else
                            {
                                //its not :(
                                if (durableTest > 0)
                                {
                                    //if your projectile has more health
                                    //test for bombs
                                    selfProjectiles[i].durability -= enemyProjectiles[e].durability;
                                    enemyProjectiles[e].NewSmoke(smokeTexture);
                                    player.sessionScore += 1;
                                    if (levelInfo.survival == false)
                                    {
                                        player.money += 1;
                                    }
                                }
                                else if (durableTest < 0)
                                {
                                    //if the enemy has more health
                                    enemyProjectiles[e].durability -= selfProjectiles[i].durability;
                                    selfProjectiles[i].NewSmoke(smokeTexture);
                                    
                                }
                                else if (durableTest == 0)
                                {
                                    //if you have equal health
                                    selfProjectiles[i].NewSmoke(smokeTexture);
                                    enemyProjectiles[e].removal = true;
                                    player.sessionScore += 1;
                                    if (levelInfo.survival == false)
                                    {
                                        player.money += 1;
                                    }
                                }
                                else
                                {
                                    //wut?
                                }
                            }
                        }
                    }
                }
            }
            //update collision of hitting the castle
            for (int i = enemyProjectiles.Count - 1; i >= 0; i--)
            { 
                //looping through enemies
                if (enemyProjectiles[i].positionRect.Intersects(castle.positionRect) && enemyProjectiles[i].projectileType != 8)
                { 
                    //hits the castle
                    player.health -= enemyProjectiles[i].durability * 10;
                    enemyProjectiles[i].NewSmoke(smokeTexture);
                }
            }
        }
        //UpdateCollision
        public void DrawProjectiles(SpriteBatch spriteBatch)
        { 
            //draws the projectiles
            if (selfProjectiles.Count >= 1)
            {
                //only runs if the list isn't empty
                for (int i = selfProjectiles.Count - 1; i >= 0; i--)
                {
                    //draws self projectiles
                    selfProjectiles[i].Draw(spriteBatch);
                }
            }
            if (enemyProjectiles.Count >= 1)
            {
                for (int i = enemyProjectiles.Count - 1; i >= 0; i--)
                {
                    //draws enemy projectiles
                    enemyProjectiles[i].Draw(spriteBatch);
                }
            }
        }
        //draw projectiles
        public void AddProjectile( int projectileType)
        {
            double velX = (235 - gameMouse.X) * .25;
            double velY = (490 - gameMouse.Y) * .25;
            Projectile projectile = new Projectile(235, 490, (int)velX, (int)velY);
            switch (projectileType)
            {

                case 0:
                    projectile.NewRock(rockTexture);
                    break;
                case 1:
                    projectile.NewCannonBall(cannonTexture);
                    break;
                case 2:
                    projectile.NewNet(netTexture);
                    break;
                case 3:
                    projectile.NewBomb(bombTexture);
                    break;
                case 4:
                    projectile.NewFireBall(fireBallTexture);
                    break;
                case 5:
                    projectile.NewBrick(brickTexture);
                    break;
                
            }
            selfProjectiles.Add(projectile);        

        }
        //AddProjectile
        public void AddEnemy(int X, int Y, int projectileType)
        {

            Projectile projectile = new Projectile(X, Y,-random.Next(5, 8), -random.Next(5, 8));
            switch (projectileType)
            {
                case 1:
                    projectile.NewRock(enemyRockTexture);
                    break;
                case 2:
                    projectile.NewFireBall(enemyFireBallTexture);
                    break;
                case 3:
                    projectile.NewBrick(enemyBrickTexture);
                    break;

            }
            enemyProjectiles.Add(projectile);    
        }
        //AddEnemy
        public void UpdateEnemy(GameTime gameTime)
        { 
            //updates the enemy, such as adding new projectiles
            levelInfo.Update(gameTime);
            if (levelInfo.CatapultReady() && enemyProjectiles.Count < levelInfo.enemyMax)
            {
                AddEnemy(800, random.Next(150,450), random.Next(1,levelInfo.level+1));
                levelInfo.lastFired = 0;
            }

        }
        //UpdateEnemy
        public void DrawGameInfo(SpriteBatch spriteBatch)
        {
            //draws the health, weapon type, level, and time.
            spriteBatch.Draw(castleIconTexture, new Rectangle(0, 10, 62, 54), Color.White);
            spriteBatch.Draw(iconList[player.weaponSelected], new Rectangle(25, 70, 30, 30), Color.White);
            if (player.weaponSelected == 0)
            {
                //its rock, infinite
                spriteBatch.DrawString(font24, "infinite", weaponValueVector, Color.Black);
            }
            else
            {
                //show weapon left
                spriteBatch.DrawString(font24, player.weaponsList[player.weaponSelected].ToString(), weaponValueVector, Color.Black);
            }
            //show time left, only if not survival
            if (levelInfo.survival == false)
            {
                int timeLeftSeconds = ((int)levelInfo.totalGameTime - (int)levelInfo.elapsedTime) / 1000;
                int seconds = timeLeftSeconds % 60;
                int minutes = (timeLeftSeconds - seconds) / 60;
                string timeLeft = minutes.ToString() + ":" + seconds.ToString();
                spriteBatch.DrawString(font34, timeLeft, new Vector2(350, 45), Color.Black);
            }
            spriteBatch.Draw(castleHealthTexture, new Rectangle(70, 30, (int)MathHelper.Clamp(player.health,0,1000), 25), Color.White);
            spriteBatch.Draw(castleHealthBoxTexture, new Rectangle(68, 28, (int)MathHelper.Clamp(player.maxHealth, 0, 1000)+4, 29), Color.White);
        }
        //DrawGameInfo
        public void ToggleKey()
        { 
            //sets the weapon based on the key pressed
            if (levelInfo.survival == false)
            {
                //only works if it's not in survival
                if (IsKeyPressed(Keys.Q))
                { 
                    //when Q is pressed, sets state to boulder
                    player.weaponSelected = 0;
                }
                else if (IsKeyPressed(Keys.W))
                {
                    //when W is pressed, sets state to cannon
                    player.weaponSelected = 1;
                }
                else if (IsKeyPressed(Keys.E))
                {
                    //when E is pressed, sets state to net
                    player.weaponSelected = 2;
                }
                else if (IsKeyPressed(Keys.A))
                {
                    //when A is pressed, sets state to bomb
                    player.weaponSelected = 3;
                }
                else if (IsKeyPressed(Keys.S))
                {
                    //when S is pressed, sets state to fireball
                    player.weaponSelected = 4;
                }
                else if (IsKeyPressed(Keys.D))
                {
                    //when D is pressed, sets state to castle
                    player.weaponSelected = 5;
                }
            }
        }
        //ToggleKey
        public bool IsKeyPressed(Keys pressedKey)
        { 
            //returns bool whether "pressedKey" is pressed now but not before
            if (currentKeyState.IsKeyDown(pressedKey) && previousKeyState.IsKeyDown(pressedKey) == false)
            {
                return true;
            }
            else 
            {
                return false;
            }

        }
        //IsKeyPressed
        public void NewFade(int targetState, Texture2D targetTexture, int m_fadeIncrement = 10)
        {
            gameState = 0;
            blackFade = 2;
            fadeTargetState = targetState;
            fadeTargetTexture = targetTexture;
            fadeIncrement = m_fadeIncrement;
        }
        //NewFade
        public void FadeUpdate(int targetState, Texture2D targetTexture)
        {
            if (blackFade >= 1 && blackFade< 255)
            {
                blackFade += fadeIncrement;
            }
            else if (blackFade <= 0)
            {
                gameState = targetState;
                fadeIncrement *= -1;
            }
            else if (blackFade >= 255)
            {
                fadeIncrement *= -1;
                blackFade = 254;
                bgTexture = targetTexture;
            }
            else 
            {
                //huh?
            }
        }
        //FadeUpdate
        public void FadeDraw(SpriteBatch spriteBatch)
        { 
            //draw the black fade
            spriteBatch.Draw(bgTexture, bgRect, new Color(0,0,0, (byte)MathHelper.Clamp(blackFade, 0,255)));
        }
        //FadeDraw
    }
}
