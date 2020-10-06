using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace firstrate.selectscreen
{
    class SelectScreen
    {
        //select screen
        private int selectorX;
        private int selectorY;
        public string selected { get; set;}
        public Boolean isDone { get; set; }

        //Old keyboard state
        private KeyboardState oldState;

        //textures
        private Texture2D selectScreen;
        private Texture2D selector;

        private ContentManager content;

        public SelectScreen(ContentManager Content)
        {
            selectorX = 172;
            selectorY = 270;
            isDone = false;
            selected = "";
            this.selectScreen = Content.Load<Texture2D>("selectscreen/selectscreen");
            this.selector = Content.Load<Texture2D>("selectscreen/selector");
            this.content = Content;
        }

        public void UnloadContent()
        {
            selectScreen.Dispose();
            selector.Dispose();
        }
    
        public void Update()
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
                    selected = "Ember";
                }
                else
                {
                    selected = "Gio";
                }

                isDone = true;
            }
            oldState = keyboardState;
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            //draw select screen
            spriteBatch.Draw(this.selectScreen, new Rectangle(0, 0, 700, 700), Color.White);

            //draw selector
            spriteBatch.Draw(this.selector, new Vector2(selectorX, selectorY), Color.White);
        }

    }
}
