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

<<<<<<< HEAD
    // Update is called once per frame
    void Update()
    {

    }
=======
>>>>>>> 08de1bc0fa1e482b247ea91216b788fbe3155b00

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
>>>>>>> 08de1bc0fa1e482b247ea91216b788fbe3155b00
