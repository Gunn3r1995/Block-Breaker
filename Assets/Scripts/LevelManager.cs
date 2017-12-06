using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour {

        public void LoadLevel(string sceneName) {
            Debug.Log("Level load requested for: " + sceneName);
			Brick.BreakableCount = 0;
            SceneManager.LoadScene(sceneName);
        }

        public void LoadNextLevel()
        {
			Brick.BreakableCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void BrickDestroyed()
        {
            if (Brick.BreakableCount <= 0) {
                LoadNextLevel();
            }
        }

        public void QuitRequest()
        {
            Debug.Log("I want to quit!");
            Application.Quit();
        }
    }
}
