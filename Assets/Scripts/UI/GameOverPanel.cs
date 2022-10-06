using TMPro;
using UnityEngine;
using Event = Observer.Event;

namespace UI
{
    public class GameOverPanel : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private TextMeshProUGUI _total;
        
        [Header("Event")]
        [SerializeField] private Event _buttonPressed;
        
        private const string Total = "Your score ";

        public void SetTotalScore(int number)
        {
            _total.text = Total + number;
        }

        public void Press()
        {
            _buttonPressed.Occured();
        }
    }
}