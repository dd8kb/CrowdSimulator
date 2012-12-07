using System.Collections.Generic;
using System.Linq;
using CrowdSimulator.Behaviour;

namespace CrowdSimulator
{
    public enum HumanType
    { 
        Normal,
        Agent,
        Victim,
        Dead
    }

    public class Human
    {

        public Human(HumanType HumanType, Vec2 Position, Vec2 Node)
        {
            this.HumanType = HumanType;
            this.Position = Position;
            this.Node = Node;
            this.MovementBehaviour = new UsualMovementBehaviour();
            this.DecisionBehaviour = new UsualDecisionBehaviour();
        }

        public Vec2 Position { get; set; }

        public Vec2 Node { get; set; }

        public Vec2 FieldIndex { get; set; }

        public Vec2 Incident { get; set; }

        public Human Victim { get; set; }

        public HumanType HumanType { get; set; }

        public IMovementBehaviour MovementBehaviour { get; set; }

        public IDecisionBehaviour DecisionBehaviour { get; set; }

        public void Update(List<Human> NearestNeighbour)
        {
            var humanInSight = NearestNeighbour.Where(OnPredicate).ToList();

            this.DecisionBehaviour.CheckSurrounding(this, humanInSight);

            this.Position = this.MovementBehaviour.Move(this, NearestNeighbour);
        }

        private bool OnPredicate(Human Human)
        {
            return Vec2.Dot((this.Node - this.Position), (Human.Position - this.Position)) >= 0.02f && (Human.Position != this.Position);
        }

        public Vec2 RequestNewRandomPosition()
        {
            return Crowd.GetRandomPosition();
        }

        public void Kill()
        {
            this.HumanType = HumanType.Dead;
            this.MovementBehaviour=new DeadMovementBehaviour();
        }
    }
}
