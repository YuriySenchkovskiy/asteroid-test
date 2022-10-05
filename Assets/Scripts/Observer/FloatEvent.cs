using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    [CreateAssetMenu(fileName = "New float event", menuName = "Float event", order = 51)]
    public class FloatEvent : ScriptableObject
    {
        private List<FloatEventListener> _boolEventListeners = new List<FloatEventListener>();

        public void Register(FloatEventListener listener)
        {
            _boolEventListeners.Add(listener);
        }
        
        public void UnRegister(FloatEventListener listener)
        {
            _boolEventListeners.Remove(listener);
        }

        public void Occured(float number)
        {
            foreach (var listener in _boolEventListeners)
            {
                listener.OnEventOccurs(number);
            }
        }
    }
}