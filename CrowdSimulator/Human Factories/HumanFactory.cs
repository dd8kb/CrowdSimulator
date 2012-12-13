using System.Collections.Generic;

namespace CrowdSimulator.Human_Factories
{
    public class HumanFactory : IHumanFactory
    {
        public void CreateHuman(List<Human> Humans)
        {
            var tmp = new Human(HumanType.Normal, Crowd.GetRandomPosition(), Crowd.GetRandomPosition());
            Humans.Add(tmp);
        }
    }
}