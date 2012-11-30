using System;
using System.Collections.Generic;
using System.Drawing;

namespace CrowdSimulator
{
    class Crowd
    {
        private readonly List<Human> humans;

        private readonly Field field;

        private readonly Bitmap bitmap;

        private static int width;
        
        private static int height;

        private int frameCount;

        private readonly Graphics graphics;

        // UIIII!!!!!!!!!!!!!!!!!!!!!!!!
        public static List<Vec2> speedOvers=new List<Vec2>();

        public Crowd(Bitmap Bitmap)
        {
            this.bitmap = Bitmap;
            this.humans = new List<Human>();
            this.field = new Field(Bitmap.Width, Bitmap.Height);
            Crowd.height = Bitmap.Height;
            Crowd.width = Bitmap.Width;
            this.graphics = Graphics.FromImage(bitmap);
        }

        public void Init(int Humans, int Assassins)
        {
            var total = Humans + Assassins;
            var row = (int)Math.Sqrt(total);
            var xIncrement = this.bitmap.Width / row;
            var yIncrement = this.bitmap.Height / row;
            var r = new Random();
            
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    this.humans.Add(new Human(HumanType.Normal, new Vec2( x * xIncrement, y * yIncrement), new Vec2(r.Next(0,this.bitmap.Width),r.Next(0,this.bitmap.Height))));
                }
            }

            for (int i = 0; i < Assassins; i++)
            {
                var next = r.Next(0, this.humans.Count - 1);

                if (this.humans[next].HumanType != HumanType.Agent)
                {
                    this.humans[next].HumanType = HumanType.Agent;

                    continue;
                }

                i--;
            }

            field.Update(this.humans);
        }

        public void Update()
        {
            frameCount++;

            foreach (var h in humans)
            {
                h.Update(this.GetNearestNeighbour(h));
            }

            if (frameCount >= 10)
            {
                field.Update(this.humans);
                frameCount = 0;
            }

            this.Draw();
        }

        private void Draw()
        {
            graphics.Clear(Color.White);

            foreach (var h in humans)
            {
                graphics.FillEllipse(Brushes.Black,h.Position.X-2,h.Position.Y-2,4,4);
            }

            //UI!!!!!!!!!!!!!!!!
            foreach (var s in Crowd.speedOvers)
            {
                graphics.FillEllipse(Brushes.Red, s.X, s.Y, 2, 2);
            }
        }

        private List<Human> GetNearestNeighbour(Human LeMe)
        {
            return field.GetNearestNeighbour(LeMe.FieldIndex, LeMe.Position);
        }

        public static Vec2 GetRandomPosition()
        {
            Random rnd = new Random();
            return new Vec2(rnd.Next(0,Crowd.width),rnd.Next(0,Crowd.height));
        }

    }
}
