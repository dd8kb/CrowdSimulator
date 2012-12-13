
using System;
using System.Collections.Generic;
using CrowdSimulator.Behaviour;

namespace CrowdSimulator.Human_Factories
{
    public class AgentFactory : HumanFactory
    {
        Random rnd = new Random();

        public new void CreateHuman(List<Human> Humans)
        {
            base.CreateHuman(Humans);

            var index = rnd.Next(0, Humans.Count - 1);
            var aIndex = Humans.Count - 1;

            Humans[aIndex].HumanType = HumanType.Agent;
            Humans[aIndex].MovementBehaviour = new AgentMovementBehaviour();
            Humans[aIndex].Victim = Humans[index];
            Humans[index].HumanType = HumanType.Victim;
        }
    }
}
