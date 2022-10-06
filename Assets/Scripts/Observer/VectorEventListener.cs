using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class VectorEventListener : MonoBehaviour
    {
        [SerializeField] private VectorEvent Event;
        [SerializeField] private UnityEvent<Vector3> Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs(Vector3 vector)
        {
            Response?.Invoke(vector);
        }
    }
}