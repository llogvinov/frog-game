using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyPoolOld : MonoBehaviour
    {
        [SerializeField] private uint _poolSize;
        [SerializeField] private Enemy _objectToPool;

        private Stack<Enemy> _stack;

        private void Awake()
        {
            SetupPool();
        }

        private void SetupPool()
        {
            _stack = new Stack<Enemy>();

            for (int i = 0; i < _poolSize; i++)
            {
                Enemy instance = Instantiate(_objectToPool, transform);
                instance.gameObject.name += $" {i}";
                instance.gameObject.SetActive(false);
                //instance.Pool = this;
                _stack.Push(instance);
            }
        }

        public Enemy GetPooledObject()
        {
            if (_stack.Count == 0)
            {
                Enemy newInstance = Instantiate(_objectToPool);
                //newInstance.Pool = this;
                return newInstance;
            }

            Enemy nextInstance = _stack.Pop();
            nextInstance.gameObject.SetActive(true);
            return nextInstance;
        }

        public void ReturnToPool(Enemy enemy)
        {
            _stack.Push(enemy);
            enemy.gameObject.SetActive(false);
        }

        public void Clear()
        {
            foreach (var enemy in _stack) Destroy(enemy);
            _stack.Clear();
        }
    }
}