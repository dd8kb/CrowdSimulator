using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdSimulator.Behaviour
{
    public interface IMovementBehaviour
    {
        Vec2 Move(Human LeMe, IEnumerable<Human> NearestNeighbours);
    }
}
