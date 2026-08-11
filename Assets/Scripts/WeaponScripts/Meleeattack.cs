using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Meleeattack : MonoBehaviour
{

    [SerializeField]
    private InputActionReference MeleeAction;

    WeaponStats weaponStats;
    private Animator PlayerAnimator;
    public GameObject HitBox;
    public AudioSource MeleeSound;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerAnimator = FindAnyObjectByType<PlayerMovement>().GetComponent<Animator>();

        weaponStats = GetComponent<WeaponStats>();

        if (HitBox.gameObject.active)
        {
            HitBox.gameObject.SetActive(false);
        }


    }
    private void OnEnable()
    {
        MeleeAction.action.Enable();
    }
    private void OnDisable()
    {
        MeleeAction.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (MeleeAction.action.WasPressedThisFrame())
        {
            if (MeleeSound != null)
            {
                MeleeSound.Play();
            }


            StartCoroutine(e_MeleeAttack());
        }

    }


    private IEnumerator e_MeleeAttack()
    {
        PlayerAnimator.SetBool("isMelee", true);
        HitBox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        PlayerAnimator.SetBool("isMelee", false);
        HitBox.SetActive(false);
    }


}