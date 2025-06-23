using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject UnactiveWeapon;
    public GameObject WeaponHolder;
    public Transform weaponPositionOnPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

=======
        
>>>>>>> 0e1d4cbcd3fb9157acae26a0ba8f3ee0f3f67ee3
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            UnactiveWeapon.transform.parent = WeaponHolder.transform;
            UnactiveWeapon.transform.position = weaponPositionOnPlayer.position;
            Destroy(this.gameObject);
        }


<<<<<<< HEAD

    }
}
=======
        
    }
}
>>>>>>> 0e1d4cbcd3fb9157acae26a0ba8f3ee0f3f67ee3
