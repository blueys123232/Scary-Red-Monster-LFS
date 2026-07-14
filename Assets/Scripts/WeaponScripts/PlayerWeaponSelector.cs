using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSelector : MonoBehaviour
{
    [SerializeField] private WeaponType2 wep;
    [SerializeField] private Transform wepParent;
    [SerializeField] private List<WepScriptableObject> Weps;

    [Space]
    [Header("Runtime Filled")]
    public WepScriptableObject activeWep;

    private void Start()
    {
        WepScriptableObject weap = Weps.Find(weap => weap.Type2 == wep);

        if(weap == null)
        {
            Debug.LogError($"No wep ScriptableObject found for WepType: {weap}");
            return;
        }

        activeWep = weap;
        weap.Spawn(wepParent, this);
    }
}
