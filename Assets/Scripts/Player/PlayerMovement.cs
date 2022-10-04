using UnityEngine;

namespace Controller
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveForwardSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _screenSizeOffset;

        private float _cameraViewHalfSize;
        private Vector2 _direction;
        private Vector3 _framePosition;
        private Vector3 _frameVelocity;

        private void Awake()
        {
            _cameraViewHalfSize = Camera.main.orthographicSize;
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
        
        private void UseTeleport()
        {
            
            if (Mathf.Abs(transform.position.x) > _cameraViewHalfSize)
            {
                transform.position = new Vector3(_screenSizeOffset * _cameraViewHalfSize * 
                                                 Mathf.Sign(transform.position.x), transform.position.y);
            }
            if (Mathf.Abs(transform.position.y) > _cameraViewHalfSize)
            {
                transform.position = new Vector3(transform.position.x, _screenSizeOffset * _cameraViewHalfSize * 
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