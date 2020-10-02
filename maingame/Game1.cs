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
        private Texture2D selectScreen;
        private Texture2D selector;
        private SelectScreen loadSelectScreen = new SelectScreen();

        //first area screen
        private Texture2D firstScreen;
        private FirstScreen loadFirstScreen = new FirstScreen();

        //characters
        private Texture2D emberCharacter;
        private Texture2D gioCharacter;

        //character movement
        private MainSprite moveGio;
        private FollowingSprite moveEmber;
        private float animationTimer;

        //test
        private Texture2D pixelSquare;
        private BoundingBox testBoundingBox;

        //collision

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

            //load select screen
            selectScreen = Content.Load<Texture2D>("selectscreen/selectscreen");
            selector = Content.Load<Texture2D>("selectscreen/selector");

            //load firstscreen
            firstScreen = Content.Load<Texture2D>("firstarea/testbackground");
            
            //load characters
            gioCharacter = Content.Load<Texture2D>("sprites/giowalkcycle");
            emberCharacter = Content.Load<Texture2D>("sprites/emberwalkcycle");
            moveEmber = new FollowingSprite(emberCharacter, 350, 349);
            moveGio = new MainSprite(gioCharacter, moveEmber, 350, 350);

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
            if(!loadSelectScreen.isDone)
            {
                loadSelectScreen.Update();
            }

            animationTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (animationTimer > 120)
            {
                moveGio.Update(loadFirstScreen.levelMap);
                animationTimer = 0;
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
            if (!loadSelectScreen.isDone)
            {
                loadSelectScreen.Draw(spriteBatch, selectScreen, selector);
            }
            else 
            {
                loadFirstScreen.Draw(spriteBatch, firstScreen);
            }
            
            if(loadSelectScreen.selected.Equals("Gio"))
            {
                if(moveEmber.y < moveGio.y)
                {
                    moveEmber.Draw(spriteBatch);
                    moveGio.Draw(spriteBatch);
                }
                else
                {
                    moveGio.Draw(spriteBatch);
                    moveEmber.Draw(spriteBatch);
                }
                
            }
            else if(loadSelectScreen.selected.Equals("Ember"))
            {
                //moveEmber.Draw(spriteBatch);
            }

            //spriteBatch.Draw(pixelSquare, testBoundingBox.Position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
