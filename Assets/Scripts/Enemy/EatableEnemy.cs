public class EatableEnemy : Enemy
{
    private uint pointsToAdd;

    protected override void OnFinalTargetReached()
    {
        enabled = false;
    }
}