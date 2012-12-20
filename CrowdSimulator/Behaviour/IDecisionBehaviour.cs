using System.Collections.Generic;

namespace CrowdSimulator.Behaviour
{
    public interface IDecisionBehaviour
    {
        void CheckSurrounding(Human LeMe, List<Human> HumansInSight);
    }
}
