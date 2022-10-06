using Core;
using UnityEngine;

namespace Enemy
{
    public class Asteroid : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _xOffset;
        [SerializeField] private float _yOffset;
        [SerializeField] private float _speed;
        
        private bool _isDirectionReady;
        private AsteroidModel _asteroidModel;

        private void OnEnable()
        {
            _asteroidModel = new AsteroidModel(transform.position, _xOffset, _yOffset, _speed);
            _asteroidModel.DirectionSelected += SetDirectionStatus;
            _asteroidModel.CalculateDirection();
        }

        private void FixedUpdate()
        {
            if (_isDirectionReady)
                MoveAsteroid();
        }

        private void OnDisable()
        {
            _isDirectionReady = false;
            _asteroidModel.DirectionSelected -= SetDirectionStatus;
        }

        private void SetDirectionStatus()
        {
            _isDirectionReady = true;
        }
        
        private void MoveAsteroid()
        {
            transform.position = _asteroidModel.GetAsteroidPosition();
        }
    }
}