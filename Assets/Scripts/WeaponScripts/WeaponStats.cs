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
    public string wepId;
    public SpriteRenderer weaponRenderer;
    public Sprite BlankImage;


    private void Start()
    {

        aPickup = FindAnyObjectByType<AmmoPickup>();
        WeaponTypeSwitch();
        PlayerPrefs.GetString(wepId);
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
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 1;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;
            case WeaponType.Shotgun:
                WeaponText.text = "Shells: " + AmmoCount.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 2;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;
            case WeaponType.Bow:
                WeaponText.text = "Arrows: " + AmmoCount.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 3;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;

            case WeaponType.Launcher:
                WeaponText.text = "Bombs: " + AmmoCount.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 5;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;

            case WeaponType.Sword:
                WeaponText.text = "Damage:" + Damage.ToString();
                wepInt = 6;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;

            case WeaponType.Katana:
                WeaponText.text = "Damage:" + Damage.ToString();
                wepInt = 7;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;

            case WeaponType.Cannon:
                WeaponText.text = "Bombs:" + AmmoCount.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 4;
                wepId = this.GetInstanceID().ToString();
                PlayerPrefs.SetString("WeaponID", wepId);
                break;

            case WeaponType.Hammer:
                WeaponText.text = "Damage:" + Damage.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 10;
                break;
            case WeaponType.Chainsaw:
                WeaponText.text = "Damage:" + Damage.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 8;
                break;
            case WeaponType.Spear:
                WeaponText.text = "Damage:" + Damage.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 7;
                break;
            case WeaponType.BombLauncher:
                WeaponText.text = "Bombs:" + AmmoCount.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 9;
                break;
            case WeaponType.Axe:
                WeaponText.text = "Damage:" + Damage.ToString();
                if (weaponRenderer != null && BlankImage != null)
                    weaponRenderer.sprite = BlankImage;
                wepInt = 11;
                break;


        }
        PlayerPrefs.Save();
    }
    private void Update()
    {
        WeaponTypeSwitch();

    }

}

public enum WeaponType
{
    None,
    Axe,
    BombLauncher,
    Katana,
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
    Hand,
    Cannon
}