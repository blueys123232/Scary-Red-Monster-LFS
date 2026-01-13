using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private PickUpmanager puManager;
    [SerializeField] int AmmoPickupAmount;
    private AudioSource audioSource;
    private RangerWeaponStats RwStats;


    // Start is called before the first frame update
    void Start()
    {
        RwStats = FindAnyObjectByType<RangerWeaponStats>();
        audioSource = GetComponent<AudioSource>();
        puManager = FindAnyObjectByType<PickUpmanager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //To Do: seperate ammo by weapon, try and add ability to add ammo to weapons not currently equipped.
        if (collision.CompareTag("Player") && RwStats.RwType != RangerWeaponType.None)
        {
            puManager.AddAmmo(AmmoPickupAmount);
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