using Core;
using ObjectPool;
using UnityEngine;

namespace Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private GameObject _laserPrefab;
        [SerializeField] private int _laserNumber;
        [SerializeField] private float _laserWaitTime;
        [SerializeField] private float _speed;

        private ShootModel _shootModel;

        private void Awake()
        {
            _shootModel = new ShootModel(_laserNumber, _laserWaitTime);
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
            var transformParent = GetComponentInParent<Transform>();
            var instance = Pool.Instance.GetGameObject(prefab, transformParent.rotation, transform.position);
            
            Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();
                
            if (rigidbody2D != null)
            {
                rigidbody2D.velocity = transform.up * _speed;
            }
        }
    }
}