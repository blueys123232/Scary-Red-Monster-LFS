using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    [SerializeField] int AmmoCount;

    [SerializeField] private GameObject projectilePreFab;
    public Transform firePoint;

    //public float fireRate = 0.5f;

    private void Start()
    {

        AmmoCount = 25;
    }

    private float nextFireTime = 0f;
    // shoots when left mouse button is pressed and cooldown had passed
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (AmmoCount > 0)
            {
                Shoot();
            }
            else
            {
                Debug.Log("No Ammo left");
            }

            //nextFireTime = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        {
            {
                Debug.Log("Firing " + gameObject.name);
                Instantiate(projectilePreFab, firePoint.transform.position, firePoint.rotation);
                AmmoCount--;
            }
        }
    }
}