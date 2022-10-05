using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerShooter _playerShooter;

        private void OnMove(InputValue value)
        {
            var vector = value.Get<Vector2>();
            _playerMovement.SetValue(vector);
        }

        private void OnBulletFire(InputValue value)
        {
            _playerShooter.ShootBullet();
        }

        private void OnLaserFire(InputValue value)
        {
            _playerShooter.ShootLaser();
        }
    }
}
