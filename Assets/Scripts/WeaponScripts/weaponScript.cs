using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponScript : MonoBehaviour
{
    // Start is called before the first frame update

    int totalWeapons;
    public int CurrentWeaponIndex;

    public GameObject[] Weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;
    public Sprite currentWeaponSprite;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        Weapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            Weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            Weapons[i].SetActive(false);
        }

        Weapons[0].SetActive(true);
    }
   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // next Gun
            if (CurrentWeaponIndex < totalWeapons-1)
            {
                Weapons[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex += 1;
                Weapons[CurrentWeaponIndex].SetActive(true);
                currentWeapon = Weapons[CurrentWeaponIndex];
                currentWeaponSprite = FindAnyObjectByType<WeaponStats>().weaponImage;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Previous Gun
            if (CurrentWeaponIndex > 0)
            {
                Weapons[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex -= 1;
                Weapons[CurrentWeaponIndex].SetActive(true);
                currentWeapon = Weapons[CurrentWeaponIndex];
                currentWeaponSprite = FindAnyObjectByType<WeaponStats>().weaponImage;
            }
        }
    }
}
