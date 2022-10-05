using Player;
using UnityEngine;

namespace Component
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private LevelController _gameController;
        [SerializeField] private PlayerMovement _playerMovement;

        public void StartGame()
        {
            _gameController.enabled = true;
            _playerMovement.enabled = true;
        }
    }
}