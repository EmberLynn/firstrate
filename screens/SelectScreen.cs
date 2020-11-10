using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstrate.screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace firstrate.selectscreen
{
    class SelectScreen : Screen
    {
        //select screen
        private int selectorX;
        private int selectorY;
        //public string selected { get; set;}
        //public bool isDone { get; set; }

        //Old keyboard state
        private KeyboardState oldState;

        //textures
        private Texture2D selectScreen;
        private Texture2D selector;

        public SelectScreen(ContentManager Content) : base(Content)
        {
            selectorX = 172;
            selectorY = 270;
            isDone = false;
            selectScreen = Content.Load<Texture2D>("selectscreen/selectscreen");
            selector = Content.Load<Texture2D>("selectscreen/selector");
        }

        public override void UnloadContent()
        {
            selectScreen.Dispose();
            selector.Dispose();
        }
    
        public override void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (oldState.IsKeyUp(Keys.D) && keyboardState.IsKeyDown(Keys.D))
            {
                selectorX = 356;
            }
            if (oldState.IsKeyUp(Keys.A) && keyboardState.IsKeyDown(Keys.A))
            {
                selectorX = 172;
            }
            if (oldState.IsKeyUp(Keys.Enter) && keyboardState.IsKeyDown(Keys.Enter))
            {
                if (selectorX == 356)
                {
                    data = "Ember";
                }
                else
                {
                    data = "Gio";
                }

                isDone = true;
            }
            oldState = keyboardState;
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            //draw select screen
            spriteBatch.Draw(this.selectScreen, new Rectangle(0, 0, 700, 700), Color.White);

            //draw selector
            spriteBatch.Draw(this.selector, new Vector2(selectorX, selectorY), Color.White);
        }

    }
}
