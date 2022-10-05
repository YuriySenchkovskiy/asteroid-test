using Core;
using Observer;
using UnityEngine;

namespace Component
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Spawn[] _spawners;
        [SerializeField] private float _timeBetweenSpawn;
        [SerializeField] private IntEvent _counted;

        private SpawnModel _spawnModel;

        private void Awake()
        {
            _spawnModel = new SpawnModel(_spawners.Length, _timeBetweenSpawn);
        }

        private void OnEnable()
        {
            _spawnModel.NumberSelected += Spawn;
        }

        private void OnDisable()
        {
            _spawnModel.NumberSelected -= Spawn;
        }

        public void SendGameResult()
        {
            _counted.Occured(Score.NumberOfDefeatedEnemies);
        }

        private void Spawn(int number)
        {
            _spawners[number].SpawnInstance();
        }
    }
}