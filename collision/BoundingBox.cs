using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstrate.collision
{
    class BoundingBox
    {
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        private Vector2 position;

        public float width { get; set; }
        public float height { get; set; }

        public BoundingBox(Vector2 position, int width, int height)
        {
            this.position = position;
            this.width = width;
            this.height = height;
        }

        public float top
        {
            get { return position.Y; }
            set { position.Y = value; }
        }
        public float bottom
        {
            get { return position.Y + height; }
            set { position.Y = value - height; }
        }
        public float left
        {
            get { return position.X; }
            set { position.X = value; }
        }
        public float right
        {
            get { return position.X + width; }
            set { position.Y = value - width; }
        }

        public bool collisionCheck(BoundingBox box)
        {
           if(this.left < box.right 
                && this.right > box.left
                && this.top < box.bottom
                && this.bottom > box.top)
            { 
                return true; 
            }
            return false;
        }
    }
}
