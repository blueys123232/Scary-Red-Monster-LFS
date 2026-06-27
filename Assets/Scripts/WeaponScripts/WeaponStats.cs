using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class WeaponStats : MonoBehaviour
{
    public WeaponType wType;
    AmmoPickup aPickup;

    //Weapon Text for Ranged/throwable weapons = Ammo
    //Weapon text for Melee Weapons = Damage
    [SerializeField] TextMeshProUGUI WeaponText;

    public int Damage, AmmoCount;
    [HideInInspector] public int ThrowableWeapons;
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


            case WeaponType.Hand:
                WeaponText.text = "Damage: " + Damage.ToString();
                wepInt = 0;
                break;

            case WeaponType.Pistol:
                WeaponText.text = "Ammo:" + AmmoCount.ToString();

                wepInt = 1;

                break;
            case WeaponType.Shotgun:
                WeaponText.text = "Shells: " + AmmoCount.ToString();

                wepInt = 2;
                break;
            case WeaponType.Bow:
                WeaponText.text = "Arrows: " + AmmoCount.ToString();

                wepInt = 3;

                break;
            case WeaponType.Launcher:
                WeaponText.text = "Explosives: " + AmmoCount.ToString();
                wepInt = 4;
                break;
            case WeaponType.Sword:
                WeaponText.text = "Damage:" + Damage.ToString();
                wepInt = 5;

                break;
                //case WeaponType.Hammer:
                //    WeaponText.text = "Ammo:" + MeleeDamage.ToString();
                //    break;
                //case WeaponType.Chainsaw:
                //    WeaponText.text = "Damage:" + MeleeDamage.ToString();
                //    break;

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
    Dagger,
    Sword,
    Pistol,
    Shotgun,
    Bow,
    Launcher,
    Bomb,
    Hammer,
    Chainsaw,
    Spear,
    Shuriken,
    Hand
}