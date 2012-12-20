using System.Collections.Generic;

namespace CrowdSimulator.Behaviour
{
    public class AgentDecisionBehaviour : IDecisionBehaviour
    {
        public void CheckSurrounding(Human LeMe, List<Human> HumansInSight)
        {
            if (LeMe.Victim.HumanType == HumanType.Dead)
            {
                LeMe.DecisionBehaviour = new UsualDecisionBehaviour();
                LeMe.MovementBehaviour = new UsualMovementBehaviour();
                LeMe.HumanType = HumanType.Normal;
            }

            foreach(Human h in HumansInSight)
            {
                if (h.HumanType != HumanType.Dead)
                {
                    continue;
                }

                if (!((LeMe.Position - h.Position).Length() < 70.0f))
                {
                    continue;
                }

                LeMe.Node = h.Position;

                LeMe.MovementBehaviour = new EvadeMovementBehaviour();
            }
        }
    }
}
