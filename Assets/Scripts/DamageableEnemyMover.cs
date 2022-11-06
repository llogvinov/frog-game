using UnityEngine;

public class DamageableEnemyMover : EnemyMover
{
    private const float OffScreenOffset = 1f;
    
    protected override void AddFinalPosition()
    {
        var lastPosition = RandomPositionOffTheScreen();
        MovePositions.Enqueue(lastPosition);
    }

    private Vector2 RandomPositionOffTheScreen()
    {
        return new Vector2(
            Random.Range(-GameManager.Instance.HalfWidth - OffScreenOffset, GameManager.Instance.HalfWidth + OffScreenOffset),
            Random.Range(0, GameManager.Instance.HalfHeight + OffScreenOffset));
    }
}