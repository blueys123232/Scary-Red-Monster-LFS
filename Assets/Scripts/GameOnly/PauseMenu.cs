using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed"); // Debug log
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Resuming game"); // Debug log
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Debug.Log("Pausing game"); // Debug log
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu"); // Debug log
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); // Replace "MainMenu" with the actual name of your main menu scene
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game"); // Debug log
        Application.Quit();
    }
}
