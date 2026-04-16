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
    public bool weaponFired;
    public AudioSource Shooting;
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
            weaponFired = true;
            StartCoroutine(Shoot());
        }

        else if (weaponStats.AmmoCount == 0)

        {
            Debug.Log("Out of Ammo");
        }
    }
    private IEnumerator Shoot()
    {
        {
            {

                Instantiate(projectilePreFab, firePoint.transform.position, firePoint.rotation);
                puManager.AmmoLoss();

                yield return new WaitForSeconds(0.1f);
                weaponFired = false;
                //When sound effect added use that as timer for weaponfired boolean

            }
        }
    }
}