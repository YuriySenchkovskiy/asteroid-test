using Core;
using UnityEngine;

namespace Enemy
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _xOffset;
        [SerializeField] private float _yOffset;
        [SerializeField] private float _speed;
        
        private Vector3 _direction;
        private bool _isDirectionReady;
        private AsteroidModel _asteroidModel;

        private void OnEnable()
        {
            _asteroidModel = new AsteroidModel(transform.position, _xOffset, _yOffset);
            _asteroidModel.DirectionSelected += SetDirection;
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
            _asteroidModel.DirectionSelected -= SetDirection;
        }

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
            _isDirectionReady = true;
        }
        
        private void MoveAsteroid()
        {
            transform.position += _direction * Time.fixedDeltaTime * _speed;
        }
    }
}