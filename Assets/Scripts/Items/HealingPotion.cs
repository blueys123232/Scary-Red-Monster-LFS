using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class HealingPotion : MonoBehaviour
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
        if(!isCollected && collision.CompareTag("Player"))
        {
            isCollected = true;
            puManager.AddPotion();
            AudioSource.Play();
            puManager.SaveInt("PotionNumber", puManager.hPotCount);
            StartCoroutine(DestroyAfterSound()); // Destroy the HPot after the sound plays
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(AudioSource.clip.length);
        Destroy(gameObject); // Destroy the HPot after the sound has played
    }
}


