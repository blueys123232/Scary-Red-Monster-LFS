using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    private bool isCollected = false;
    private AudioSource audioSource;
    PickUpmanager puManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        puManager = FindAnyObjectByType<PickUpmanager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            isCollected = true; // Mark as collected to prevent multiple triggers
            puManager = FindAnyObjectByType<PickUpmanager>();
            audioSource.Play(); // Play the coin collection sound
            StartCoroutine(DestroyAfterSound()); // Destroy the coin after the sound plays
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject); // Destroy the coin after the sound has played
    }
}
