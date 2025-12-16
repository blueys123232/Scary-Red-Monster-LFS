using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;


public class WeaponStats : MonoBehaviour
{
    public WeaponType wType;
    [SerializeField] TextMeshProUGUI ammoText;


    AmmoPickup aPickup;

    public int Damage, AmmoCount;
    public float ProjectileSpeed;

    public int wepInt;

    private void Start()
    {

        aPickup = FindAnyObjectByType<AmmoPickup>();
        WeaponTypeSwitch();
    }

    public void WeaponTypeSwitch()
    {
        switch (wType)
        {
            case WeaponType.None:
                //Nothing should be NONE but if it is having this case should prevent errors
                break;

            case WeaponType.Melee:
                ammoText.text = "Melee";
                wepInt = 0;
                //No pickups or anything for this one
                break;
            case WeaponType.Pistol:
                ammoText.text = "Ammo: " + AmmoCount.ToString();
                wepInt = 1;
                break;
            case WeaponType.Shotgun:
                ammoText.text = "Ammo: " + AmmoCount.ToString();
                wepInt = 2;
                break;
            case WeaponType.Bow:
                ammoText.text = "Arrows: " + AmmoCount.ToString();
                wepInt = 3;
                break;
            case WeaponType.Launcher:
                ammoText.text = "Explosives: " + AmmoCount.ToString();
                wepInt = 4;
                break;
        }
    }
    private void Update()
    {
        WeaponTypeSwitch();
        Debug.Log(wepInt);
    }

}

public enum WeaponType
{
    Thrower,
    None,
    Melee,
    Pistol,
    Shotgun,
    Bow,
    Launcher
}