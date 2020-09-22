using firstrate.animation;
using firstrate.collision;
using firstrate.selectscreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        private Texture2D emberCharacter;
        private Texture2D gioCharacter;

        //character movement
        private MoveSprite moveSprite;
        private float animationTimer;

        //test
        private Texture2D pixelSquare;

        //collision
        private LevelMap levelMap;

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
           
            
            //load characters
            gioCharacter = Content.Load<Texture2D>("firstarea/giosprite");
            emberCharacter = Content.Load<Texture2D>("firstarea/embersprite");
            moveSprite = new MoveSprite(350, 350, gioCharacter);

            //test
            pixelSquare = Content.Load<Texture2D>("test/70sqpixel");
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

            if(animationTimer > 100)
            {
                moveSprite.Update();
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //draw select screen
            if (!loadSelectScreen.isDone)
            {
                loadSelectScreen.Draw(spriteBatch, selectScreen, selector);
            }
            
            if(loadSelectScreen.selected.Equals("Gio"))
            {
                moveSprite.Draw(spriteBatch, gioCharacter);
                spriteBatch.Draw(pixelSquare, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(pixelSquare, new Vector2(630, 630), Color.White);
            }
            else if(loadSelectScreen.selected.Equals("Ember"))
            {
                spriteBatch.Draw(emberCharacter, new Vector2(350, 350), Color.White);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
