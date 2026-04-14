using UnityEngine;

public class SaveScript : MonoBehaviour
{
    [HideInInspector] public string SavedLevelName;
    [HideInInspector] public int SavedLevelIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveLevelProgress(string KeyName, int levelIndex)
    {
        PlayerPrefs.SetInt(KeyName, levelIndex);

        if (!string.IsNullOrEmpty(KeyName))
            PlayerPrefs.SetString(KeyName, KeyName);

        SavedLevelName = KeyName;
        SavedLevelIndex = levelIndex;

        //PlayerPrefs.GetInt(SavedLevelName, SavedLevelIndex);
        //PlayerPrefs.GetString(SavedLevelName, SavedLevelName);

        PlayerPrefs.Save();
    }


}

