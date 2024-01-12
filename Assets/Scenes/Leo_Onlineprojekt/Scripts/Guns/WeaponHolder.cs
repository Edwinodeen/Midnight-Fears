using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    GunProjectiles[] guns;
    public int Weapon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Weapon++;
            if (Weapon >= guns.Length)
            {
                Weapon = 0;
            }
            for (int i = 0; i < guns.Length; i++)  //Lös detta!!!!!!!!!!!!!!
            {
                if (i != Weapon)
                {
                    guns[i].gameObject.SetActive(false);
                }
                else
                {
                    guns[i].gameObject.SetActive(true);
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            guns[Weapon].Shoot();
        }
       
    }
}
