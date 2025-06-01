using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{
    // Start is called before the first frame update

    int totalWeapons = 1;
    public int CurrentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;
    public GameObject currentGun;

    void Start()
    {
        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
    }
   // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // next Gun
            if (CurrentWeaponIndex < totalWeapons-1)
            {
                guns[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex += 1;
                guns[CurrentWeaponIndex].SetActive(true);
                currentGun = guns[CurrentWeaponIndex];
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Previous Gun
            if (CurrentWeaponIndex > 0)
            {
                guns[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex -= 1;
                guns[CurrentWeaponIndex].SetActive(true);
                currentGun = guns[CurrentWeaponIndex];
            }
        }
    }
}
