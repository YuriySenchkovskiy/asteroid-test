using UnityEngine;

namespace Component
{
    public class SpawnList : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private Spawn[] _spawners;

        public void SpawnAll()
        {
            foreach (var spawn in _spawners)
            {
                spawn.SpawnInstance();
            }
        }
    }
}