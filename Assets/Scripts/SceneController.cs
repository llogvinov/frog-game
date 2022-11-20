using UnityEngine;
using UnityEngine.SceneManagement;

namespace FrogGame
{
    public class SceneController : MonoBehaviour
    {
        public void ReloadScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void LoadMenuScene() => 
            SceneManager.LoadScene(0);
    }
}