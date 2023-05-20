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
        ActivateCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
        {
            DeactivateCurrentWeapon();
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            ActivateCurrentWeapon();
        }
        else if (scrollInput < 0f)
        {
            DeactivateCurrentWeapon();
            currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;
            ActivateCurrentWeapon();
        }
    }

    private void ActivateCurrentWeapon()
    {
        if (weapons[currentWeaponIndex] != null)
        {
            weapons[currentWeaponIndex].SetActive(true);
        }
        else
        {
            SkipDestroyedWeapons(1);
            ActivateCurrentWeapon();
        }
    }

    private void DeactivateCurrentWeapon()
    {
        if (weapons[currentWeaponIndex] != null)
        {
            weapons[currentWeaponIndex].SetActive(false);
        }
    }

    private void SkipDestroyedWeapons(int skipCount)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            int index = (currentWeaponIndex + i) % weapons.Length;
            if (weapons[index] != null)
            {
                skipCount--;
                if (skipCount <= 0)
                {
                    currentWeaponIndex = index;
                    return;
                }
            }
        }
    }
}