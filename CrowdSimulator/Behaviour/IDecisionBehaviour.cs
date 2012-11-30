using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdSimulator.Behaviour
{
    public interface IDecisionBehaviour
    {
        void CheckSurrounding(Human LeMe, List<Human> HumansInSight);
    }
}
