using UnityEngine;
using UnityEngine.SceneManagement;

namespace Component
{
    public class ReloadLevel : MonoBehaviour
    {
        public void ReloadInGameMenu()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}