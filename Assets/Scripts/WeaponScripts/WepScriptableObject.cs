using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Weapon", order = 0)]
public class WepScriptableObject : ScriptableObject
{
    public WeaponType2 Type2;
    public Transform firePosition;
    public string Name;
    public GameObject SpritePrefab;
    public Vector2 SpawnPoint;

    public WepConfigSO wepConfig;

    private MonoBehaviour ActiveMB;
    private GameObject spriteM;
    private float LastShootTime;

    public void Spawn(Transform parent, MonoBehaviour activeMB)
    {
        this.ActiveMB = activeMB;
        LastShootTime = 0; //In editor this will NOT be properly reset, in this is fine.
        spriteM = Instantiate(SpritePrefab);
        spriteM.transform.SetParent(parent, false);
        spriteM.transform.localPosition = SpawnPoint;
        
    }

    public void Shoot()
    {
        if(Time.time > wepConfig.Firerate + LastShootTime)
        {
            LastShootTime = Time.time;
            Vector2 shotDirection = firePosition.right;

            RaycastHit2D hit2D = Physics2D.Raycast(firePosition.transform.position, shotDirection, float.MaxValue, wepConfig.HitMask);

            if (hit2D)
            {
                Debug.Log("Shot Hit");
            }
            else
            {
                Debug.Log("Shot Missed");
            }
        }
    }

}
