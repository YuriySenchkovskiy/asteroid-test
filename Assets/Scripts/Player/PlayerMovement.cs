using System;
using Observer;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _moveForwardSpeed;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _screenSizeOffset;
        
        [Header("Event")]
        [SerializeField] private GameObjectEvent _playerPosition;
        [SerializeField] private VectorEvent _coordinates;
        [SerializeField] private FloatEvent _angle;
        [SerializeField] private FloatEvent _speed;

        private float _halfAcceleration;
        private float _cameraViewSize;
        private Vector2 _direction;
        private Vector3 _framePosition;
        private Vector3 _frameVelocity;

        private void Awake()
        {
            _halfAcceleration = 0.5f;
            _cameraViewSize = Camera.main.orthographicSize;
        }

        private void FixedUpdate()
        {
            UseTeleport();
            MoveForward();
            Rotate();
            SendData();
        }
    
        public void SetValue(Vector2 direction)
        {
            _direction = direction;
        }

        public void PassGoal()
        {
            _playerPosition.Occured(gameObject);
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
            Vector3 rawAcceleration = _moveForwardSpeed * _rawMovementTowards * transform.up;
            transform.position += _frameVelocity * Time.deltaTime + rawAcceleration * Mathf.Pow(Time.deltaTime, 2) * _halfAcceleration;
            
            _frameVelocity = (transform.position - _framePosition) / Time.deltaTime;
            var currentSpeed = (float)Math.Round(_frameVelocity.magnitude, 2);
            _speed.Occured(currentSpeed);
        }
    
        private void Rotate()
        {
            var rotationVector = Vector3.forward * -_direction.x * Time.deltaTime * _rotationSpeed;
            transform.Rotate(rotationVector);
        }

        private void SendData()
        {
            _coordinates.Occured(transform.position);
            var currentZAngle = (float)Math.Round(transform.rotation.eulerAngles.z, 2);
            _angle.Occured(currentZAngle);
        }
    }
}