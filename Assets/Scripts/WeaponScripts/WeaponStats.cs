using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WeaponStats : MonoBehaviour
{
    public WeaponType wType;

    [SerializeField] TextMeshProUGUI ammoText;


    public int Damage, AmmoCount;
    public float ProjectileSpeed;

    private void Start()
    {

    }

    private void WeaponTypeSwitch()
    {
        switch (wType)
        {
            case WeaponType.None:
                //Nothing should be NONE but if it is having this case should prevent errors
                break;

            case WeaponType.Melee:
                ammoText.text = "Melee";
                //No pickups or anything for this one
                break;

            case WeaponType.Pistol:
                ammoText.text = "Ammo: " + AmmoCount.ToString();
                break;

            case WeaponType.Shotgun:
                ammoText.text = "Ammo: " + AmmoCount.ToString();
                break;
            case WeaponType.Bow:
                ammoText.text = "Arrows: " + AmmoCount.ToString();
                break;

        }
    }
    private void Update()
    {
        WeaponTypeSwitch();
    }

}

public enum WeaponType
{
    None,
    Melee,
    Pistol,
    Shotgun,
    Bow,
    Launcher

}