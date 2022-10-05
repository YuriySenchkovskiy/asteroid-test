using UnityEngine;

namespace Component
{
    public class SpawnList : MonoBehaviour
    {
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