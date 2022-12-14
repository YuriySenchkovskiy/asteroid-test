using UnityEngine;

namespace Utils
{
    public class SpawnUtils
    {
        public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, GameObject container)
        {
            return Object.Instantiate(prefab, position, rotation, container.transform);
        }
    }
}