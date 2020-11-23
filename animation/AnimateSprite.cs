using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace firstrate.animation
{
    class AnimateSprite
    {
        public Texture2D texture { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        //this object holds the atlas, knows how many images are in the atlas, and keeps track of 
        //what frame we are on in the atlas
        public AnimateSprite(Texture2D texture, int rows, int columns, bool isMoving)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
            
            if (isMoving)
            {
                totalFrames = this.columns;
            }
            else
            {
                totalFrames = this.rows * this.columns;
            }
          
        }
        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        //determine how many individual images are in the frame by finding its width and height
        //then find what frame we are on to know which image in the atlas to draw
        public void Draw(SpriteBatch spriteBatch, Vector2 location, int row)
        {
            int width = this.texture.Width / this.columns;
            int height = this.texture.Height / this.rows;
            if(row == 0)
            {
                row = (int)((float)currentFrame / (float)this.columns);
            }
            int column = currentFrame % this.columns;

            //the rectangle we want to draw
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            //where we want to draw it
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(this.texture, destinationRectangle, sourceRectangle, Color.White);


        }
    }
}
