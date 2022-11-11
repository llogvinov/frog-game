public class DamageableEnemy : Enemy
{
    private uint _damageToGive;
    
    protected override void OnFinalTargetReached()
    {
        Release();
    }
}