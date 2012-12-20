using System.Collections.Generic;
using System.Linq;

namespace CrowdSimulator.Behaviour
{
    public class AgentMovementBehaviour : IMovementBehaviour
    {

        private Vec2 velocity;

        private Vec2 distance;

        private readonly float speed;

        public AgentMovementBehaviour()
        {
            velocity = new Vec2(0, 0);

            distance = new Vec2(0, 0);

            speed = 2.4f;
        }

        public Vec2 Move(Human LeMe, IEnumerable<Human> NearestNeighbours)
        {
            LeMe.Node = LeMe.Victim.Position;

            if ((LeMe.Node - LeMe.Position).Length() < 14f)
            {
                LeMe.Victim.Kill();
            }

            this.velocity = LeMe.Node - LeMe.Position;

            this.velocity.Mul(1.0f / this.velocity.Length());

            this.velocity.Mul(this.speed);

            foreach (var human in NearestNeighbours.Where(Human => Human.Position != LeMe.Position && !(Human.HumanType != HumanType.Agent && LeMe.HumanType == HumanType.Victim)))
            {
                this.distance = human.Position - LeMe.Position;

                var num = this.distance.Length();

                distance.Mul(1.0f / distance.Length());

                distance.Mul(1.7f);

                if (!(num <= 15.0f))
                {
                    continue;
                }

                num = 15.0f - num;

                num /= 15.0f;

                this.distance.Mul(num * -1f);

                this.distance.Mul(3.5f);

                this.velocity += this.distance;

                this.distance = human.Position - LeMe.Position;
            }

            this.velocity.Mul(1.0f / this.velocity.Length());

            this.velocity.Mul(this.speed);

            LeMe.Position = LeMe.Position + this.velocity;

            return LeMe.Position;
        }
    }
}
