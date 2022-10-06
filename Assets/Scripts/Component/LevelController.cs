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
            _spawnModel.NumberSelected += Spawn;
            _spawnModel.StartSpawn();
        }

        private void OnDisable()
        {
            _spawnModel.ChangeGameStatus();
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