using UnityEngine;
using Event = Observer.Event;

namespace Enemy
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float _fromX;
        [SerializeField] private float _toX;
        [SerializeField] private float _fromY;
        [SerializeField] private float _toY;

        [SerializeField] private Event _asteroidCreated;
        [SerializeField] private float _speed;
        
        private Vector3 _direction;
        
        private void Start()
        { 
            _asteroidCreated.Occured();
            _direction = GetDirection();
        }

        private void FixedUpdate()
        {
            MoveAsteroid();
        }
        
        private Vector3 GetDirection()
        {
            Vector3 randomDirection = new Vector3(Random.Range(_fromX, _toX),
                Random.Range(_fromY, _toY));

            return randomDirection.normalized;
        }
        
        private void MoveAsteroid()
        {
            transform.position += _direction * Time.fixedDeltaTime * _speed;
        }
    }
}