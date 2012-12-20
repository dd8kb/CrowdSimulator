namespace CrowdSimulator.Human_Factories
{
    public class HumanFactory : IHumanFactory
    {
        public Human CreateHuman()
        {
            var human = new Human(HumanType.Normal, Crowd.GetRandomPosition(), Crowd.GetRandomPosition());
            
            return human;
        }
    }
}