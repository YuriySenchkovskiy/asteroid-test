using Core;
using UnityEngine;

namespace Enemy
{
    public class DestroyController : MonoBehaviour
    {
        [SerializeField] private Observer.Event _damage;
        
        public void AddScore()
        {
            _damage.Occured();
            ScoreModel.AddScore();
        }
    }
}