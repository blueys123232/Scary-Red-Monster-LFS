using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponScript : MonoBehaviour
{
    // Start is called before the first frame update

    int totalWeapons;
    [SerializeField] int CurrentWeaponIndex;

    [SerializeField] GameObject[] Weapons;
    [SerializeField] GameObject[] WeaponsUI;
    [SerializeField] GameObject weaponHolder, weaponUIHolder, currentWeapon;

    shootScript S_Script;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        Weapons = new GameObject[totalWeapons];
        WeaponsUI = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            Weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            Weapons[i].SetActive(false);

            WeaponsUI[i] = weaponUIHolder.transform.GetChild(i).gameObject;
            WeaponsUI[i].SetActive(false);
        }
        //Weapons[0] should by default be unarmed
        Weapons[0].SetActive(true);
        WeaponsUI[0].SetActive(true);

        //LoadInt();

    }
    // Update is called once per frame
    void Update()
    {
        totalWeapons = weaponHolder.transform.childCount;
        Weapons = new GameObject[totalWeapons];
        WeaponsUI = new GameObject[totalWeapons];

        //if(Input.GetKeyDown(KeyCode.Comma))
        //{
        //    SaveWeaponsHeld("WeaponsHeld", CurrentWeaponIndex);
        //    Debug.Log("Saved Weapons" + CurrentWeaponIndex);
        //}

        WeaponSwitch();
    }

    void WeaponSwitch()
    {

        S_Script = FindAnyObjectByType<shootScript>();

        /* 
         Update the weapons fire point in here somewhere?
        so that it doesnt just update whenever we move
         */

        for (int i = 0; i < totalWeapons; i++)
        {
            Weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            WeaponsUI[i] = weaponUIHolder.transform.GetChild(i).gameObject;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            // Next weapon
            if (CurrentWeaponIndex < totalWeapons - 1)
            {
                Weapons[CurrentWeaponIndex].SetActive(false);
                WeaponsUI[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex += 1;

                //Sets next weapon to active
                Weapons[CurrentWeaponIndex].SetActive(true);
                WeaponsUI[CurrentWeaponIndex].SetActive(true);
                currentWeapon = Weapons[CurrentWeaponIndex];

            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Previous Weapon
            if (CurrentWeaponIndex > 0)
            {
                Weapons[CurrentWeaponIndex].SetActive(false);
                WeaponsUI[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex -= 1;

                Weapons[CurrentWeaponIndex].SetActive(true);
                WeaponsUI[CurrentWeaponIndex].SetActive(true);
                currentWeapon = Weapons[CurrentWeaponIndex];

            }
        }
    }

    //void SaveWeaponsHeld(string curWeapons, int totWeapons)
    //{
    //    PlayerPrefs.SetInt(curWeapons, totWeapons);
    //    PlayerPrefs.Save();
    //}

    //public void LoadInt()
    //{
    //    CurrentWeaponIndex = PlayerPrefs.GetInt("WeaponsHeld");
    //    Debug.Log("loaded Weapons");
    //}

}