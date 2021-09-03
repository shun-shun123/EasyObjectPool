using System;
using System.Collections.Generic;
using EasyObjectPool.Interface;
using UnityEngine;

namespace EasyObjectPool.Base
{
    /// <summary>
    /// ObjectPool abstract class
    /// </summary>
    /// <typeparam name="T">the type of pooling object</typeparam>
    public abstract class BaseObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour, IPoolElement<T>
    {
        [SerializeField]
        protected T poolingObject;

        [SerializeField]
        private Transform poolRootTransform;
        
        [SerializeField]
        protected int initCapacity;

        private List<T> _objectPool;

        private bool _hasInitialized;
        
        protected virtual void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            _objectPool = new List<T>(initCapacity);
            for (var i = 0; i < initCapacity; i++)
            {
                CreateAndAddNewObjectToPool();
            }

            _hasInitialized = true;
        }

        public virtual T Rent()
        {
            if (!_hasInitialized)
            {
                throw new InvalidOperationException("ObjectPool is not initialized");
            }

            if (_objectPool.Count == 0)
            {
                CreateAndAddNewObjectToPool();
            }

            var obj = _objectPool[0];
            _objectPool.RemoveAt(0);
            obj.gameObject.SetActive(true);
            obj.OnActive();
            return obj;
        }

        public virtual void Return(T rent)
        {
            if (!_hasInitialized)
            {
                throw new InvalidOperationException("ObjectPool is not initialized");
            }
            rent.OnDeActive();
            rent.gameObject.SetActive(false);
            _objectPool.Add(rent);
        }

        
        private void CreateAndAddNewObjectToPool()
        {
            var newObject = Instantiate(poolingObject, poolRootTransform);
            newObject.gameObject.SetActive(false);
            _objectPool.Add(newObject);
        }
    }
}