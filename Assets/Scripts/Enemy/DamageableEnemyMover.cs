namespace FrogGame.Enemy
{
    public class DamageableEnemyMover : EnemyMover
    {
        protected override void AddFinalPosition()
        {
            var lastPosition = EnemySpawner.RandomPositionOffTheScreen();
            MovePositions.Enqueue(lastPosition);
        }
    
    }
}