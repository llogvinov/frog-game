using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class ObjectPool : MonoBehaviour
    {
        public event Action<PooledObject> GetObject;
        public event Action<PooledObject> ObjectReturned;

        [SerializeField] private uint _initPoolSize;
        [SerializeField] private PooledObject _objectToPool;
        
        private Stack<PooledObject> _pool;

        private bool IsPoolEmpty => _pool.Count == 0;
        
        private void Awake()
        {
            SetupPool();
        }

        private void SetupPool()
        {
            _pool = new Stack<PooledObject>();

            for (int i = 0; i < _initPoolSize; i++)
            {
                var instance = Instantiate(_objectToPool, transform);
                instance.Pool = this;
                instance.gameObject.SetActive(false);
                _pool.Push(instance);
            }
        }

        public PooledObject GetPooledObject()
        {
            if (IsPoolEmpty)
            {
                PooledObject newInstance = Instantiate(_objectToPool);
                newInstance.Pool = this;
                GetObject?.Invoke(newInstance);
                return newInstance;
            }

            PooledObject nextInstance = _pool.Pop();
            nextInstance.gameObject.SetActive(true);
            return nextInstance;
        }

        public void ReturnObjectToPool(PooledObject pooledObject)
        {
            _pool.Push(pooledObject);
            pooledObject.gameObject.SetActive(false);
            ObjectReturned?.Invoke(pooledObject);
        }

        public void Clear()
        {
            if (IsPoolEmpty) return;
            
            foreach (var pooledObject in _pool) 
                Destroy(pooledObject.gameObject);
            _pool.Clear();
        }
    }
}