using UnityEngine;

namespace Utils
{
    public class SpawnUtils
    {
        public static GameObject Spawn(GameObject prefab, Vector3 position, GameObject container)
        {
            return Object.Instantiate(prefab, position, Quaternion.identity, container.transform);
        }
    }
}