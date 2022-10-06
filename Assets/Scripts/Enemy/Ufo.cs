using UnityEngine;

namespace Enemy
{
    public class Ufo : MonoBehaviour
    {
        [SerializeField] private float _fromX;
        [SerializeField] private float _toX;
        [SerializeField] private float _fromY;
        [SerializeField] private float _toY;

        [SerializeField] private Observer.Event _ufoCreated;
        [SerializeField] private float _speed;
        
        private Vector3 _direction;
        private bool _isDirectionReady;
        
        private void OnEnable()
        { 
            _ufoCreated.Occured();
        }

        private void FixedUpdate()
        {
            if (_isDirectionReady)
            {
                MoveAsteroid();
            }
        }

        private void OnDisable()
        {
            _isDirectionReady = false;
        }

        public void SetDirection(GameObject playerPosition)
        {
            Vector3 randomDirection = new Vector3(Random.Range(_fromX, _toX),
                Random.Range(_fromY, _toY));

            var directionToPlayer = playerPosition.transform.position - transform.position;
            _direction = (randomDirection + directionToPlayer).normalized;
            _isDirectionReady = true;
        }
        
        private void MoveAsteroid()
        {
            transform.position += _direction * Time.fixedDeltaTime * _speed;
        }
    }
}