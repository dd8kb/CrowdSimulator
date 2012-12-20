using System;
using System.Collections.Generic;
using System.Drawing;
using CrowdSimulator.Human_Factories;

namespace CrowdSimulator
{
    public class Crowd
    {
        private readonly List<Human> humans;

        private readonly Field field;

        private readonly Bitmap bitmap;

        private static int width;
        
        private static int height;

        private int frameCount;

        private readonly Graphics graphics;

        private static readonly Random Rnd = new Random(DateTime.Now.Millisecond);

        public Crowd(Bitmap Bitmap)
        {
            this.bitmap = Bitmap;
            this.humans = new List<Human>();
            this.field = new Field(Bitmap.Width, Bitmap.Height);
            height = Bitmap.Height;
            width = Bitmap.Width;
            this.graphics = Graphics.FromImage(bitmap);
        }

        public void Init(int Humans, int Assassins)
        {
            var agentFactory = new AgentFactory();
            var humanFactory = new HumanFactory();

            for (int i = 0; i < Humans; i++)
            {
                humans.Add(humanFactory.CreateHuman());
            }

            for (int i = 0; i < Assassins; i++)
            {
                humans.Add(agentFactory.CreateHuman(humans));
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
                if (h.HumanType == HumanType.Normal)
                {
                    graphics.FillEllipse(Brushes.Black, h.Position.X - 2, h.Position.Y - 2, 4, 4);    
                }
                else if (h.HumanType == HumanType.Agent)
                {
                    graphics.FillEllipse(Brushes.Red, h.Position.X - 2, h.Position.Y - 2, 4, 4);
                }
                else if (h.HumanType==HumanType.Dead)
                {
                    graphics.FillEllipse(Brushes.GreenYellow, h.Position.X - 2, h.Position.Y - 2, 4, 4);
                }
                else if (h.HumanType == HumanType.Victim)
                {
                    graphics.FillRectangle(Brushes.DeepSkyBlue, h.Position.X - 2, h.Position.Y - 2, 4, 4);
                }

            }
        }

        private List<Human> GetNearestNeighbour(Human LeMe)
        {
            return field.GetNearestNeighbour(LeMe.FieldIndex, LeMe.Position);
        }

        public static Vec2 GetRandomPosition()
        {
            return new Vec2(Rnd.Next(0, width), Rnd.Next(0, height));
        }
    }
}
