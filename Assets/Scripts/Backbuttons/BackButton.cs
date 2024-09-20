using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // This method is called when the Back button is pressed
    public void GoBackToMainMenu()
    {
        // Load the Main Menu scene by its name
        SceneManager.LoadScene("Main Menu");
    }
}
