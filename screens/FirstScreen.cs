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
    class FirstScreen : Screen
    {
        //public bool isDone {get; set;}
        private Texture2D firstScreen;
        public FirstScreen(ContentManager Content) : base(Content)
        {
            levelMap = new LevelMap(700, 0, 700, 0);
            coordinates = new List<int>();
            isDone = false;
            //set all of the objects on the map
            coordinates.Add(1);
            coordinates.Add(1);
            coordinates.Add(1);
            coordinates.Add(2);

            firstScreen = Content.Load<Texture2D>("firstarea/testbackground");

            levelMap.addObjects(coordinates);
        }

        public override void Update()
        {
            //Console.WriteLine("Inside update in firstscreen");
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.P))
            {
                isDone = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(firstScreen, new Rectangle(0, 0, 700, 700), Color.White);
        }
    }
}
