using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{

    public GameObject gameoverPanel;
    public GameObject pausemenuPanel;
    
    public void Restart()
   
    {
        if (pausemenuPanel != null)
        {
            pausemenuPanel.SetActive(false);
        }

        if (gameoverPanel != null)
        {
            pausemenuPanel.SetActive(false);
        }





        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
       
        
        if (pausemenuPanel != null)
        {
            pausemenuPanel.SetActive(false);
        }

        if (gameoverPanel != null)
        {
            pausemenuPanel.SetActive(false);
        }



        SceneManager.LoadScene("Main Menu"); // Replace "MainMenu" with the actual name of your main menu scene


    }

    public void QuitGame()
    {


        Application.Quit(); // Quit the application
      
    }
   
}
