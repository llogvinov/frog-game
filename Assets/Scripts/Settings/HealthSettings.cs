using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "HealthSettings", menuName = "ObjectSettings/HealthSettings")]
    public class HealthSettings : ScriptableObject
    {
        [SerializeField] private int _minHealth;
        [SerializeField] private int _maxHealth;

        public int MinHealth => _minHealth;

        public int MaxHealth => _maxHealth;
    }
}