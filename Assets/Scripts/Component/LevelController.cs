using Core;
using UI;
using UnityEngine;
using Event = Observer.Event;

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
        [SerializeField] private Event _clicked;
        [SerializeField] private Event _startedBefore;

        private SpawnModel _asteroid;
        private SpawnModel _ufo;
        private float _asteroidTime;
        private float _ufoTime;
        private bool _isGameStart;

        private void Awake()
        {
            _informationPanel.gameObject.SetActive(true);
            _asteroid = new SpawnModel(_asteroidSpawners.Length);
            _asteroid.NumberSelected += AsteroidSpawn;
            _asteroid.StartSpawn();

            _ufo = new SpawnModel(_ufoSpawners.Length);
            _ufo.NumberSelected += UfoSpawn;
            _ufo.StartSpawn();
        }

        private void Update()
        {
            Spawn();
        }

        private void OnDisable()
        {
            _asteroid.NumberSelected -= AsteroidSpawn;
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
            _clicked.Occured();
            ScoreModel.ClearResult();
            Core.ReloadLevel.Reload();
        }

        private void AsteroidSpawn(int number)
        {
            _asteroidSpawners[number].SpawnInstance();
        }
        
        private void UfoSpawn(int number)
        {
            _ufoSpawners[number].SpawnInstance();
        }

        private void Spawn()
        {
            if (_timeBetweenAsteroidSpawn > _asteroidTime)
            {
                _asteroidTime += Time.deltaTime;
            }
            else
            {
                _asteroid.StartSpawn();
                _asteroidTime = 0f;
            }
            
            if (_timeBetweenUfoSpawn > _ufoTime)
            {
                _ufoTime += Time.deltaTime;
            }
            else
            {
                _ufo.StartSpawn();
                _ufoTime = 0f;
            }
        }
    }
}