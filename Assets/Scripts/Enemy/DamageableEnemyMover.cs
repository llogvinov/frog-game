namespace FrogGame.Enemy
{
    public class DamageableEnemyMover : EnemyMover
    {
        protected override void AddFinalPosition()
        {
            var lastPosition = Utils.RandomPositionOffTheScreen();
            MovePositions.Enqueue(lastPosition);
        }
    
    }
}