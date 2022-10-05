using ObjectPool;
using UnityEngine;

namespace Component
{
    public class Realiser : MonoBehaviour
    {
        public void TryRelease(GameObject gameObject)
        {
            if (!gameObject.TryGetComponent(out PoolItem poolItem))
            {
                return;
            }
            
            poolItem.Release();
        }
    }
}