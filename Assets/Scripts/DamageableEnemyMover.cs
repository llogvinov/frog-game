using UnityEngine;

public class DamageableEnemyMover : EnemyMover
{
    private const float OffScreenOffset = 1f;
    
    protected override void AddFinalPosition()
    {
        var lastPosition = EnemySpawner.RandomPositionOffTheScreen();
        MovePositions.Enqueue(lastPosition);
    }
    
}