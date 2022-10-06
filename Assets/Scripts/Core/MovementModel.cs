using System;
using UnityEngine;

namespace Core
{
    public class MovementModel
    {
        private float _cameraViewSize;
        private float _screenSizeOffset;
        private Vector3 _framePosition;
        private Transform _transform;

        private float _moveForwardSpeed;
        private float _halfAcceleration;
        private float _rotationSpeed;
        private Vector3 _frameVelocity;
        
        public Action<float> Speed;
        
        public MovementModel(Transform transform, float moveForwardSpeed, float screenSizeOffset, float rotationSpeed)
        {
            _cameraViewSize = Camera.main.orthographicSize;
            _screenSizeOffset = screenSizeOffset;
            _transform = transform;
            _moveForwardSpeed = moveForwardSpeed;
            
            _rotationSpeed = rotationSpeed;
            _halfAcceleration = 0.5f;
        }
        
        public void TrackTeleportLocation()
        {
            if (Mathf.Abs(_transform.position.x) > _cameraViewSize)
            {
                _transform.position = new Vector3(_screenSizeOffset * _cameraViewSize * 
                                                 Mathf.Sign(_transform.position.x), _transform.position.y);
            }
            if (Mathf.Abs(_transform.position.y) > _cameraViewSize)
            {
                _transform.position = new Vector3(_transform.position.x, _screenSizeOffset * _cameraViewSize * 
                                                                       Mathf.Sign(_transform.position.y));
            }
        }

        public void MovePlayer(Vector3 direction)
        {
            _framePosition = _transform.position;
            float _rawMovementTowards = Mathf.Clamp(direction.y, 0, 1);
            Vector3 rawAcceleration = _moveForwardSpeed * _rawMovementTowards * _transform.up;
            _transform.position += _frameVelocity * Time.deltaTime + rawAcceleration * Mathf.Pow(Time.deltaTime, 2) * _halfAcceleration;
            _frameVelocity = (_transform.position - _framePosition) / Time.deltaTime;
            
            var currentSpeed = (float)Math.Round(_frameVelocity.magnitude, 2);
            Speed?.Invoke(currentSpeed);
        }

        public void RotatePlayer(Vector3 direction)
        {
            var rotationVector = Vector3.forward * -direction.x * Time.deltaTime * _rotationSpeed;
            _transform.Rotate(rotationVector);
        }
    }
}