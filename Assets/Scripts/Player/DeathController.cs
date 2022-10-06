using UnityEngine;

namespace Player
{
    public class DeathController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject _player;
        
        [Header("Event")]
        [SerializeField] private Observer.Event _gameEnded;

        public void StopGame()
        {
            _gameEnded.Occured();
            _player.gameObject.SetActive(false);
        }
    }
}