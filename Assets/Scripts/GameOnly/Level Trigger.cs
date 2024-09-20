using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public GameObject optionsPanel; // Reference to the UI panel that contains the options
    public int levelIndex; // Index of the level to load
    public string levelName; // Name of the level to load (optional)
    public bool useLevelName = false; // Toggle between using level index or name

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Open the options panel instead of loading the level directly
            OpenOptionsPanel();
        }
    }

    void OpenOptionsPanel()
    {
        // Activate the options panel
        optionsPanel.SetActive(true);

        // Optionally, pause the game if you want to stop gameplay while the panel is open
        // Time.timeScale = 0f; // This will freeze the game
    }

    // Method to load the level
    public void LoadLevel()
    {
        // Close the options panel
        optionsPanel.SetActive(false);

        // Optionally, resume the game if you paused it earlier
        // Time.timeScale = 1f;

        if (useLevelName)
        {
            // Load level by name
            SceneManager.LoadScene(levelName);
        }
        else
        {
            // Load level by index
            SceneManager.LoadScene(levelIndex);
        }
    }

    // Method to go back to Chapter 1
    public void GoToChapter1()
    {
        // Close the options panel
        optionsPanel.SetActive(false);

        // Load the scene for Chapter 1 (you need to know the index or name)
        SceneManager.LoadScene("Chapter1"); // Replace with actual scene name or index

        // Optionally, resume the game if you paused it earlier
        // Time.timeScale = 1f;
    }

    // Method to return to the main menu
    public void GoToMainMenu()
    {
        // Close the options panel
        optionsPanel.SetActive(false);

        // Load the main menu scene (you need to know the index or name)
        SceneManager.LoadScene("MainMenu"); // Replace with actual scene name or index

        // Optionally, resume the game if you paused it earlier
        // Time.timeScale = 1f;
    }

    // Optional: A method to just close the panel and resume the game
    public void ClosePanel()
    {
        // Deactivate the options panel
        optionsPanel.SetActive(false);

        // Optionally, resume the game if you paused it earlier
        // Time.timeScale = 1f;
    }
}
