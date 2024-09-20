using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonChapterSelect : MonoBehaviour
{
    // This method is called when the Back button is pressed
    public void ChapterSelect()
    {
        // Load the Main Menu scene by its name
        SceneManager.LoadScene("Chapter Select");
    }
}
