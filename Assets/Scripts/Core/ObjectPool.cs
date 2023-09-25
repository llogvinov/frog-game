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
        [SerializeField] private uint _maxPoolSize;
        [Space]
        [SerializeField] private PooledObject _objectToPool;
        
        private Stack<PooledObject> _pool;

        private List<PooledObject> _allInstances;

        private bool IsPoolEmpty => _pool.Count == 0;
        
        private void Awake()
        {
            if (_initPoolSize > _maxPoolSize)
            {
                Debug.LogWarning($"{gameObject.name} has {nameof(_initPoolSize)} greater then {nameof(_maxPoolSize)}. " +
                                 $"Resetting {nameof(_maxPoolSize)} to be equal with {nameof(_initPoolSize)}");
                _maxPoolSize = _initPoolSize;
            }
            SetupPool();
        }

        private void SetupPool()
        {
            _pool = new Stack<PooledObject>();
            _allInstances = new List<PooledObject>();

            for (int i = 0; i < _initPoolSize; i++)
            {
                var instance = Instantiate(_objectToPool, transform);
                instance.Pool = this;
                instance.gameObject.SetActive(false);
                _pool.Push(instance);
                _allInstances.Add(instance);
            }
        }

        public PooledObject TryGetPooledObject()
        {
            if (IsPoolEmpty)
            {
                if (_allInstances.Count >= _maxPoolSize)
                {
                    Debug.LogError($"The {gameObject.name} pool reached its max capacity. Unable to get object");
                    return null;
                }
                
                PooledObject newInstance = Instantiate(_objectToPool, transform);
                newInstance.Pool = this;
                GetObject?.Invoke(newInstance);
                return newInstance;
            }

            PooledObject nextInstance = _pool.Pop();
            nextInstance.gameObject.SetActive(true);
            GetObject?.Invoke(nextInstance);
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