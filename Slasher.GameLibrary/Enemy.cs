using Slasher.GameLibrary.Enums;
using ToolKit;


namespace Slasher.GameLibrary
{
    public class Enemy : Entity
    {
        public EnemyType EnemyType;
        public GoalType GoalType { get; set; }
        private int _mobility = 2;

        //TODO implement weighted probability for mobility of 3 and above.
        public int Mobility()
        {
            int rolledMobility = _mobility;
            if (_mobility > 1)
            {
                rolledMobility = Random.Shared.Next(_mobility);
            }
            return rolledMobility;
        }

        //TODO implement logic for picking enemyType when spawning.
        public Enemy()
        {
            EntityType = EntityType.Enemy;
            SpawnLocation = new int[2] { 0, 0 };
            GoalType = GoalType.ReachPlayer;
        }

        public int[] GetMovementDirection(int[] goalLocation)
        {
            int[] rawValues = Location.Subtract(goalLocation);
            int[] direction = new int[rawValues.Length];

            for (int x = 0; x < rawValues.Length; x++)
            {
                direction[x] = -Math.Sign(rawValues[x]);
            }
            return direction;
        }

        
        public int[] AdvanceTick(int[] playerLocation)
        {
            int[] movementVector = new int[] { 0, 0 };

            switch (GoalType)
            {
                //TODO roll Mobility for each part of the vector separately.
                case GoalType.ReachPlayer:
                    movementVector = GetMovementDirection(playerLocation).Multiply(Mobility());
                    break;

                case GoalType.Empty:
                    movementVector = new int[]{ 0, 0 };
                    break;
            }
            return movementVector;
        }
    }
}
