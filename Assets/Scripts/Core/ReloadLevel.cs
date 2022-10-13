using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class ReloadLevel : MonoBehaviour
    {
        public static void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(scene.name);
        }
    }
}