using firstrate.animation;
using firstrate.collision;
using firstrate.screens;
using firstrate.selectscreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
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

        //characters
        private Texture2D emberCharacter;
        private Texture2D gioCharacter;

        //character movement
        private MainSprite main;
        private FollowingSprite following;
        private float animationTimer;

        //collision
        private LevelMap currentMap;

        //list of screens and current screen
        private List<string> screens = new List<string>();
        private Screen currentScreen;

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
            //screens
            currentScreen = new SelectScreen(Content);
            screens.Add("FirstScreen");
            screens.Add("SecondScreen");

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
            
            //load characters
            gioCharacter = Content.Load<Texture2D>("sprites/giowalkcycle");
            emberCharacter = Content.Load<Texture2D>("sprites/emberwalkcycle");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentScreen.Update(animationTimer, main);
            currentMap = currentScreen.levelMap;

            //animation for main sprite
            animationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(main!=null)
            {
                if (animationTimer > 120)
                {
                    currentScreen.data = main.Update(currentMap);
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
            //also have to check if currentScreen isDone before moving to next screen which would be a surrounding if statement
            //within the surrounding if statement, set value of current screen to true
            if(currentScreen.isDone)
            {
                if (main == null && following == null)
                {
                    if (currentScreen.data.Equals("Gio") && currentScreen.data != null)
                    {
                        following = new FollowingSprite(emberCharacter, 500, 499);
                        main = new MainSprite(gioCharacter, following, 500, 500);
                    }
                    else
                    {
                        following = new FollowingSprite(gioCharacter, 350, 349);
                        main = new MainSprite(emberCharacter, following, 350, 350);
                    }
                }

                currentScreen.UnloadContent();
                //I don't think we need to loop through it?
                foreach (string entry in screens)
                {
                    Type screenType = Type.GetType("firstrate.screens." + entry);
                    currentScreen = (Screen)Activator.CreateInstance(screenType, Content);
                    break;
                }

                /*  Type screenType = Type.GetType("firstrate.screens." + screens[0]);
                  currentScreen = (Screen)Activator.CreateInstance(screenType, Content);
                   */
                screens.RemoveAt(0);
   
            }
             

            currentScreen.Draw(spriteBatch);
            
           
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
     
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
