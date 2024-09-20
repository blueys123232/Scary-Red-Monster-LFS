using UnityEngine;
using UnityEngine.SceneManagement;

public class NewAndLoad : MonoBehaviour
{
    // Public string to specify the first level of the game
    public string firstLevelSceneName;
    public string levelIntroSceneName;  // Optional: if you have an intro before the first level

    // Method to start a new game
    public void StartNewGame()
    {
        // Clear any existing save data
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        // Load the first level or the level intro scene
        if (!string.IsNullOrEmpty(levelIntroSceneName))
        {
            SceneManager.LoadScene(levelIntroSceneName);
        }
        else
        {
            SceneManager.LoadScene(firstLevelSceneName);
        }
    }

    // Method to load the last saved game
    public void LoadGame()
    {
        int savedLevelIndex = PlayerPrefs.GetInt("LastLevelIndex", -1);
        string savedLevelName = PlayerPrefs.GetString("LastLevelName", "");

        if (savedLevelIndex >= 0)
        {
            SceneManager.LoadScene(savedLevelIndex);
        }
        else if (!string.IsNullOrEmpty(savedLevelName))
        {
            SceneManager.LoadScene(savedLevelName);
        }
        else
        {
            // If no save exists, start a new game or show a message
            Debug.Log("No saved game found, starting a new game.");
            StartNewGame();
        }
    }

    // Method to save the current level progress
    public void SaveLevelProgress(int levelIndex, string levelName = "")
    {
        PlayerPrefs.SetInt("LastLevelIndex", levelIndex);
        PlayerPrefs.SetString("LastLevelName", levelName);
        PlayerPrefs.Save();
    }

    // Method to load the next level when the current one is completed
    public void LoadNextLevel(int currentLevelIndex)
    {
        int nextLevelIndex = currentLevelIndex + 1;

        // Save the progress
        SaveLevelProgress(nextLevelIndex);

        // Load the next level
        SceneManager.LoadScene(nextLevelIndex);
    }
}
