using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Array to hold references to the level buttons
    public Button[] levelButtons;

    // Reference to the lock sprite
    public Sprite lockImage;

    // Optional: Adjust the brightness using a color tint
    public Color lockImageColor = new Color(1f, 1f, 1f, 0.8f); // White color with some transparency to make it appear brighter

    // Names of the intro scenes corresponding to each level
    public string[] levelIntroScenes;

    // Names of the main level scenes corresponding to each level
    public string[] mainLevelScenes;

    void Start()
    {
        // Call the method to update the level buttons based on player progress
        UpdateLevelButtons();
    }

    // Method to update the level buttons' states
    void UpdateLevelButtons()
    {
        int levelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1); // Default to 1 unlocked level

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i < levelsUnlocked)
            {
                // Level is unlocked
                levelButtons[i].interactable = true;
            }
            else
            {
                // Level is locked
                levelButtons[i].interactable = false;
                levelButtons[i].image.sprite = lockImage; // Set the lock image
                levelButtons[i].image.color = lockImageColor; // Apply the color tint to make it brighter
            }
        }
    }

    // Method to load the level intro scene by name
    public void LoadLevelIntro(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Intro scene name is not set.");
        }
    }

    // Method to load the main level scene by name
    public void LoadMainLevel(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Main level scene name is not set.");
        }
    }

    // Method to reset the player's progress (e.g., when the "RESET" button is pressed)
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("LevelsUnlocked", 1); // Reset to only the first level unlocked
        UpdateLevelButtons(); // Update the buttons' states accordingly
    }
}
