using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    public GameObject[] weapons;
    private int currentWeaponIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentWeaponIndex = 0;
        weapons[currentWeaponIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            weapons[currentWeaponIndex].SetActive(true);
        }

        else if (scrollInput < 0f)
        {
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex--;

            if (currentWeaponIndex < 0)
            {
                currentWeaponIndex = weapons.Length - 1;
            }

            weapons[currentWeaponIndex].SetActive(true);
        }
    }
}
