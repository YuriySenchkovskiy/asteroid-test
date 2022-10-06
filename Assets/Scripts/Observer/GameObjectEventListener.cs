using UnityEngine;
using UnityEngine.Events;

namespace Observer
{
    public class GameObjectEventListener : MonoBehaviour
    {
        [SerializeField] private GameObjectEvent Event;
        [SerializeField] private UnityEvent<GameObject> Response;

        private void OnEnable()
        {
            Event.Register(this);
        }

        private void OnDisable()
        {
            Event.UnRegister(this);
        }
        
        public void OnEventOccurs(GameObject gameObject)
        {
            Response?.Invoke(gameObject);
        }
    }
}