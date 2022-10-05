using UnityEngine;
using Utils;

namespace Component
{
    public class EnterTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer = ~0;
        [SerializeField] private EnterEvent _action;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.IsInLayer(_layer)) 
                return;
            
            _action?.Invoke(other.gameObject);
        }
    }
}