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
        public int x { get;  set; }
        public int y { get; set; }
        public bool isSet;
        private int row;
        private AnimateSprite animateSprite;
        private LevelMap levelMap;
        private BoundingBox boundingBox;
        private Vector2 oldPosition;
        private KeyboardState oldState;
        //private Keys movementKey;
        private List<char> keys = new List<char>();
        


        public MoveSprite(Texture2D character) 
        {
            boundingBox = new BoundingBox(new Vector2(x, y), 45, 71);
            animateSprite = new AnimateSprite(character,4,4);
            isSet = false;
        }

        //other box is for testing; will be using level map instead
        public void Update(LevelMap levelMap)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keys.Count > 0) 
            {
                foreach (BoundingBox box in levelMap.items)
                {
                    if (boundingBox.collisionCheck(box) || boundingBox.borderCollision(levelMap))
                    {
                        boundingBox.Position = oldPosition;
                        if (keys[keys.Count - 1] == 'W')
                        {
                            y += 6;
                        }
                        if (keys[keys.Count - 1] == 'S')
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
                if (keys[keys.Count - 1] == 'W' && keyboardState.IsKeyDown(Keys.W))
                {
                    y -= 6;
                    row = 1;
                    animateSprite.Update();
                }
                if (keys[keys.Count-1] == 'A' && keyboardState.IsKeyDown(Keys.A))
                {
                    x -= 7;
                    row = 2;
                    animateSprite.Update();
                }
                if (keys[keys.Count - 1] == 'S' && keyboardState.IsKeyDown(Keys.S))
                {
                    y += 6;
                    row = 0;
                    animateSprite.Update();
                }
                if (keys[keys.Count-1] == 'D' && keyboardState.IsKeyDown(Keys.D))
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
            isSet = true;
            //spriteBatch.Draw(character, new Vector2(x, y), Color.White);
        }

    }
}
