using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAccessibility : MonoBehaviour
{
    private List<GameObject> accessibleWeapons = new List<GameObject>();

    public void EnableWeapon(GameObject weapon, ref bool firstWeaponEnabled)
    {
        if (weapon != null)
        {
            accessibleWeapons.Add(weapon);

            if (!firstWeaponEnabled)
            {
                weapon.SetActive(true);
                firstWeaponEnabled = true;
            }

            else
            {
                weapon.SetActive(false);
            }
        }
    }

    public void DisableWeapon(GameObject weapon)
    {
        if (weapon != null)
        {
            accessibleWeapons.Remove(weapon);
            Destroy(weapon);
        }
    }

    public bool IsWeaponAccessible(GameObject weapon)
    {
        return accessibleWeapons.Contains(weapon);
    }
}