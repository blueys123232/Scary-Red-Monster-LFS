using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscenes : MonoBehaviour
{
    public string nextSceneName;
    public float introDuration = 10f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= introDuration)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
