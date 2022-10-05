using System.Threading.Tasks;
using UnityEngine;

namespace Core
{
    public class ShootModel
    {
        private int _startLaserNumber;
        private int _currentLaserNumber;
        private int _laserStep;
        private float _waitTime;
        private bool _isLaserFilling;

        public float LaserPrepareTime { get; private set; }

        public ShootModel(int laserNumber, float waitTime)
        {
            _startLaserNumber = _currentLaserNumber = laserNumber;
            _waitTime = waitTime;
            _laserStep = 1;
        }

        public bool GetLaserStatus()
        {
            if (_currentLaserNumber > 0)
            {
                ChangeLaserNumber(-_laserStep);
                return true;
            }
            
            if (!_isLaserFilling)
            {
                _isLaserFilling = true;
                FillLaser();
            }
            
            return false;
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
                    LaserPrepareTime = seconds <= 0 ? 0 : seconds;
                    await Task.Yield();
                }
                
                ChangeLaserNumber(_laserStep);
            }

            _isLaserFilling = false;
        }

        private void ChangeLaserNumber(int number)
        {
            _currentLaserNumber += number;
        }
    }
}