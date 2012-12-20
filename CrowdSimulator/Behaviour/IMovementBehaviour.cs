using System.Collections.Generic;

namespace CrowdSimulator.Behaviour
{
    public interface IMovementBehaviour
    {
        Vec2 Move(Human LeMe, IEnumerable<Human> NearestNeighbours);
    }
}
