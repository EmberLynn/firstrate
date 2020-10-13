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
    class FirstScreen
    {
        public LevelMap levelMap { get; }
        public List<int> coordinates { get; }
        public bool isDone {get; set;}

        //content to load
        private Texture2D firstScreen;
        public FirstScreen(ContentManager Content)
        {
            levelMap = new LevelMap(700, 0, 700, 0);
            coordinates = new List<int>();
            isDone = false;
            //set all of the objects on the map
            coordinates.Add(1);
            coordinates.Add(1);
            coordinates.Add(1);
            coordinates.Add(2);
            levelMap.addObjects(coordinates);

            this.firstScreen = Content.Load<Texture2D>("firstarea/testbackground");
        }

        public void UnloadContent()
        {
            firstScreen.Dispose();
        }

        public void Update()
        {
            //Console.WriteLine("Inside update in firstscreen");
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.P))
            {
                isDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(this.firstScreen, new Rectangle(0, 0, 700, 700), Color.White);
        }
    }
}
