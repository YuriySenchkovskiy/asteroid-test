using System;
using System.Threading.Tasks;
using ObjectPool;
using UnityEngine;

namespace Core
{
    public class ShootModel
    {
        private int _startLaserNumber;
        private int _currentLaserNumber;
        private int _laserStep;
        private bool _isLaserFilling;
        
        private float _waitTime;
        private float _laserPrepareTime;

        public Action<float> Timer;
        public Action<int> LaserCharges;

        public ShootModel(int laserNumber, float waitTime)
        {
            _startLaserNumber = _currentLaserNumber = laserNumber;
            _waitTime = waitTime;
            _laserStep = 1;
        }

        public bool GetLaserStatus()
        {
            if (_currentLaserNumber <= 0) 
                return false;
            
            ChangeLaserNumber(-_laserStep);
            return true;
        }

        public void MakeShoot(Transform transformParent, Transform transform, GameObject prefab, float _speed)
        {
            var instance = Pool.Instance.GetGameObject(prefab, transformParent.rotation, transform.position);
            
            Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();
                
            if (rigidbody2D != null)
            {
                rigidbody2D.velocity = transform.up * _speed;
            }
        }

        private async void FillLaser()
        {
            while (_currentLaserNumber < _startLaserNumber)
            {
                var currentTime = 0f;

                while (currentTime < _waitTime)
                {
                    currentTime += Time.deltaTime;
                    var seconds = _waitTime - currentTime;
                    _laserPrepareTime = seconds <= 0 ? 0 : seconds;
                    Timer?.Invoke(_laserPrepareTime);
                    await Task.Yield();
                }
                
                ChangeLaserNumber(_laserStep);
            }

            _isLaserFilling = false;
        }

        private void ChangeLaserNumber(int number)
        {
            _currentLaserNumber += number;

            if (_currentLaserNumber == 0 && !_isLaserFilling)
            {
                ChangeFillingStatus();
            }
            
            LaserCharges?.Invoke(_currentLaserNumber);
        }

        private void ChangeFillingStatus()
        {
            _isLaserFilling = true;
            FillLaser(); 
        }
    }
}