using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    //public GameObject projectilePreFab;
    //public Transform firePoint;
    //public float projectilespeed = 20f;
    //public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    // shoots when left mouse button is pressed and cooldown had passed
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            //nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        {
            {
                Debug.Log("Firing " + gameObject.name);

            }
        }
    }
}