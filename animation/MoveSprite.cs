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
        private Vector2 oldPosition;
        private KeyboardState oldState;
        //private Keys movementKey;
        private List<char> keys = new List<char>();


        public MoveSprite(int x, int y, Texture2D character) 
        {
            this.x = x;
            this.y = y;
            boundingBox = new BoundingBox(new Vector2(x, y), 45, 71);
            animateSprite = new AnimateSprite(character,4,4);
        }

        //other box is for testing; will be using level map instead
        public void Update(LevelMap levelMap, BoundingBox otherBox)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (boundingBox.collisionCheck(otherBox))
            {
                boundingBox.Position = oldPosition;
                if (keys[keys.Count - 1] == 'W')
                {
                    y += 6;
                }
                if (keys[keys.Count-1] == 'S')
                {
                    y -= 6;
                }
                if (keys[keys.Count - 1] == 'A')
                {
                    x += 7;
                }
                if (keys[keys.Count - 1] == 'D')
                {
                    x -= 7;
                }

            }
            
            if(keyboardState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
            {
                keys.Add('A');
            }
            if (keyboardState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W))
            {
                keys.Add('W');
            }
            if (keyboardState.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S))
            {
                keys.Add('S');
            }
            if (keyboardState.IsKeyDown(Keys.D) && oldState.IsKeyUp(Keys.D))
            {
                keys.Add('D');
            }

            if (keyboardState.IsKeyUp(Keys.A))
            {
                keys.Remove('A');
            }
            if (keyboardState.IsKeyUp(Keys.W))
            {
                keys.Remove('W');
            }
            if (keyboardState.IsKeyUp(Keys.S))
            {
                keys.Remove('S');
            }
            if (keyboardState.IsKeyUp(Keys.D))
            {
                keys.Remove('D');
            }
           
            if(keys.Count != 0) 
            {
                if (keys[keys.Count - 1] == 'W' && keyboardState.IsKeyDown(Keys.W) && y > levelMap.lowY)
                {
                    y -= 6;
                    row = 1;
                    animateSprite.Update();
                }
                if (keys[keys.Count-1] == 'A' && keyboardState.IsKeyDown(Keys.A) && x > levelMap.lowX)
                {
                    x -= 7;
                    row = 2;
                    animateSprite.Update();
                }
                if (keys[keys.Count - 1] == 'S' && keyboardState.IsKeyDown(Keys.S) && y < levelMap.highY)
                {
                    y += 6;
                    row = 0;
                    animateSprite.Update();
                }
                if (keys[keys.Count-1] == 'D' && keyboardState.IsKeyDown(Keys.D) && x < levelMap.highX)
                {
                    x += 7;
                    row = 3;
                    animateSprite.Update();
                }
                
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
