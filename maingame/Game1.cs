using firstrate.animation;
using firstrate.collision;
using firstrate.screens;
using firstrate.selectscreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using BoundingBox = firstrate.collision.BoundingBox;

namespace firstrate
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //select screen
        private SelectScreen loadSelectScreen;

        //first area screen
        private Texture2D firstScreen;
        private FirstScreen loadFirstScreen = new FirstScreen();

        //second area test
        private SecondScreenTest secondScreenTest = new SecondScreenTest();


        //characters
        private Texture2D emberCharacter;
        private Texture2D gioCharacter;

        //character movement
        private MainSprite main;
        private FollowingSprite following;
        private float animationTimer;

        //test
        private Texture2D pixelSquare;
        private BoundingBox testBoundingBox;

        //collision
        private LevelMap currentMap;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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

            //set screen size
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 700;
            graphics.ApplyChanges();

            //load firstscreen
            firstScreen = Content.Load<Texture2D>("firstarea/testbackground");
            
            //load characters
            gioCharacter = Content.Load<Texture2D>("sprites/giowalkcycle");
            emberCharacter = Content.Load<Texture2D>("sprites/emberwalkcycle");
           

            //test
            pixelSquare = Content.Load<Texture2D>("test/70sqpixel");
            testBoundingBox = new BoundingBox(new Vector2(300, 100), 75, 75);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //selector screen control
            if(loadSelectScreen!=null)
            {
                if (!loadSelectScreen.isDone)
                {
                    loadSelectScreen.Update();
                }
            }
            if(!loadFirstScreen.isDone)
            {
                loadFirstScreen.Update();
                currentMap = loadFirstScreen.levelMap;
            }
            else
            {
                currentMap = secondScreenTest.levelMap;
            }


            //animation for main sprite
            animationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(main!=null)
            {
                if (animationTimer > 120)
                {
                    main.Update(currentMap);
                    animationTimer = 0;
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            //draw select screen
            if (loadSelectScreen == null)
            {
                loadSelectScreen = new SelectScreen(Content);
            }
            else
            {
                if (!loadSelectScreen.isDone)
                {
                    loadSelectScreen.Draw(spriteBatch);
                }
                else if (!loadFirstScreen.isDone)
                {
                    loadSelectScreen.UnloadContent();
                    loadFirstScreen.Draw(spriteBatch, firstScreen);
                }
                else
                {
                    secondScreenTest.Draw(spriteBatch, firstScreen);
                }
             
                //decide who is main and who is following character(s)
                if (loadSelectScreen.selected.Equals("Gio"))
                {
                    if (main == null && following == null)
                    {
                        following = new FollowingSprite(emberCharacter, 350, 349);
                        main = new MainSprite(gioCharacter, following, 350, 350);
                    }

                }
                else if (loadSelectScreen.selected.Equals("Ember"))
                {
                    if (main == null && following == null)
                    {
                        following = new FollowingSprite(gioCharacter, 350, 349);
                        main = new MainSprite(emberCharacter, following, 350, 350);
                    }

                }

                //draw main character and following character(s)
                if (main != null)
                {
                    if (following.y <= main.y)
                    {
                        following.Draw(spriteBatch);
                        main.Draw(spriteBatch);
                    }
                    else
                    {
                        main.Draw(spriteBatch);
                        following.Draw(spriteBatch);
                    }
                }
     
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
