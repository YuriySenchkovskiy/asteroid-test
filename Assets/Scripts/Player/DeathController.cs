using UnityEngine;
using Event = Observer.Event;

namespace Player
{
    public class DeathController : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private GameObject _player;
        
        [Header("Event")]
        [SerializeField] private Event _gameEnded;
        [SerializeField] private Event _damaged;

        public void StopGame()
        {
            _damaged.Occured();
            _gameEnded.Occured();
            _player.gameObject.SetActive(false);
        }
    }
}