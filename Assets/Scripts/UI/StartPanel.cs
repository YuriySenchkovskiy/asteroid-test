using UnityEngine;

namespace UI
{
    public class StartPanel : MonoBehaviour
    {
        [Header("Event")]
        [SerializeField] private Observer.Event _startPressed;
        
        public void Press()
        {
            _startPressed.Occured();
        }
    }
}