using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{

    [SerializeField] private GameObject projectilePreFab;
    public Transform firePoint;
    private PickUpmanager puManager;
    WeaponStats weaponStats;



    //public float fireRate = 0.5f;

    private void Start()
    {
        weaponStats = GetComponent<WeaponStats>();
        puManager = FindAnyObjectByType<PickUpmanager>();

    }

    private float nextFireTime = 0f;
    // shoots when left mouse button is pressed and cooldown had passed
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && weaponStats.AmmoCount > 0)
        {
            Shoot();

        }

        else if (weaponStats.AmmoCount == 0) 

        {
            Debug.Log("Out of Ammo");
        }
    }
    void Shoot()
    {
        {
            {
                Instantiate(projectilePreFab, firePoint.transform.position, firePoint.rotation);
                puManager.AmmoLoss();
            }
        }
    }
}