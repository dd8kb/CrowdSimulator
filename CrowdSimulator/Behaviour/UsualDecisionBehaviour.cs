using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrowdSimulator.Behaviour
{
    public class UsualDecisionBehaviour : IDecisionBehaviour
    {
        public void CheckSurrounding(Human LeMe, List<Human> HumansInSight)
        {
            foreach(Human h in HumansInSight)
            {
                if (h.HumanType == HumanType.Dead)
                {
                    if ((LeMe.Position - h.Position).Length() < 70.0f)
                    {
                        LeMe.Node = h.Position;
                        // TODO: change MovementBehaviour
                        LeMe.MovementBehaviour = new EvadeMovementBehaviour();
                    }
                }
            }
        }
    }
}
