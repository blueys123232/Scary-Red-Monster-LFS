using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private GameObject InactiveWeapon, InactiveWeaponUI;
    [SerializeField] private GameObject WeaponHolder, WeaponUIHolder;
    [SerializeField] private Transform weaponPositionOnPlayer;

    PickUpmanager puManager;


    private void Start()
    {
        puManager = FindAnyObjectByType<PickUpmanager>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            InactiveWeapon.transform.parent = WeaponHolder.transform;
            InactiveWeaponUI.transform.parent = WeaponUIHolder.transform; 
            InactiveWeapon.transform.position = weaponPositionOnPlayer.position;
            Destroy(this.gameObject);
        }
    }
}