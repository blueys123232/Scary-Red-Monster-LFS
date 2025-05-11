using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PickUpmanager : MonoBehaviour
{
    //Script which handles picking up, Coins, healing potions and Keys.
    public TextMeshProUGUI coinText, hPotText, keyText;
    [HideInInspector] public int coinCount, hPotCount, keyCount;


    // Start is called before the first frame update
    void Start()
    {
        coinCount = 0;
        hPotCount = 0;
        keyCount = 0;

        UpdatePickupText();
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


    void UpdatePickupText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
        hPotText.text = "Healing Potions: " + hPotCount.ToString();
        keyText.text = "Keys: " + keyCount.ToString();
    }


    public void UsePotion()
    {
        if(hPotCount > 0)
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
        if(keyCount > 0)
        {
            keyCount--;
            UpdatePickupText();
        }
        else
        {
            Debug.Log("No Keys");
        }
    }

}
