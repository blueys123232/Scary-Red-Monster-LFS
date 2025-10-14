using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewContinueAndLoad : MonoBehaviour
{
    [Header("Scenes")]
    public string firstLevelSceneName;  // First Level 
    public string levelIntroSceneName;  // Optional: if you have an intro before the first level

    [Header("UI")]
    public TMP_Text levelText; // Level: Text
    public GameObject saveLoadPanel;
    public GameObject mainMenuPanel;
    public GameObject newGameConformation;

    const string KEY_LAST_INDEX = "LastLevelIndex";
    const string KEY_LAST_NAME = "LastLevelName";

    [Header("Save Slot UI")]
    public TMP_Text[] slotLabels;
    public int maxSlots = 3;

    public class SaveData
    {
        public string levelName;
        public int levelIndex;
        public string createdAtUtc;
        public string updatedAtUtc;
    }

    void Start()
    {
        if (newGameConformation != null)
            newGameConformation.SetActive(false);
        UpdateLevelText();
        UpdateSaveSlots();
    }

    public void OnNewGamePressed()
    {
        if (newGameConformation != null)
            newGameConformation.SetActive(true);
    }

    public void ConfirmNewGameYes()
    {
        PlayerPrefs.DeleteKey(KEY_LAST_INDEX);
        PlayerPrefs.DeleteKey(KEY_LAST_NAME);

        // Default to tutorial or first level
        if (!string.IsNullOrEmpty(levelIntroSceneName))
        {
            PlayerPrefs.SetString(KEY_LAST_NAME, "Tutorial");
            PlayerPrefs.Save();
            UpdateLevelText();
            SceneManager.LoadScene(levelIntroSceneName);
        }
        else
        {
            PlayerPrefs.SetString(KEY_LAST_NAME, firstLevelSceneName);
            PlayerPrefs.Save();
            UpdateLevelText();
            SceneManager.LoadScene(firstLevelSceneName);
        }

        if (newGameConformation != null)
            newGameConformation.SetActive(false);
    }


    public void ConfirmNewGameNO()
    {
        if (newGameConformation != null)
            newGameConformation.SetActive(false);
    }


    // Method to load the last saved game
    public void LoadGame()
    {
        int savedIndex = PlayerPrefs.GetInt("LastLevelIndex", -1);
        string savedName = PlayerPrefs.GetString("LastLevelName", "");

        if (!string.IsNullOrEmpty(savedName))
        {
            SceneManager.LoadScene(savedName);
        }
        else if (savedIndex >= 0)
        {
            SceneManager.LoadScene(savedIndex);
        }
        else
        {
            // If no save exists, start a new game or show a message
            Debug.Log("No saved game found, starting a new game.");
            OpenSaveLoadPanel();
        }
    }
    public void OpenSaveLoadPanel()
    {
        if (saveLoadPanel != null)
            saveLoadPanel.SetActive(true);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        UpdateSaveSlots();
    }

    public void CloseSaveLoadPanel()
    {
        if (saveLoadPanel != null)
            saveLoadPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
    }
    void UpdateSaveSlots()
    {
        for (int i = 0; i < maxSlots; i++)
        {
            string key = $"SaveSlot_{i}_Level";
            string levelName = PlayerPrefs.GetString(key, "Empty");

            if (slotLabels != null && i < slotLabels.Length)
                slotLabels[i].text = $"Slot {i + 1}: {levelName}";
        }
    }
    public void StartNewGameInSlot(int slotIndex)
{
    string key = $"SaveSlot_{slotIndex}_Level";
    PlayerPrefs.SetString(key, "Tutorial");
    PlayerPrefs.Save();

    Debug.Log($"New game started in slot {slotIndex + 1}");
    UpdateSaveSlots();
    SceneManager.LoadScene(levelIntroSceneName);
}

public void DeleteSaveSlot(int slotIndex)
{
    string key = $"SaveSlot_{slotIndex}_Level";
    if (PlayerPrefs.HasKey(key))
    {
        PlayerPrefs.DeleteKey(key);
        PlayerPrefs.Save();
        Debug.Log($"Deleted save slot {slotIndex + 1}");
    }

    UpdateSaveSlots();
}
    public void SaveLevelProgress(int levelIndex, string levelName = "")
    {
        PlayerPrefs.SetInt(KEY_LAST_NAME, levelIndex);
        if (!string.IsNullOrEmpty(levelName))
            PlayerPrefs.SetString(KEY_LAST_NAME, levelName);

        PlayerPrefs.Save();
        UpdateLevelText();
    }


public void LoadNextLevel(int currentLevelIndex, string nextLevelName = "")
{
    int nextLevelIndex = currentLevelIndex + 1;
        SaveLevelProgress(nextLevelIndex, nextLevelName);

    if (!string.IsNullOrEmpty(nextLevelName))
        SceneManager.LoadScene(nextLevelName);
    else
        SceneManager.LoadScene(nextLevelIndex);
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
    public void UpdateLevelText()
    {
        if (levelText == null) return;

        string savedName = PlayerPrefs.GetString(KEY_LAST_NAME, "");
        int savedIndex = PlayerPrefs.GetInt(KEY_LAST_NAME, -1);
        if (!string.IsNullOrEmpty(savedName))
            levelText.text = $"Level: {savedName}";
        else if (savedIndex >= 0)
            levelText.text = $"Level: Build #{savedIndex}";
        else
            levelText.text = "Level: None";
    }


}