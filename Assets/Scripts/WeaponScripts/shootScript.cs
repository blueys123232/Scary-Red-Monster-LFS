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
    public AudioSource Shooting;
    private Animator PlayerAnimator;

    private void Start()
    {
        PlayerAnimator = FindAnyObjectByType<PlayerMovement>().GetComponent<Animator>();
        weaponStats = GetComponent<WeaponStats>();
        puManager = FindAnyObjectByType<PickUpmanager>();
        firePoint = GameObject.Find("FirePoint").transform;
    }

    private float nextFireTime = 0f;
    // shoots when left mouse button is pressed and cooldown had passed
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && weaponStats.AmmoCount > 0)
        {
            PlayerAnimator.SetBool("isFiring", true);
            StartCoroutine(Shoot());
        }

        else if (weaponStats.AmmoCount == 0)

        {
            Debug.Log("Out of Ammo");
        }

        
    }
    private IEnumerator Shoot()
    {
        Instantiate(projectilePreFab, weaponStats.transform.position, firePoint.rotation);
        puManager.AmmoLoss();

        yield return new WaitForSeconds(0.1f);
        PlayerAnimator.SetBool("isFiring", false);
        //When sound effect added use that as timer for weaponfired boolean
    }

    
}