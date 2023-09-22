using UnityEngine;

namespace Enemy
{
    public class Eatable : MonoBehaviour
    {
        [SerializeField] private int _eatablePoints;

        public int EatablePoints => _eatablePoints;
    }
}