using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThrowableWeaponStats : MonoBehaviour
{
   
    public ThrowableWeaponType TwType;

    [SerializeField] TextMeshProUGUI ThrowableWeaponObjects;


    AmmoPickup aPickup;

    public int Damage, ThrowableWeapons;
    public float ProjectileSpeed;

    public int wepInt;

    [Header("Weapon Sprite")]
    public Sprite BlankImage;         // The blank sprite
    public SpriteRenderer weaponRenderer;   // Assign the weapon's SpriteRenderer here

    private void Start()
    {

        ThrowableWeaponTypeSwitch();
    }

    public void ThrowableWeaponTypeSwitch()
    {

        switch (TwType)
        {
            case ThrowableWeaponType.None:
                //Nothing should be NONE but if it is having this case should prevent errors
                break;
            case ThrowableWeaponType.Shuriken:
                //Nothing should be NONE but if it is having this case should prevent errors
                break;

        }
    }
    private void Update()
    {
        ThrowableWeaponTypeSwitch();
        Debug.Log(wepInt);
    }

}


public enum ThrowableWeaponType
{
    None,
    Bomb,
    Shuriken

}
