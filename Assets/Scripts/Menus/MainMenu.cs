using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This method is called when the Play button is pressed
    public void PlayGame()
    {
        // Load the Chapter Select scene by its name
        SceneManager.LoadScene("Chapter Select");
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
