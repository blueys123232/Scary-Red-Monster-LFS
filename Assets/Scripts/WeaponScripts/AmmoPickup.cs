using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    private bool isCollected = false;
    private AudioSource audioSource;
    PickUpmanager pickupmanager;
    public int AmmoPickupAmount;
    WeaponStats wStats;

    // Start is called before the first frame update
    void Start()
    {
        wStats = FindAnyObjectByType<WeaponStats>();
        audioSource = GetComponent<AudioSource>();
        pickupmanager = FindAnyObjectByType<PickUpmanager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected && collision.CompareTag("Player"))
        {
            isCollected = true;
            pickupmanager.AddAmmo(AmmoPickupAmount);
            audioSource.Play();
            StartCoroutine(DestroyAfterSound());
        }
    }

    private IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(gameObject); // Destroy the coin after the sound has played
    }
}



