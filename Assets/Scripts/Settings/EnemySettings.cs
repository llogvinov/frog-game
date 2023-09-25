using UnityEngine;

namespace Settings
{
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private string _enemyName;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private uint _movePointsNumber;

        public string EnemyName => _enemyName;
        public float MoveSpeed => _moveSpeed;
        public uint MovePointsNumber => _movePointsNumber;

        public void Init(string enemyName, float moveSpeed, uint movePointsNumber)
        {
            _enemyName = enemyName;
            _moveSpeed = moveSpeed;
            _movePointsNumber = movePointsNumber;
        }
    }
}