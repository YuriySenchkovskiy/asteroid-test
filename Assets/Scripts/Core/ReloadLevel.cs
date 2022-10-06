using UnityEngine.SceneManagement;

namespace Core
{
    public class ReloadLevel
    {
        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}