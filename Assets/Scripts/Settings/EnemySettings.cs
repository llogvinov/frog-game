using UnityEngine;

namespace Settings
{
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _movePointsNumber;

        public void Init(string enemyName, float moveSpeed, int movePointsNumber)
        {
            _name = enemyName;
            _moveSpeed = moveSpeed;
            _movePointsNumber = movePointsNumber;
        }
    }
}