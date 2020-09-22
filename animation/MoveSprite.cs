using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using firstrate.collision;

namespace firstrate.animation
{
    class MoveSprite
    {
        private int x;
        private int y;
        private int row;
        private AnimateSprite animateSprite;
        private LevelMap levelMap;
        

        public MoveSprite(int x, int y, Texture2D character) 
        {
            this.x = x;
            this.y = y;
            animateSprite = new AnimateSprite(character,4,4);
        }

        public void Update(LevelMap levelMap)
        {
            KeyboardState keyboardState = Keyboard.GetState();
           
            if (keyboardState.IsKeyDown(Keys.A) && x > levelMap.lowX)
            {
                x -= 7;
                row = 2;
                animateSprite.Update();
            }
            else if (keyboardState.IsKeyDown(Keys.D) && x < levelMap.highX)
            {
                x += 7;
                row = 3;
                animateSprite.Update();
            }
            else if (keyboardState.IsKeyDown(Keys.W) && y > levelMap.lowY)
            {
                y -= 6;
                row = 1;
                animateSprite.Update();
            }
            else if (keyboardState.IsKeyDown(Keys.S) && y < levelMap.highY)
            {
                y += 6;
                row = 0;
                animateSprite.Update();
            }
            
            
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D character)
        {
            animateSprite.Draw(spriteBatch, new Vector2(x, y), row);
            //spriteBatch.Draw(character, new Vector2(x, y), Color.White);
        }

    }
}
