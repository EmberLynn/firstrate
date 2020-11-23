using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstrate.animation;
using firstrate.collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BoundingBox = firstrate.collision.BoundingBox;


namespace firstrate.screens
{
    class FirstScreen : Screen
    {
        private Texture2D firstScreen;

        //animations for dog
        private Texture2D daveTheDog;
        private AnimateSprite daveAnimation;
        private float animationTimer;
        public FirstScreen(ContentManager Content) : base(Content)
        {
            levelMap = new LevelMap(700, 0, 700, 0);
            coordinates = new List<int>();
            isDone = false;

            //upper wall
            coordinates.Add(1);
            coordinates.Add(1);


            //dog
            coordinates.Add(5);
            coordinates.Add(5);

            //load content
            firstScreen = Content.Load<Texture2D>("tutorialscreen/tutotialroom");
            daveTheDog = Content.Load<Texture2D>("tutorialscreen/dogsprite");
            daveAnimation = new AnimateSprite(daveTheDog,2,4, false);

            levelMap.addObjects(coordinates);
        }

        public override void Update(float gameTime)
        {
            animationTimer += gameTime;
          
            if (animationTimer > 450)
            {
                daveAnimation.Update();
                animationTimer = 0;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Draw(firstScreen, new Rectangle(0, 0, 700, 700), Color.White);
            daveAnimation.Draw(spriteBatch, new Vector2(280,280), 0);
        }
    }
}
