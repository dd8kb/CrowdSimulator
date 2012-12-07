using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdSimulator.Behaviour
{
    public class DeadMovementBehaviour : IMovementBehaviour
    {
        public Vec2 Move(Human LeMe, IEnumerable<Human> NearestNeighbours)
        {
            return LeMe.Position;
        }

        private Vec2 GetNewTarget(Human LeMe)
        {
            return LeMe.RequestNewRandomPosition();
        }
    }
}
