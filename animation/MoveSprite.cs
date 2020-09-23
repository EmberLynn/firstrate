using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using firstrate.collision;
using BoundingBox = firstrate.collision.BoundingBox;
namespace firstrate.animation
{
    class MoveSprite
    {
        private int x;
        private int y;
        private int row;
        private AnimateSprite animateSprite;
        private LevelMap levelMap;
        private BoundingBox boundingBox;
        private Vector2 currentPosition;
        private Vector2 oldPosition;
        private KeyboardState oldState;
        private Keys movementKey;


        public MoveSprite(int x, int y, Texture2D character) 
        {
            this.x = x;
            this.y = y;
            boundingBox = new BoundingBox(new Vector2(x, y), 45, 71);
            animateSprite = new AnimateSprite(character,4,4);
        }

        public void Update(LevelMap levelMap, BoundingBox otherBox)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (boundingBox.collisionCheck(otherBox))
            {
                boundingBox.Position = oldPosition;
                if(oldState.IsKeyDown(Keys.W))
                {
                    y += 6;
                }
                if (oldState.IsKeyDown(Keys.S))
                {
                    y -= 6;
                }
                if (oldState.IsKeyDown(Keys.A))
                {
                    x += 7;
                }
                if (oldState.IsKeyDown(Keys.D))
                {
                    x -= 7;
                }

            }

            if (keyboardState.IsKeyDown(Keys.W) && y > levelMap.lowY)
            {
                y -= 6;
                row = 1;
                animateSprite.Update();
            }
            else if (keyboardState.IsKeyDown(Keys.A) && x > levelMap.lowX)
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
            else if (keyboardState.IsKeyDown(Keys.S) && y < levelMap.highY)
            {
                y += 6;
                row = 0;
                animateSprite.Update();
            }
            oldPosition = boundingBox.Position;
            oldState = keyboardState;
            boundingBox.Position = new Vector2(x, y);
   
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animateSprite.Draw(spriteBatch, boundingBox.Position, row);
            //spriteBatch.Draw(character, new Vector2(x, y), Color.White);
        }

    }
}
