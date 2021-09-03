using UnityEngine;

namespace EasyObjectPool.Interface
{
    /// <summary>
    /// Interface of objectPool
    /// </summary>
    public interface IObjectPool<T> where T : Object
    {
        /// <summary>
        /// Rent from ObjectPool
        /// </summary>
        /// <returns>instance of T</returns>
        T Rent();

        /// <summary>
        /// Return instance to objectPool
        /// </summary>
        /// <param name="rent">instance of T</param>
        void Return(T rent);
    }
}