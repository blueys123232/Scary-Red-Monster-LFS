using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WeaponStats : MonoBehaviour
{
    public WeaponType wType;

    public TextMeshProUGUI ammoText;


    public int Damage, AmmoCount;
    public float ProjectileSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (wType == WeaponType.Projectile)
        {
            ammoText.text = "Ammo: " + AmmoCount.ToString();
        }
        else if(wType == WeaponType.Melee)
        {
            ammoText.text = "Melee";
        }

    }

}

public enum WeaponType
{
    None,
    Melee,
    Projectile,
}
