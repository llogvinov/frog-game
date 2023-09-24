namespace Enemy.Damageable
{
    public class DamageableEnemyMover : EnemyMover
    {
        protected override void AddFinalPosition() => 
            AddFinalPositionOffScreen();
    }
}