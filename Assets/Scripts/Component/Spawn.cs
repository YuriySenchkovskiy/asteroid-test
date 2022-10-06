using ObjectPool;
using Unity.Mathematics;
using UnityEngine;

namespace Component
{
    public class Spawn : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _prefab;

        [ContextMenu("Spawn")]
        public GameObject SpawnInstance()
        {
            var instance = Pool.Instance.GetGameObject(_prefab, quaternion.identity, transform.position);
            return instance;
        }
    }
}