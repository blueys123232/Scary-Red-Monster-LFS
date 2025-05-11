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
            isCollected = true;
            puManager.AddKey();
            AudioSource.Play();
            StartCoroutine(DestroyAfterSound()); // Destroy the coin after the sound plays
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(AudioSource.clip.length);
        Destroy(gameObject); // Destroy the coin after the sound has played
    }

}