using Player;
using UnityEngine;

namespace Component
{
    public class GameController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject _levelController;
        [SerializeField] private PlayerMovement _playerMovement;

        public void StartGame()
        {
            _levelController.SetActive(true);
            _playerMovement.enabled = true;
        }
    }
}