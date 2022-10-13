using System;
using Core;
using Observer;
using UnityEngine;
using Event = Observer.Event;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [Header("General")] 
        [SerializeField] private Transform _parent;
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private int _laserNumber;
        [SerializeField] private float _laserWaitTime;
        [SerializeField] private float _speed;

        [Header("Event")] 
        [SerializeField] private FloatEvent _timer;
        [SerializeField] private IntEvent _charge;
        [SerializeField] private Event _shoot;

        private ShootModel _shootModel;

        private void Awake()
        {
            _shootModel = new ShootModel(_laserNumber, _laserWaitTime);
            _shootModel.Timer += SendTimer;
            _shootModel.LaserCharges += SendCharges;
        }

        private void Start()
        {
            SendCharges(_laserNumber);
            SendTimer(0f);
        }

        private void OnDisable()
        {
            _shootModel.Timer -= SendTimer;
            _shootModel.LaserCharges -= SendCharges;
        }

        public void ShootBullet()
        {
            Shoot(_bulletPrefab);
        }

        public void ShootLaser()
        {
            if (_shootModel.GetLaserStatus())
                Shoot(_laserPrefab);
        }

        private void Shoot(GameObject prefab)
        {
            _shoot.Occured();   
            _shootModel.CalculateShoot(_parent, transform, prefab, _speed);
        }

        private void SendTimer(float time)
        {
            var timer = (float)Math.Round(time, 2);
            _timer.Occured(timer);
        }
        
        private void SendCharges(int charge)
        {
            _charge.Occured(charge);
        }
    }
}