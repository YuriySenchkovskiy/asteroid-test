using UI;
using UnityEngine;

namespace Component
{
    public class GameMenu : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Observer.Event _clicked;

        public void StartGame()
        {
            _clicked.Occured();
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel("Game");
        }
    }
}