using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstrate.collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace firstrate.screens
{
    class FirstScreen
    {
        public LevelMap levelMap { get; }
        public FirstScreen()
        {
            levelMap = new LevelMap(655, 0, 630, 0);
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D firstScreen) 
        {
            spriteBatch.Draw(firstScreen, new Rectangle(0, 0, 700, 700), Color.White);
        }
    }
}
