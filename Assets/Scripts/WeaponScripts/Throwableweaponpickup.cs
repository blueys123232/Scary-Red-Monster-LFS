using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Throwableweaponpickup : MonoBehaviour
{

    [SerializeField] private int Thorwables;
    private AudioSource audioSource;
    private WeaponStats wStats;
    private PickUpmanager puMan;

    // Start is called before the first frame update
    void Start()
    {
        wStats = FindAnyObjectByType<WeaponStats>();
        puMan = FindAnyObjectByType<PickUpmanager>();
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //To Do: seperate ammo by weapon, try and add ability to add ammo to weapons not currently equipped.
        if (collision.CompareTag("Player") && wStats.wType != WeaponType.Melee)
        {
            
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
