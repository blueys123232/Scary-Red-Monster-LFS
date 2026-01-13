using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    SaveScript sScript;

    private void Awake()
    {
        sScript = FindAnyObjectByType<SaveScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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

    public void Pause()
    {
        Debug.Log("Pausing game"); // Debug log
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;

        sScript.SaveLevelProgress(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().buildIndex.ToString(),
            SceneManager.GetActiveScene().buildIndex, SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Main Menu");

    }
    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game"); // Debug log
        Application.Quit();
    }
}