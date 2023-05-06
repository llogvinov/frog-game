using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneController : MonoBehaviour
    {
        private const int MenuSceneBuildIndex = 0;
        private const int GameSceneBuildIndex = 1;
        
        public void ReloadScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void LoadMenuScene() => 
            SceneManager.LoadScene(MenuSceneBuildIndex);

        public void LoadGameScene() =>
            SceneManager.LoadScene(GameSceneBuildIndex);
    }
}