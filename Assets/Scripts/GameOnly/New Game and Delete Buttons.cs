using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameandDeleteButtons : MonoBehaviour
{
    [Header("Scenes")]
    public string firstLevelSceneName;     // e.g., "Level1"
    public string levelIntroSceneName;     // e.g., "Tutorial" or intro scene

    // -------- Global (backward-compat) keys --------
    const string KEY_LAST_INDEX = "LastLevelIndex";
    const string KEY_LAST_NAME = "LastLevelName";
    [Header("UI")]
    private TextMeshProUGUI SavedLevelName;

    [Header("Save File and Delete Buttons")]
    [SerializeField] private GameObject[] SaveFileButtons;
    [SerializeField] private GameObject[] DeleteButtons;
    private void Start()
    {
        SavedLevelName = FindAnyObjectByType<TextMeshProUGUI>();

        if (SaveFileButtons != null)
        {
            foreach (var btn in SaveFileButtons)
                if (btn != null) btn.SetActive(true);
        }

        if (DeleteButtons != null)
        {
            foreach (var btn in DeleteButtons)
                if (btn != null) btn.SetActive(true);
        }
    }


    public void StartNewGame()
    {

        PlayerPrefs.DeleteKey(KEY_LAST_INDEX);
        PlayerPrefs.DeleteKey(KEY_LAST_NAME);
        PlayerPrefs.Save();

        if (!string.IsNullOrEmpty(levelIntroSceneName))
        {
            PlayerPrefs.SetString(KEY_LAST_NAME, levelIntroSceneName);
            SavedLevelName.text = levelIntroSceneName;
            PlayerPrefs.Save();
            SceneManager.LoadScene(levelIntroSceneName);
        }
        else
        {
            PlayerPrefs.SetString(KEY_LAST_NAME, firstLevelSceneName);
            PlayerPrefs.Save();
            SceneManager.LoadScene(firstLevelSceneName);
        }
    }
    public void ContinueGame()
    {
        string saveName = PlayerPrefs.GetString(KEY_LAST_NAME, "");
        int savedIndex = PlayerPrefs.GetInt(KEY_LAST_INDEX, -1);

        if (!string.IsNullOrEmpty(saveName))
        {
            SceneManager.LoadScene(saveName);
        }
        else if (savedIndex >= 0)
        {
            SceneManager.LoadScene(savedIndex);
        }
        else
        {
            StartNewGame();
        }
    }
    public void LoadGame()
    {
        ContinueGame();
    }
    public void SaveLevelProgress(int levelIndex, string levelName = "")
    {
        PlayerPrefs.SetInt(KEY_LAST_INDEX, levelIndex);

        if (!string.IsNullOrEmpty(levelName))
            PlayerPrefs.SetString(KEY_LAST_NAME, levelName);
        PlayerPrefs.Save();
    }
    public void LoadNextLevel(int currentLevelIndex, string nextLevelName = "")
    {
        int nextIndex = currentLevelIndex + 1;
        SaveLevelProgress(nextIndex, nextLevelName);
        if (!string.IsNullOrEmpty(nextLevelName))
            SceneManager.LoadScene(nextLevelName);
        else
            SceneManager.LoadScene(nextIndex);
    }
    public void DeleteSaveFile()
    {
        PlayerPrefs.DeleteKey(KEY_LAST_INDEX);
        PlayerPrefs.DeleteKey(KEY_LAST_NAME);
        PlayerPrefs.Save();

        Debug.Log("Save File Deleted");

        if (SavedLevelName != null)
            SavedLevelName.text = "None";
    }

}






