using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meleeattack : MonoBehaviour
{
    WeaponStats weaponStats;
    private Animator PlayerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerAnimator = FindAnyObjectByType<PlayerMovement>().GetComponent<Animator>();
        weaponStats = GetComponent<WeaponStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(e_MeleeAttack());
        }

    }

    private IEnumerator e_MeleeAttack()
    {
        PlayerAnimator.SetBool("isMelee", true);
        yield return new WaitForSeconds(0.2f);
        PlayerAnimator.SetBool("isMelee", false);
    }
}