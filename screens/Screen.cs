using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using firstrate.animation;

namespace firstrate.screens
{
    class Screen
    {
        public collision.LevelMap levelMap { get; set; }
        public List<int> coordinates { get; set; }
        public bool isDone { get; set; }

        public string data { get; set; }

        public Screen() { }

        public virtual void Update(float gameTime, MainSprite main) { }

        public virtual void UnloadContent() { }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
