using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstrate.collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BoundingBox = firstrate.collision.BoundingBox;

namespace firstrate.screens
{
    class SecondScreenTest : Screen
    {
        private Texture2D testScreen;
        public SecondScreenTest(ContentManager Content) : base(Content)
        {
            levelMap = new LevelMap(700, 0, 700, 0);
            coordinates = new List<int>();
            
            //set all of the objects on the map
            coordinates.Add(1);
            coordinates.Add(1);

            testScreen = Content.Load<Texture2D>("tutorialscreen/tutotialroom");

            levelMap.addObjects(coordinates);
        }



        public override void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(testScreen, new Rectangle(0, 0, 700, 700), Color.White);
        }
    }
}
