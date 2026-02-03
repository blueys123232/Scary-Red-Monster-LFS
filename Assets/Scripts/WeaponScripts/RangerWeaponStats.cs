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
    [SerializeField] Sprite BlankImage;         // The blank sprite
    [SerializeField] SpriteRenderer weaponRenderer;   // Assign the weapon's SpriteRenderer here

    private void Start()
    {
        aPickup = FindAnyObjectByType<AmmoPickup>();
        RangerWeaponTypeSwitch();
    }

   public void RangerWeaponTypeSwitch()
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
                RwepInt = 0;
                //Debug.Log(RwepInt);
                break;
            case RangerWeaponType.Shotgun:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 1;
                //Debug.Log(RwepInt);
                break;
            case RangerWeaponType.Bow:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 2;
                //Debug.Log(RwepInt);

                break;
            case RangerWeaponType.Launcher:
                ammoText.text = "Ammo:" + AmmoCount.ToString();

                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                RwepInt = 3;
                //Debug.Log(RwepInt);
                break;
        }
    }
    private void Update()
    {
        RangerWeaponTypeSwitch();

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