namespace Enemy
{
    public class DamageableEnemyMover : EnemyMover
    {
        protected override void AddFinalPosition() => 
            AddFinalPositionOffScreen();
    }
}