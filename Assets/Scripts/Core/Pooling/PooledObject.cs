﻿using UnityEngine;

namespace Core.Pooling
{
    public class PooledObject : MonoBehaviour
    {
        private ObjectPool _pool;

        public ObjectPool Pool
        {
            get => _pool;
            set => _pool = value;
        }

        public void Release() => 
            _pool.ReturnObjectToPool(this);
    }
}