using Core;
using UnityEngine;

namespace Enemy
{
    public class DestroyController : MonoBehaviour
    {
        public void AddScore()
        {
            ScoreModel.AddScore();
        }
    }
}