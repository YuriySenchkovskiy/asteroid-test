using UnityEngine;

namespace Core
{
    public class UfoModel
    {
        private float _speed;
        private float _offset;
        private GameObject _goal;
        private Vector3 _position;
        private Vector3 _direction;

        public UfoModel(Vector3 position, GameObject playerPosition, float speed)
        {
            _position = position;
            _goal = playerPosition;
            _speed = speed;
            _offset = 0.2f;
        }

        public Vector3 GetPosition()
        {
            var directionToPlayer = _goal.transform.position - _position;
            _direction = directionToPlayer.normalized;
            
            if (Vector3.Distance(_goal.transform.position, _position) < _offset)
            {
                _position += Vector3.zero;
            }
            else
            {
                _position += _direction * Time.fixedDeltaTime * _speed;
            }
            
            return _position;
        }
    }
}