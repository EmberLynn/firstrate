using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace firstrate.collision
{
    class LevelMap
    {
        public int highX { get; }
        public int lowX { get; }
        public int highY { get; }
        public int lowY { get; }

        public List<BoundingBox> items { get; set; }
        
        public LevelMap(int highX, int lowX, int highY, int lowY) 
        {
            this.highX = highX;
            this.lowX = lowX;
            this.highY = highY;
            this.lowY = lowY;
            this.items = new List<BoundingBox>();
        }

        //might want to figure out a way to accept a range of coordinates to make large blocks of objects to collide with
        public void addObjects(List<int> coordinates)
        {
            int y;
            int x;

            for(int i = 0; i < coordinates.Count-1; i+=2)
            {
                x = (coordinates[i] - 1) * 70;
                y = (coordinates[i + 1] - 1) * 70;
                items.Add(new BoundingBox(new Vector2(x, y), 70, 70, ""));
            }
        }

        public void addObjectsWithName(int x, int y, string name)
        {
            /*x = x * 70;
            y = y * 70;*/
            items.Add(new BoundingBox(new Vector2((x-1)*70, (y-1)*70), 70, 70, name));
        }

    }
}
