using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public float startingDelay = 1f;
    public AudioSource audioSource;
    public AudioClip typingSound;
   

    private int index;
  

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }


    void Update()
    {

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(WaitAndStartDialogue());
    }
    IEnumerator WaitAndStartDialogue()
    {
        yield return new WaitForSeconds(startingDelay);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
       

      foreach (char c in lines[index].ToCharArray())

        {
            textComponent.text += c;
            

            if (audioSource != null && typingSound != null)
            {
                audioSource.PlayOneShot(typingSound);
            }


            yield return new WaitForSeconds(textSpeed);

        }


        yield return new WaitForSeconds(2f);

        audioSource.Stop();

        NextLine();

    }


    void NextLine()
    { 
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            Debug.Log("Dialogue is Stopped");
        }
    }
}
