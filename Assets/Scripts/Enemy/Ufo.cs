using Core;
using UnityEngine;

namespace Enemy
{
    public class Ufo : MonoBehaviour
    {
        [Header("General")]
        [SerializeField] private float _speed;
        
        [Header("Event")]
        [SerializeField] private Observer.Event _ufoCreated;
        
        private bool _isGoalPassed;
        private UfoModel _ufoModel;
        
        private void Start()
        {
            Notice();
        }

        private void FixedUpdate()
        {
            if (_isGoalPassed)
                MoveUfo();
        }

        private void OnDisable()
        {
            _isGoalPassed = false;
        }

        public void Notice()
        {
            _ufoCreated.Occured();
        }

        public void SetGoal(GameObject playerPosition)
        {
            _ufoModel = new UfoModel(transform.position, playerPosition, _speed);
            _isGoalPassed = true;
        }
        
        private void MoveUfo()
        {
            transform.position = _ufoModel.GetPosition();
        }
    }
}