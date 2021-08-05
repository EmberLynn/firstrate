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
    class SecondScreen : Screen
    {
        //main view
        private Texture2D secondScreen;

        public SecondScreen(ContentManager Content)
        {
            levelMap = new LevelMap(700, 0, 700, 0);

            //load content
            secondScreen = Content.Load<Texture2D>("tutorialscreen/tutotialroom");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(secondScreen, new Rectangle(0, 0, 700, 700), Color.White);
        }
    }
}
