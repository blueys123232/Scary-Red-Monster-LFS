using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class PlayerAction : MonoBehaviour
{
    [SerializeField] private PlayerWeaponSelector weaponSelector;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && weaponSelector.activeWep != null) 
        { 
            
        }
    }
}
