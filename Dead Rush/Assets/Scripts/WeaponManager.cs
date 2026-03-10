using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    [SerializeField] int count;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swap();
        }

        if (Input.GetMouseButtonDown(0))
        {
            weapons[count].Attack();
        }
    }

    public void Swap()
    {
        weapons[count].gameObject.SetActive(false);

        count = (count + 1) % weapons.Count;

        weapons[count].gameObject.SetActive(true);
    }

}
