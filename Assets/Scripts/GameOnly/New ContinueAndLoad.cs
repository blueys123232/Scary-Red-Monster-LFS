using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NewContinueAndLoad : MonoBehaviour
{
    [Header("Scenes")]
    public string firstLevelSceneName;     // e.g., "Level1"
    public string levelIntroSceneName;     // e.g., "Tutorial" or intro scene

    [Header("UI")]
    public TMP_Text levelText;             // Shows the current global save label (optional)
    public GameObject newGameConfirmation; // Popup for main "New Game"
    public GameObject saveLoadPanel;       // The Save Loads panel
    public GameObject mainMenuPanel;       // Main menu panel

    [Header("Save Slot UI")]
    public TMP_Text[] slotLabels;          // 3 labels (Save Slot 1..3)
    public int maxSlots = 3;               // Default 3

    // -------- Global (backward-compat) keys --------
    const string KEY_LAST_INDEX = "LastLevelIndex";
    const string KEY_LAST_NAME = "LastLevelName";
    const string KEY_ACTIVE_SLOT = "ActiveSaveSlot"; // which slot the player last used (-1 if none)

    // -------- Per-slot keys helpers --------
    static string K_LevelName(int slot) => $"SaveSlot_{slot}_LevelName";
    static string K_LevelIndex(int slot) => $"SaveSlot_{slot}_LevelIndex";
    static string K_SavedAt(int slot) => $"SaveSlot_{slot}_SavedAtUtc";

    void Start()
    {
        if (newGameConfirmation) newGameConfirmation.SetActive(false);
        if (saveLoadPanel) saveLoadPanel.SetActive(false);

        UpdateLevelText();
        UpdateSaveSlots();
    }

    // ===================== MAIN "NEW GAME" (global) =====================
    public void OnNewGamePressed()
    {
        if (newGameConfirmation) newGameConfirmation.SetActive(true);
    }

    public void ConfirmNewGameYes()
    {
        // Wipe global keys only (slots stay untouched)
        PlayerPrefs.DeleteKey(KEY_LAST_INDEX);
        PlayerPrefs.DeleteKey(KEY_LAST_NAME);
        PlayerPrefs.DeleteKey(KEY_ACTIVE_SLOT);
        PlayerPrefs.Save();

        // Set global label to Tutorial/FirstLevel so "Level:" text is meaningful
        string label = !string.IsNullOrEmpty(levelIntroSceneName) ? "Tutorial" : firstLevelSceneName;
        PlayerPrefs.SetString(KEY_LAST_NAME, label);
        PlayerPrefs.Save();
        UpdateLevelText();

        if (newGameConfirmation) newGameConfirmation.SetActive(false);

        // Go to intro/first level
        if (!string.IsNullOrEmpty(levelIntroSceneName))
            SceneManager.LoadScene(levelIntroSceneName);
        else
            SceneManager.LoadScene(firstLevelSceneName);
    }

    public void ConfirmNewGameNo()
    {
        if (newGameConfirmation) newGameConfirmation.SetActive(false);
    }

    // ===================== CONTINUE / LOAD (global) =====================
    public void LoadGame()
    {
        // Prefer last active slot if present
        int activeSlot = PlayerPrefs.GetInt(KEY_ACTIVE_SLOT, -1);
        if (activeSlot >= 0 && SlotHasData(activeSlot))
        {
            LoadSlot(activeSlot);
            return;
        }

        // Fallback: legacy global
        int savedIndex = PlayerPrefs.GetInt(KEY_LAST_INDEX, -1);
        string savedName = PlayerPrefs.GetString(KEY_LAST_NAME, "");

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
            // Nothing saved → show the Save/Load panel so the player can pick a slot
            OpenSaveLoadPanel();
        }
    }

    // ===================== SAVE/LOAD PANEL =====================
    public void OpenSaveLoadPanel()
    {
        if (saveLoadPanel) saveLoadPanel.SetActive(true);
        if (mainMenuPanel) mainMenuPanel.SetActive(false);
        UpdateSaveSlots();
    }

    public void CloseSaveLoadPanel()
    {
        if (saveLoadPanel) saveLoadPanel.SetActive(false);
        if (mainMenuPanel) mainMenuPanel.SetActive(true);
    }

    // Call from each "New" button in the Save Loads panel with 0/1/2
    public void StartNewGameInSlot(int slotIndex)
    {
        if (!IsValidSlot(slotIndex)) return;

        // Record that this is the active slot
        PlayerPrefs.SetInt(KEY_ACTIVE_SLOT, slotIndex);

        // Initialize the slot to Tutorial (or first level)
        string startName = !string.IsNullOrEmpty(levelIntroSceneName) ? levelIntroSceneName : firstLevelSceneName;
        int startIndex = SceneUtility.GetBuildIndexByScenePath(startName); // may be -1 if path not used; name is enough

        PlayerPrefs.SetString(K_LevelName(slotIndex), startName);
        PlayerPrefs.SetInt(K_LevelIndex(slotIndex), startIndex);
        PlayerPrefs.SetString(K_SavedAt(slotIndex), System.DateTime.UtcNow.ToString("o"));

        // Mirror to global keys for legacy "Continue"
        PlayerPrefs.SetString(KEY_LAST_NAME, startName);
        PlayerPrefs.SetInt(KEY_LAST_INDEX, startIndex);
        PlayerPrefs.Save();

        UpdateLevelText();
        UpdateSaveSlots();

        // Load the chosen start scene
        SceneManager.LoadScene(startName);
    }

    // Call from each "Load" button in the Save Loads panel with 0/1/2 (if you have a dedicated Load button per slot)
    public void LoadSlot(int slotIndex)
    {
        if (!IsValidSlot(slotIndex)) return;

        string name = PlayerPrefs.GetString(K_LevelName(slotIndex), string.Empty);
        int index = PlayerPrefs.GetInt(K_LevelIndex(slotIndex), -1);

        if (string.IsNullOrEmpty(name) && index < 0)
        {
            // Empty slot → treat as new
            StartNewGameInSlot(slotIndex);
            return;
        }

        // Set active slot and mirror to global
        PlayerPrefs.SetInt(KEY_ACTIVE_SLOT, slotIndex);
        if (!string.IsNullOrEmpty(name)) PlayerPrefs.SetString(KEY_LAST_NAME, name);
        if (index >= 0) PlayerPrefs.SetInt(KEY_LAST_INDEX, index);
        PlayerPrefs.Save();

        UpdateLevelText();

        if (!string.IsNullOrEmpty(name))
            SceneManager.LoadScene(name);
        else
            SceneManager.LoadScene(index);
    }

    // Call from each "Delete" button with 0/1/2
    public void DeleteSaveSlot(int slotIndex)
    {
        if (!IsValidSlot(slotIndex)) return;

        PlayerPrefs.DeleteKey(K_LevelName(slotIndex));
        PlayerPrefs.DeleteKey(K_LevelIndex(slotIndex));
        PlayerPrefs.DeleteKey(K_SavedAt(slotIndex));

        // If this was the active slot, clear it
        if (PlayerPrefs.GetInt(KEY_ACTIVE_SLOT, -1) == slotIndex)
            PlayerPrefs.DeleteKey(KEY_ACTIVE_SLOT);

        PlayerPrefs.Save();
        UpdateSaveSlots();
        UpdateLevelText();
    }

    // ===================== SAVE PROGRESS (call from levels/checkpoints) =====================
    public void SaveLevelProgress(int levelIndex, string levelName = "")
    {
        // Save to active slot if available
        int activeSlot = PlayerPrefs.GetInt(KEY_ACTIVE_SLOT, -1);
        if (activeSlot >= 0)
        {
            if (!string.IsNullOrEmpty(levelName))
                PlayerPrefs.SetString(K_LevelName(activeSlot), levelName);

            PlayerPrefs.SetInt(K_LevelIndex(activeSlot), levelIndex);
            PlayerPrefs.SetString(K_SavedAt(activeSlot), System.DateTime.UtcNow.ToString("o"));
        }

        // Also mirror to global keys for "Continue"
        PlayerPrefs.SetInt(KEY_LAST_INDEX, levelIndex);
        if (!string.IsNullOrEmpty(levelName))
            PlayerPrefs.SetString(KEY_LAST_NAME, levelName);

        PlayerPrefs.Save();
        UpdateLevelText();
        UpdateSaveSlots();
    }

    // ===================== NEXT LEVEL =====================
    public void LoadNextLevel(int currentLevelIndex, string nextLevelName = "")
    {
        int nextIndex = currentLevelIndex + 1;
        SaveLevelProgress(nextIndex, nextLevelName);

        if (!string.IsNullOrEmpty(nextLevelName))
            SceneManager.LoadScene(nextLevelName);
        else
            SceneManager.LoadScene(nextIndex);
    }

    // ===================== UI REFRESH =====================
    void UpdateLevelText()
    {
        if (levelText == null) return;

        // Prefer active slot display if present
        int activeSlot = PlayerPrefs.GetInt(KEY_ACTIVE_SLOT, -1);
        if (activeSlot >= 0 && SlotHasData(activeSlot))
        {
            string n = PlayerPrefs.GetString(K_LevelName(activeSlot), "");
            levelText.text = string.IsNullOrEmpty(n) ? $"Level: Build #{PlayerPrefs.GetInt(K_LevelIndex(activeSlot), -1)}"
                                                      : $"Level: {n}";
            return;
        }

        // Fallback to legacy global label
        string savedName = PlayerPrefs.GetString(KEY_LAST_NAME, "");
        int savedIndex = PlayerPrefs.GetInt(KEY_LAST_INDEX, -1);

        if (!string.IsNullOrEmpty(savedName))
            levelText.text = $"Level: {savedName}";
        else if (savedIndex >= 0)
            levelText.text = $"Level: Build #{savedIndex}";
        else
            levelText.text = "Level: None";
    }

    void UpdateSaveSlots()
    {
        if (slotLabels == null) return;

        for (int i = 0; i < Mathf.Min(maxSlots, slotLabels.Length); i++)
        {
            string levelName = PlayerPrefs.GetString(K_LevelName(i), string.Empty);
            int levelIdx = PlayerPrefs.GetInt(K_LevelIndex(i), -1);
            string savedAt = PlayerPrefs.GetString(K_SavedAt(i), "");

            if (!string.IsNullOrEmpty(levelName) || levelIdx >= 0)
            {
                string main = !string.IsNullOrEmpty(levelName) ? levelName : $"Build #{levelIdx}";
                string when = string.IsNullOrEmpty(savedAt) ? "" : $"\nSaved: {System.DateTime.Parse(savedAt).ToLocalTime():g}";
                slotLabels[i].text = $"Save Slot {i + 1}: {main}{when}";
            }
            else
            {
                slotLabels[i].text = $"Save Slot {i + 1}: Empty";
            }
        }
    }

    // ===================== Helpers =====================
    bool IsValidSlot(int slot) => slot >= 0 && slot < maxSlots;

    bool SlotHasData(int slot)
    {
        return !string.IsNullOrEmpty(PlayerPrefs.GetString(K_LevelName(slot), "")) ||
               PlayerPrefs.GetInt(K_LevelIndex(slot), -1) >= 0;
    }
}