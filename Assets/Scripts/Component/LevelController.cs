using Core;
using Observer;
using UnityEngine;

namespace Component
{
    public class LevelController : MonoBehaviour
    {
        [Header("Asteroid")]
        [SerializeField] private Spawn[] _asteroidSpawners;
        [SerializeField] private float _timeBetweenAsteroidSpawn;
        
        [Header("Ufo")]
        [SerializeField] private Spawn[] _ufoSpawners;
        [SerializeField] private float _timeBetweenUfoSpawn;
        
        [Header("Score")]
        [SerializeField] private IntEvent _counted;
        
        private SpawnModel _asteroid;
        private SpawnModel _ufo;

        private void Awake()
        {
            _asteroid = new SpawnModel(_asteroidSpawners.Length, _timeBetweenAsteroidSpawn);
            _asteroid.NumberSelected += AsteroidSpawn;
            _asteroid.StartSpawn();
            
            _ufo = new SpawnModel(_ufoSpawners.Length, _timeBetweenUfoSpawn);
            _ufo.NumberSelected += UfoSpawn;
            _ufo.StartSpawn();
        }

        private void OnDisable()
        {
            _asteroid.ChangeGameStatus();
            _asteroid.NumberSelected -= AsteroidSpawn;
            
            _ufo.ChangeGameStatus();
            _ufo.NumberSelected -= UfoSpawn;
        }

        public void SendGameResult()
        {
            _counted.Occured(Score.NumberOfDefeatedEnemies);
        }

        private void AsteroidSpawn(int number)
        {
            _asteroidSpawners[number].SpawnInstance();
        }
        
        private void UfoSpawn(int number)
        {
            _ufoSpawners[number].SpawnInstance();
        }
    }
}