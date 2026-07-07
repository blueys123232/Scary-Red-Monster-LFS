//using JetBrains.Annotations;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class CanThrowWeapons : MonoBehaviour
//{

//    [SerializeField] private GameObject projectilePreFab;
//    public Transform firePoint;
//    private PickUpmanager puManager;
//    //ThrowableWeaponStats ThrowableWeaponStats;
//    public bool weaponFired;
//    public AudioSource Shooting;
//    private void Start()
//    {
//        //ThrowableWeaponStats = GetComponent<ThrowableWeaponStats>();
//        puManager = FindAnyObjectByType<PickUpmanager>();
//    }

//    private float nextFireTime = 0f;
//    // shoots when left mouse button is pressed and cooldown had passed
//    void Update()
//    {
//        if (Input.GetButtonDown("Fire1") && ThrowableWeaponStats.ThrowableWeapons > 0)
//        {
//            weaponFired = true;
//            StartCoroutine(Shoot());
//        }

//        else if (ThrowableWeaponStats.ThrowableWeapons == 0)

//        {
//            Debug.Log("Out of Ammo");
//        }
//    }
//    private IEnumerator Shoot()
//    {
//        {
//            {
//                Instantiate(projectilePreFab, firePoint.transform.position, firePoint.rotation);
//                puManager.ThrowableLoss();
//                yield return null;
//                //When sound effect added use that as timer for weaponfired boolean
//                weaponFired = false;
//            }
//        }
//    }
//}