using System;
using FrogGame;

public class EatableEnemyMover : EnemyMover
{
    private Target _target;

    private void OnEnable()
    {
        FinalTargetReached += OnFinalTargetReached;
    }

    private void OnDisable()
    {
        FinalTargetReached -= OnFinalTargetReached;
    }

    private void OnFinalTargetReached()
    {
        _target.OccupyTarget();
    }

    protected override void AddFinalPosition()
    {
        var frogGirl = FindObjectOfType<FrogGirl>();
        _target = frogGirl.Target;
        var lastPosition = _target.Position;
        MovePositions.Enqueue(lastPosition);
    }
}