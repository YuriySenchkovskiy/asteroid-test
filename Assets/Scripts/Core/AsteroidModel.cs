using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class AsteroidModel
    {
        private Vector3 _position;
        private Vector3 _direction;
        private float _xOffset;
        private float _yOffset;
        private float _speed;

         public delegate void Direction();
         public event Direction DirectionSelected;
        
        public AsteroidModel(Vector3 position, float xOffset, float yOffset, float speed)
        {
            _position = position;
            _xOffset = xOffset;
            _yOffset = yOffset;
            _speed = speed;
        }

        public void CalculateDirection()
        {
            if (_position.x > 0)
            {
                _xOffset *= -1;
            }

            if (_position.y > 0)
            {
                _yOffset *= -1;
            }
            
            float xRange = Random.Range(0, _xOffset);
            float yRange = Random.Range(0, _yOffset);
            _direction = new Vector3(xRange, yRange);
            DirectionSelected?.Invoke();
        }

        public Vector3 GetAsteroidPosition()
        {
            return _position += _direction * Time.deltaTime * _speed;
        }
    }
}