using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    [CreateAssetMenu(fileName = "New vector event", menuName = "Vector3 Event", order = 51)]
    public class VectorEvent : ScriptableObject
    {
        private List<VectorEventListener> _eventListeners = new List<VectorEventListener>();

        public void Register(VectorEventListener listener)
        {
            _eventListeners.Add(listener);
        }
        
        public void UnRegister(VectorEventListener listener)
        {
            _eventListeners.Remove(listener);
        }

        public void Occured(Vector2 vector)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventOccurs(vector);
            }
        }
    }
}