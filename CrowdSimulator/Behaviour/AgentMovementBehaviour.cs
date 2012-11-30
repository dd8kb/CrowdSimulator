using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdSimulator.Behaviour
{
    public class AgentMovementBehaviour : IMovementBehaviour
    {

        private Vec2 velocity;

        private Vec2 distance;

        private float speed;

        private Random rnd = new Random();

        public AgentMovementBehaviour()
        {
            velocity = new Vec2(0, 0);

            distance = new Vec2(0, 0);

            speed = 2.0f;
        }

        public Vec2 Move(Human LeMe, IEnumerable<Human> NearestNeighbours)
        {
            if ((LeMe.Node - LeMe.Position).Length() < 14f)
            {
                LeMe.Node = this.GetNewTarget(LeMe);
            }

            this.velocity = LeMe.Node - LeMe.Position;

            this.velocity.Mul(1.0f/this.velocity.Length());

            this.velocity.Mul(this.speed);

            foreach (
                var human in
                    NearestNeighbours.Where(
                        Human =>
                        Human.Position != LeMe.Position &&
                        Human.HumanType != HumanType.Victim))
            {
                this.distance = human.Position - LeMe.Position;

                var num = this.distance.Length();

                distance.Mul(1.0f/distance.Length());

                distance.Mul(1.7f);

                if (!(num <= 25.0f))
                {
                    continue;
                }

                num = 25.0f - num;

                num /= 25.0f;

                this.distance.Mul(num*-1f);

                this.distance.Mul(3.5f);

                this.velocity += this.distance;
            }

            LeMe.Position = LeMe.Position + this.velocity;

            return LeMe.Position;
        }

        private Vec2 GetNewTarget(Human LeMe)
        {
            return LeMe.RequestNewRandomPosition();
        }

    }
}
