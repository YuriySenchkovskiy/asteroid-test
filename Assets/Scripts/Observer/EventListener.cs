using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class EventListener : MonoBehaviour
    {
        [SerializeField] private Event Event;
        [SerializeField] private UnityEvent Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs()
        {
            Response?.Invoke();
        }
    }
}