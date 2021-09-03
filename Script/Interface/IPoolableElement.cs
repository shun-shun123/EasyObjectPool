using UnityEngine;

namespace EasyObjectPool.Interface
{
    /// <summary>
    /// interface of object which is able to pool
    /// </summary>
    public interface IPoolElement<out T> where T : MonoBehaviour
    {
        void OnActive();

        void OnDeActive();
    }
}