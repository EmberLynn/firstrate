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
        
        //get rid of params and hardcode size, for now
        public LevelMap(int highX, int lowX, int highY, int lowY) 
        {
            this.highX = highX;
            this.lowX = lowX;
            this.highY = highY;
            this.lowY = lowY;
            this.items = new List<BoundingBox>();
        }

        public void addObjects(List<int> coordinates)
        {
            int y = 0;
            int x = 0;

            for(int i = 0; i < coordinates.Count-1; i+=2)
            {
                x = (coordinates[i] - 1) * 70;
                y = (coordinates[i + 1] - 1) * 70;
                items.Add(new BoundingBox(new Vector2(x, y), 70, 70));
            }
            
        }

    }
}
