using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    public string resetStringName;
    
    public void Restart()
   
    {
        if (!string.IsNullOrEmpty(resetStringName))
        {
            SceneManager.LoadScene(resetStringName);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoadMainMenu()
    {

      

        SceneManager.LoadScene("Main Menu"); // Replace "MainMenu" with the actual name of your main menu scene
  
    }

    public void QuitGame()
    {


        Application.Quit(); // Quit the application
      
    }
   
}
