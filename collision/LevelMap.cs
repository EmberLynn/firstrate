using System;
using System.Collections.Generic;
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
        
        public LevelMap(int highX, int lowX, int highY, int lowY) 
        {
            this.highX = highX;
            this.lowX = lowX;
            this.highY = highY;
            this.lowY = lowY;
        }

        //has array of bounding boxes
    }
}
