using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenAnyScene : MonoBehaviour
{
    public string openScene;

    // Start is called before the first frame update
    public void OpeningScene()
    {

        SceneManager.LoadScene(openScene);

    }

}








