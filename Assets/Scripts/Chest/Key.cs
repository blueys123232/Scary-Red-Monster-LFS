using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Key : MonoBehaviour
{
    private bool isCollected = false;
    private AudioSource AudioSource;
    PickUpmanager puManager;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        puManager = FindAnyObjectByType<PickUpmanager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player"))
        {
            AudioSource.Play(); //Rework so sound plays
            isCollected = true;
            puManager.AddKey();
            puManager.SaveInt("KeyNumber", puManager.keyCount);
            Destroy(gameObject);
        }
    }
}