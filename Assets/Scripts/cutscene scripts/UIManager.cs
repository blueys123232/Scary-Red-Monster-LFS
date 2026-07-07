using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image RespawnScreen;
    private bool fadeOut, fadeIn;
    //fade speed
    public float fadeTime;

    void Update()
    {
        if (fadeOut)
        {
            //have to create a new color as you cant just set the Alpha/a to be 1
            RespawnScreen.color = new Color(0, 0, 0, Mathf.MoveTowards(RespawnScreen.color.a, 1f, fadeTime * Time.deltaTime));
        }
        //fade back in to game when respawning
        if (fadeIn)
        {
            RespawnScreen.color = new Color(0, 0, 0, Mathf.MoveTowards(RespawnScreen.color.a, 0f, fadeTime * Time.deltaTime));
        }
    }

    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false;
    }

    public void FadeIn()
    {
        fadeOut = false;
        fadeIn = true;
    }


}
