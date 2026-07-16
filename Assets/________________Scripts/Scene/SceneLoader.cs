using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // This line runs ONLY inside the Unity Editor to stop Play Mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // This line runs ONLY in the final built application
            Application.Quit();
#endif
    }

}
