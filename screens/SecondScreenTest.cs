using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstrate.collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BoundingBox = firstrate.collision.BoundingBox;

namespace firstrate.screens
{
    class SecondScreenTest
    {
        public LevelMap levelMap { get; }
        public List<int> coordinates { get; }
        public SecondScreenTest()
        {
            levelMap = new LevelMap(700, 0, 700, 0);
            coordinates = new List<int>();
            
            //set all of the objects on the map
            coordinates.Add(1);
            coordinates.Add(1);

            levelMap.addObjects(coordinates);
        }

        //need to figure out how to add objects to levelMap

        public void Draw(SpriteBatch spriteBatch, Texture2D firstScreen) 
        {
            spriteBatch.Draw(firstScreen, new Rectangle(0, 0, 700, 700), Color.White);
        }
    }
}
