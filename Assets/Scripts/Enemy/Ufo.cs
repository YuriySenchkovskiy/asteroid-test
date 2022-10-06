using UnityEngine;

namespace Enemy
{
    public class Ufo : MonoBehaviour
    {
        [SerializeField] private Observer.Event _ufoCreated;
        [SerializeField] private float _speed;
        
        private GameObject _goal;
        private Vector3 _direction;
        private bool _isGoalPassed;
        
        private void OnEnable()
        { 
            _ufoCreated.Occured();
        }

        private void FixedUpdate()
        {
            if (_isGoalPassed)
            {
                MoveUfo();
            }
        }

        private void OnDisable()
        {
            _isGoalPassed = false;
        }

        public void SetGoal(GameObject playerPosition)
        {
            _goal = playerPosition;
            _isGoalPassed = true;
        }
        
        private void MoveUfo()
        {
            if (_goal != null)
            {
                var directionToPlayer = _goal.transform.position - transform.position;
                _direction = directionToPlayer.normalized;
                transform.position += _direction * Time.fixedDeltaTime * _speed;
            }
        }
    }
}