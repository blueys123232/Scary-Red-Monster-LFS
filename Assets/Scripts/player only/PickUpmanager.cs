using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PickUpmanager : MonoBehaviour
{
    //Script which handles picking up, Coins, healing potions and Keys.
    

    [HideInInspector] public int coinCount, hPotCount, keyCount;
    WeaponStats wStats;
   

    public int coinCount, hPotCount, keyCount;



    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        hPotCount = 0;
        keyCount = 0;


        UpdatePickupText();
    }

    private void Update()
    {

        wStats = FindAnyObjectByType<WeaponStats>();
       

        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadInt();
        }

    }

    public void AddCoin()
    {
        coinCount++;
        UpdatePickupText();
    }

    public void AddKey()
    {
        keyCount++;
        UpdatePickupText();
    }

    public void AddPotion()
    {
        hPotCount++;
        UpdatePickupText();
    }

    public void AddAmmo(int AmmoToAdd)
    {
        wStats.AmmoCount = wStats.AmmoCount + AmmoToAdd;
        UpdatePickupText();
    }

    public void AddThrowables (int ThrowabletoAdd)
    {
        wStats.ThrowableWeapons = wStats.ThrowableWeapons + ThrowabletoAdd;
        UpdatePickupText();

    }
    public void UpdatePickupText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
        hPotText.text = "Healing Potions: " + hPotCount.ToString();
        keyText.text = "Keys: " + keyCount.ToString();
    }


    public void UsePotion()
    {
        if (hPotCount > 0)
        {
            hPotCount = hPotCount - 1;
            UpdatePickupText();
        }
        else
        {
            Debug.Log("No potions");
        }
    }

    public void UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--;
            UpdatePickupText();
        }
        else
        {
            Debug.Log("No Keys");
        }
    }

    public void AmmoLoss()
    {
        wStats.AmmoCount--;
        UpdatePickupText();
    }

    public void ThrowableLoss()
    {
        wStats.ThrowableWeapons--;
        UpdatePickupText();
    }

    public void SaveInt(string keyName, int Value)
    {
        PlayerPrefs.SetInt(keyName, Value);
        PlayerPrefs.Save();
    }

    public void LoadInt()
    {
        coinCount = PlayerPrefs.GetInt("CoinNumber");
        keyCount = PlayerPrefs.GetInt("KeyNumber");
        hPotCount = PlayerPrefs.GetInt("PotionNumber");
        UpdatePickupText(); 
    }
}