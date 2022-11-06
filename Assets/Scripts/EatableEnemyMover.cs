public class EatableEnemyMover : EnemyMover
{
    protected override void AddFinalPosition()
    {
        var lastPosition = GameManager.Instance.FrogGirl.transform.position;
        MovePositions.Enqueue(lastPosition);
    }
}