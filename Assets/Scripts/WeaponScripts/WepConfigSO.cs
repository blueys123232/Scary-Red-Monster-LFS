using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Config", menuName = "Weapons/Weapon Configuration", order = 2)]
public class WepConfigSO : ScriptableObject
{
    public LayerMask HitMask;
    public Vector2 spread = new Vector2(0.1f, 0.1f);
    public float Firerate = 0.25f;
}
