using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstrate.animation;
using firstrate.collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BoundingBox = firstrate.collision.BoundingBox;
using firstrate.helpers;


namespace firstrate.screens
{
    class FirstScreen : Screen
    {
        //main view
        private Texture2D firstScreen;

        //animations for dog
        private Texture2D daveTheDog;
        private AnimateSprite daveAnimation;
        private float animationTimer;

        //talking to the dog
        private Texture2D dialogScreen;
        private KeyboardState oldState;
        private bool drawDialog;
        private DialogReader dialogReader = new DialogReader();
        private SpriteFont retroFont;
        private string currentDialog = "";

        public FirstScreen(ContentManager Content)
        {
            levelMap = new LevelMap(700, 0, 700, 0);
            coordinates = new List<int>();
            isDone = false;
            data = "";

            //upper wall
            //would like to streamline the adding process at some point
            coordinates.Add(1);
            coordinates.Add(1);
            coordinates.Add(2);
            coordinates.Add(1);
            coordinates.Add(3);
            coordinates.Add(1);
            coordinates.Add(4);
            coordinates.Add(1);
            coordinates.Add(5);
            coordinates.Add(1);
            coordinates.Add(6);
            coordinates.Add(1);
            coordinates.Add(7);
            coordinates.Add(1);
            coordinates.Add(8);
            coordinates.Add(1);
            coordinates.Add(9);
            coordinates.Add(1);

            //dog
            levelMap.addObjectsWithName(5, 5, "Dave");

            //load content
            firstScreen = Content.Load<Texture2D>("tutorialscreen/tutotialroom");
            dialogScreen = Content.Load<Texture2D>("tutorialscreen/dialogscreen");
            
            //load font
            retroFont = Content.Load<SpriteFont>("fonts/RetroFont");

            daveTheDog = Content.Load<Texture2D>("tutorialscreen/dogsprite");
            daveAnimation = new AnimateSprite(daveTheDog,2,4, false);

            //dialog for dog
            //using absolute path for now -- will be changed in the future, but this is good enough for now
            dialogReader.getDialog(@"C:\Users\ember\source\repos\firstrate\Content\TestDialog.txt");

            levelMap.addObjects(coordinates);
        }

        public override void Update(float gameTime, MainSprite main)
        {
            //talking to dogs
            KeyboardState keyboardState = Keyboard.GetState();
            if(data.Equals("Dave"))
            {
                if (oldState.IsKeyUp(Keys.Enter) && keyboardState.IsKeyDown(Keys.Enter))
                {
                    //lock the character's animation and allow the dialog box to be drawn
                    drawDialog = true;
                    main.locked = true;
                    dialogReader.nextLine();

                    //reset the dialog reader and unlock character animation once we've reached the end of the dialog
                    if(dialogReader.isDialogDone())
                    {
                        main.locked = false;
                        drawDialog = false;
                        dialogReader = new DialogReader();
                        dialogReader.getDialog(@"C:\Users\ember\source\repos\firstrate\Content\TestDialog.txt");
                    }
                }
            }
          
            if(drawDialog)
            {
                currentDialog = dialogReader.typeLine(animationTimer);
            }
            //for unlock test
            if (keyboardState.IsKeyDown(Keys.P))
            {
                main.locked = false;
            }

            //dog animation
            animationTimer += gameTime;
            if (animationTimer > 450)
            {
                daveAnimation.Update();
                animationTimer = 0;
            }

            oldState = keyboardState;
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(firstScreen, new Rectangle(0, 0, 700, 700), Color.White);
            daveAnimation.Draw(spriteBatch, new Vector2(280,280), 0);

            if(drawDialog)
            {
                spriteBatch.Draw(dialogScreen, new Rectangle(0, 529, 700, 171), Color.White);
                spriteBatch.DrawString(retroFont, currentDialog, new Vector2(45, 570), Color.Red);
            }
            
        }
    }
}
