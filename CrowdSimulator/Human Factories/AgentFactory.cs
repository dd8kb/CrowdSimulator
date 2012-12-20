using System;
using System.Collections.Generic;
using CrowdSimulator.Behaviour;

namespace CrowdSimulator.Human_Factories
{
    public class AgentFactory : HumanFactory
    {
        readonly Random rnd = new Random();

        public Human CreateHuman(List<Human> Humans)
        {
            var human = this.CreateHuman();
            int listIndex;

            do
            {
                listIndex = rnd.Next(0, Humans.Count - 1);
            } while (!(Humans[listIndex].HumanType != HumanType.Agent && Humans[listIndex].HumanType != HumanType.Victim));

            human.HumanType = HumanType.Agent;
            human.MovementBehaviour = new AgentMovementBehaviour();
            human.DecisionBehaviour = new AgentDecisionBehaviour();
            human.Victim = Humans[listIndex];
            Humans[listIndex].HumanType = HumanType.Victim;

            return human;
        }
    }
}
