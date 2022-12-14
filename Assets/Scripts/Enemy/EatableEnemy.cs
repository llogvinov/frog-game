using UnityEngine;

public class EatableEnemy : Enemy
{
    [SerializeField] private int _pointsToAdd;

    public int PointsToAdd => _pointsToAdd;
    
    protected override void OnFinalTargetReached()
    {
        enabled = false;
    }
}