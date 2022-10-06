using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class AsteroidModel
    {
        private Vector3 _position;
        private float _xOffset;
        private float _yOffset;

        public delegate void Direction(Vector3 direction);
        public event Direction DirectionSelected;
        
        public AsteroidModel(Vector3 position, float xOffset, float yOffset)
        {
            _position = position;
            _xOffset = xOffset;
            _yOffset = yOffset;
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
            Vector3 randomDirection = new Vector3(xRange, yRange);
            DirectionSelected?.Invoke(randomDirection.normalized);
        }
    }
}