using UnityEngine;

public class SaveScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveLevelProgress(string KeyName, string KeyIndex, int levelIndex, string levelName = "")
    {
        PlayerPrefs.SetInt(KeyIndex, levelIndex);

        if (!string.IsNullOrEmpty(levelName))
            PlayerPrefs.SetString(KeyName, levelName);
        PlayerPrefs.Save();

        PlayerPrefs.GetInt(KeyIndex, levelIndex);
        PlayerPrefs.GetString(KeyName, levelName);
    }
}
