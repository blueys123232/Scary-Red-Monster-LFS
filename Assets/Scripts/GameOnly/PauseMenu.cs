using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] GameObject OtherUI;

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
        pauseMenuUI.SetActive(false);
        OtherUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        OtherUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;

        Debug.Log(SceneManager.GetActiveScene().name);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        sScript.SaveLevelProgress(SceneManager.GetActiveScene().name, SceneManager.GetActiveScene().buildIndex);


        SceneManager.LoadScene("Main Menu");

    }
    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NewandLoad()
    {
        SceneManager.LoadScene("New And Load");
    }
}