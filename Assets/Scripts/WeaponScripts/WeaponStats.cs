using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class WeaponStats : MonoBehaviour
{
    public WeaponType wType;

    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI Meleetext;
    [SerializeField] TextMeshProUGUI ThrowableText;
    AmmoPickup aPickup;
    

    public int Damage, AmmoCount, ThrowableWeapons, MeleeDamage;
    public float ProjectileSpeed;
    public int wepInt;

    [Header("Weapon Sprite")]
    public Sprite BlankImage;         // The blank sprite
    public SpriteRenderer weaponRenderer;   // Assign the weapon's 
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
             
                break;
            case WeaponType.Pistol:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 1;
                break;
            case WeaponType.Shotgun:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 2;
                break;
            case WeaponType.Bow:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 3;

                break;
            case WeaponType.Launcher:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 4;
                break;
            case WeaponType.Sword:
                Meleetext.text = "Damage:" + MeleeDamage.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                break;
            case WeaponType.Hammer:
                ammoText.text = "Ammo:" + MeleeDamage.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                break;
            case WeaponType.Chainsaw:
                ammoText.text = "Ammo:" + MeleeDamage.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                break;

        }
    }
    private void Update()
    {
        WeaponTypeSwitch();
        //Debug.Log(wepInt);
    }

}

public enum WeaponType
{
    Dagger,
    None,
    Sword,
    Pistol,
    Shotgun,
    Bow,
    Launcher,
    Bomb,
    Hammer,
    Chainsaw
   
}