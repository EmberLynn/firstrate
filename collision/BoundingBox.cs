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
        //collision is rudimentary, but good enough for now.  Will probably look into how to refine this further later.

        //object needs to know if it can be interacted with by the main player
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 position;

        public float width { get; set; }
        public float height { get; set; }

        public string name { get; set; }

        public BoundingBox(Vector2 position, int width, int height, string name)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.name = name;
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

        public bool borderCollision(LevelMap levelMap)
        {
            if(this.left < levelMap.lowX
                || this.right > levelMap.highX
                || this.top < levelMap.lowY
                || this. bottom > levelMap.highY)
                return true;

            return false;
        }
    }
}
