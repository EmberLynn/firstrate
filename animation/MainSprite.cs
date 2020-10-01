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
    class MainSprite
    {
        private int x;
        private int y; 
        
        private int row;
        private AnimateSprite animateSprite;
        private BoundingBox boundingBox;
        public Vector2 oldPosition { set; get; }
        private KeyboardState oldState;
        //private Keys movementKey;
        private List<char> keys = new List<char>();

        //following
        private FollowingSprite followingSprite;
        


        public MainSprite(Texture2D character, FollowingSprite followingSprite ,int x, int y) 
        {
            boundingBox = new BoundingBox(new Vector2(x, y), 45, 70);
            animateSprite = new AnimateSprite(character,4,4);
            this.followingSprite = followingSprite;
            this.x = x;
            this.y = y;
       
        }

        //other box is for testing; will be using level map instead
        public void Update(LevelMap levelMap)
        {
            KeyboardState keyboardState = Keyboard.GetState();

          
                if (keys.Count > 0)
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



                if (keyboardState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
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

                if (keys.Count != 0)
                {
                    if (keys[keys.Count - 1] == 'W' && keyboardState.IsKeyDown(Keys.W))
                    {
                        y -= 6;
                        row = 1;

                }
                    if (keys[keys.Count - 1] == 'A' && keyboardState.IsKeyDown(Keys.A))
                    {
                        x -= 7;
                        row = 2;
                }
                    if (keys[keys.Count - 1] == 'S' && keyboardState.IsKeyDown(Keys.S))
                    {
                        y += 6;
                        row = 0;
                }
                    if (keys[keys.Count - 1] == 'D' && keyboardState.IsKeyDown(Keys.D))
                    {
                        x += 7;
                        row = 3;
                }
                animateSprite.Update();
                followingSprite.Update(x, y, row);

            }

           
            oldPosition = boundingBox.Position;
            boundingBox.Position = new Vector2(x, y);
            oldState = keyboardState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //followingSprite.Draw(spriteBatch);
            animateSprite.Draw(spriteBatch, boundingBox.Position, row);
        }

    }
}
