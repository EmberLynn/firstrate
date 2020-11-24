using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstrate.animation
{

    class FollowingSprite
    {
        public int x { get; set; }
        public int y { get; set; }

        private int row;
        private AnimateSprite animateSprite;
        private List<int> movementBuffer;

        public FollowingSprite(Texture2D character, int x, int y)
        {
            animateSprite = new AnimateSprite(character, 4, 4, true);
            this.x = x;
            this.y = y;
            movementBuffer = new List<int>();
        }

        public void Update(int x, int y, int row)
        {
            if(movementBuffer.Count < 15)
            {
                movementBuffer.Add(x);
                movementBuffer.Add(y);
            }
            else 
            {
                
                if (this.y < movementBuffer[1])
                {
                    this.row = 0;
                    this.y = movementBuffer[1];
                    animateSprite.Update();
                }
                if (this.x < movementBuffer[0])
                {
                    this.row = 3;
                    this.x = movementBuffer[0];
                    animateSprite.Update();
                }
                if (this.x > movementBuffer[0])
                {
                    this.row = 2;
                    this.x = movementBuffer[0];
                    animateSprite.Update();
                }
                if (this.y > movementBuffer[1])
                {
                    this.row = 1;
                    this.y = movementBuffer[1];
                    animateSprite.Update();
                }
                movementBuffer.RemoveAt(0);
                movementBuffer.RemoveAt(0);
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            animateSprite.Draw(spriteBatch, new Vector2(x,(y-30)), row);
        }
    }
}
