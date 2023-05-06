using UnityEngine;

namespace FrogGame.Enemy
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