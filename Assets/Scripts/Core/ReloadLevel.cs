using UnityEngine.SceneManagement;

namespace Core
{
    public class ReloadLevel
    {
        public void ReloadInGameMenu()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}