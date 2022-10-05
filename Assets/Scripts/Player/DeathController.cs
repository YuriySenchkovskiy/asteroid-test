using UnityEngine;

namespace Player
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] private GameObject _player;
        [SerializeField] private Observer.Event _gameEnded;

        public void StopGame()
        {
            _gameEnded.Occured();
            _player.gameObject.SetActive(false);
        }
    }
}