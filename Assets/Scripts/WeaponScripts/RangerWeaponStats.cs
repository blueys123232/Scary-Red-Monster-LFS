using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RangerWeaponStats : MonoBehaviour
{
    public RangerWeaponType RwType;

    [SerializeField] TextMeshProUGUI ammoText;


    AmmoPickup aPickup;

    public int Damage, AmmoCount;
    public float ProjectileSpeed;

    public int RwepInt;

    [Header("Weapon Sprite")]
    public Sprite BlankImage;         // The blank sprite
    public SpriteRenderer weaponRenderer;   // Assign the weapon's SpriteRenderer here

    private void Start()
    {
        aPickup = FindAnyObjectByType<AmmoPickup>();
        RangerWeaponTypeSwitch();
    }

   public  void RangerWeaponTypeSwitch()
    {

        switch (RwType)
        {
            case RangerWeaponType.None:
                //Nothing should be NONE but if it is having this case should prevent errors
                break;
            case RangerWeaponType.Pistol:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 1;
                break;
            case RangerWeaponType.Shotgun:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 2;
                break;
            case RangerWeaponType.Bow:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 3;

                break;
            case RangerWeaponType.Launcher:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 4;
                break;
        }
    }
    private void Update()
    {
        RangerWeaponTypeSwitch();
        Debug.Log(RwepInt);
    }

}

public enum RangerWeaponType
{
    None,
    Pistol,
    Shotgun,
    Bow,
    Launcher
}