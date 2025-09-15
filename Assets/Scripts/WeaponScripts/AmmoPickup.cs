using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{


    private bool isCollected = false;

    //public AmmoType Atype;


    //private AudioSource audioSource;
    public int AmmoPickupAmount;
    WeaponStats wStats;

    // Start is called before the first frame update
    void Start()
    {
        wStats = FindAnyObjectByType<WeaponStats>();
        //audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!isCollected && collision.CompareTag("Player") && wStats.wType == WeaponType.Pistol)

       if (!isCollected && collision.CompareTag("Player") && wStats.wType == WeaponType.Pistol)

        {
            Debug.Log("jfiweihlkjweadaonlkjw");
            isCollected = true;
            wStats.AmmoCount += AmmoPickupAmount;


            //audioSource.Play();
            //StartCoroutine(DestroyAfterSound());



            
            //audioSource.Play();
            //StartCoroutine(DestroyAfterSound());
            


        }
    }

    //private IEnumerator DestroyAfterSound()
    //{
    //    //yield return new WaitForSeconds(audioSource.clip.length);
    //    Destroy(gameObject); // Destroy the coin after the sound has played
    //}
}

//public enum AmmoType 
//{ 
//    None,
//    Bullet,
//    Shell,

