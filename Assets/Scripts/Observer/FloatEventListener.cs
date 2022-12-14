using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class FloatEventListener : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private FloatEvent Event;
        [SerializeField] private UnityEvent<float> Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs(float number)
        {
            Response?.Invoke(number);
        }
    }
}