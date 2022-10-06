using Core;
using Observer;
using UI;
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
        
        [Header("UI")]
        [SerializeField] private InformationPanel _informationPanel;
        [SerializeField] private GameOverPanel _gameOverPanel;

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

        public void ShowGameOverPanel()
        {
            _informationPanel.gameObject.SetActive(false);
            _gameOverPanel.gameObject.SetActive(true);
            _gameOverPanel.SetTotalScore(ScoreModel.NumberOfDefeatedEnemies);
        }

        public void ReloadLevel()
        {
            var reloadLevel = new ReloadLevel();
            ScoreModel.ClearResult();
            reloadLevel.Reload();
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