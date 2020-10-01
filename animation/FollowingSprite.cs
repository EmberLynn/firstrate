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
        public int x;
        public int y;

        private int row;
        private AnimateSprite animateSprite;
        private List<int> movementBuffer;

        public FollowingSprite(Texture2D character, int x, int y)
        {
            animateSprite = new AnimateSprite(character, 4, 4);
            this.x = x;
            this.y = y;
            movementBuffer = new List<int>();
        }

        public void Update(int x, int y, int row)
        {
            if(movementBuffer.Count < 12)
            {
                movementBuffer.Add(x);
                movementBuffer.Add(y);
            }
            else 
            {

                if (this.y < movementBuffer[1])
                {
                    this.row = row;
                    this.y = movementBuffer[1];
                }
                if (this.x < movementBuffer[0])
                {
                    this.row = row;
                    this.x = movementBuffer[0];
                }
                if (this.x > movementBuffer[0])
                {
                    this.row = row;
                    this.x = movementBuffer[0];
                }
                if (this.y > movementBuffer[1])
                {
                    this.row = row;
                    this.y = movementBuffer[1];
                }
                animateSprite.Update();
                movementBuffer.RemoveAt(0);
                movementBuffer.RemoveAt(0);
            }

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            animateSprite.Draw(spriteBatch, new Vector2(x,y), row);
        }
    }
}
