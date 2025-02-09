using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {

            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning("The Scene is not Setted Up");
        }
    }

    // This method is called when the Exit button is pressed
    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
        // If you are running the game in the Unity editor, this line will stop the play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
