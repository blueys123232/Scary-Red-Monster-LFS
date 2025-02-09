using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscne : MonoBehaviour
{
    // name of the load screen
    public string nextSceneName;

    // Update is called by a frame 
     void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        { 
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
