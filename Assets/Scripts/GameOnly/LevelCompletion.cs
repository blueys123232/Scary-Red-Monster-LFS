using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{

    public string sceneName;
    public GameObject completionPanel;

    public void CompleteLevel()

    {
        if (completionPanel != null)
        {

            completionPanel.SetActive(true);
        }


    }

    void UnlockLevel()
    {
        PlayerPrefs.SetInt(sceneName + "Unlocked", 1);
        PlayerPrefs.Save();
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void RestartLevel()
    {
       SceneManager.LoadScene(sceneName);
    }
}
