using UnityEngine;

namespace Enemy.Damageable
{
    public class DamageableEnemy : Enemy
    {
        [SerializeField] private int _damageToGive;

        public int DamageToGive => _damageToGive;

        protected override void OnFinalTargetReached()
        {
            Release();
        }
    }
}