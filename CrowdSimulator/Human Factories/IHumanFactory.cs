using System.Collections.Generic;

namespace CrowdSimulator.Human_Factories
{
    public interface IHumanFactory
    {
        void CreateHuman(List<Human> Humans);
    }
}
