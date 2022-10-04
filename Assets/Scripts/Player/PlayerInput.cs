using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        private void OnMove(InputValue value)
        {
            var vector = value.Get<Vector2>();
            _playerMovement.SetValue(vector);
        }
    }
}
