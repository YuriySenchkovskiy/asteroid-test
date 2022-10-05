using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    [CreateAssetMenu(fileName = "New Game Object Event", menuName = "Game Object Event", order = 51)]
    public class GameObjectEvent : ScriptableObject
    {
        private List<GameObjectEventListener> _eventListeners = new List<GameObjectEventListener>();

        public void Register(GameObjectEventListener listener)
        {
            _eventListeners.Add(listener);
        }
        
        public void UnRegister(GameObjectEventListener listener)
        {
            _eventListeners.Remove(listener);
        }

        public void Occured(GameObject gameObject)
        {
            foreach (var listener in _eventListeners)
            {
                listener.OnEventOccurs(gameObject);
            }
        }
    }
}