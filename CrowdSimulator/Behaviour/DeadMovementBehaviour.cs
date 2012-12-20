using System.Collections.Generic;

namespace CrowdSimulator.Behaviour
{
    public class DeadMovementBehaviour : IMovementBehaviour
    {
        public Vec2 Move(Human LeMe, IEnumerable<Human> NearestNeighbours)
        {
            return LeMe.Position;
        }
    }
}
