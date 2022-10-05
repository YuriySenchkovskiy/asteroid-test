using Observer;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveForwardSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _screenSizeOffset;
        [SerializeField] private GameObjectEvent _gameObjectEvent;

        private float _cameraViewSize;
        private Vector2 _direction;
        private Vector3 _framePosition;
        private Vector3 _frameVelocity;

        private void Awake()
        {
            _cameraViewSize = Camera.main.orthographicSize;
        }

        private void FixedUpdate()
        {
            UseTeleport();
            MoveForward();
            Rotate();
        }
    
        public void SetValue(Vector2 direction)
        {
            _direction = direction;
        }

        public void PassGoal()
        {
            _gameObjectEvent.Occured(gameObject);
        }
        
        private void UseTeleport()
        {
            if (Mathf.Abs(transform.position.x) > _cameraViewSize)
            {
                transform.position = new Vector3(_screenSizeOffset * _cameraViewSize * 
                                                 Mathf.Sign(transform.position.x), transform.position.y);
            }
            if (Mathf.Abs(transform.position.y) > _cameraViewSize)
            {
                transform.position = new Vector3(transform.position.x, _screenSizeOffset * _cameraViewSize * 
                                                                       Mathf.Sign(transform.position.y));
            }
        }

        private void MoveForward()
        {
            _framePosition = transform.position;
            float _rawMovementTowards = Mathf.Clamp(_direction.y, 0, 1);
            Vector3 trueAcceleration = _moveForwardSpeed * _rawMovementTowards * transform.up;
            transform.position += _frameVelocity * Time.deltaTime + trueAcceleration * Mathf.Pow(Time.deltaTime, 2) * 0.5f;
            _frameVelocity = (transform.position - _framePosition) / Time.deltaTime;
        }
    
        private void Rotate()
        {
            var rotationVector = Vector3.forward * -_direction.x * Time.deltaTime * _rotationSpeed;
            transform.Rotate(rotationVector);
        }
    }
}