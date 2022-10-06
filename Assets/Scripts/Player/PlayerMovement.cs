using System;
using Core;
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
        
        private Vector2 _direction;
        private MovementModel _movementModel;

        private void Awake()
        {
            _movementModel = new MovementModel(transform, _moveForwardSpeed, _screenSizeOffset, _rotationSpeed);
            _movementModel.Speed += SendSpeed;
        }

        private void FixedUpdate()
        {
            UseTeleport();
            MoveForward();
            Rotate();
            SendData();
        }

        private void OnDisable()
        {
            _movementModel.Speed -= SendSpeed;
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
            _movementModel.TrackTeleportLocation();
        }

        private void MoveForward()
        {
            _movementModel.MovePlayer(_direction);
        }
    
        private void Rotate()
        {
            _movementModel.RotatePlayer(_direction);
        }

        private void SendData()
        {
            _coordinates.Occured(transform.position);
            var currentZAngle = (float)Math.Round(transform.rotation.eulerAngles.z, 2);
            _angle.Occured(currentZAngle);
        }

        private void SendSpeed(float speed)
        {
            _speed.Occured(speed);
        }
    }
}