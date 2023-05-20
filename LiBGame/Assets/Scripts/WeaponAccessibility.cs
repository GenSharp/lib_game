using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAccessibility : MonoBehaviour
{
    private List<GameObject> accessibleWeapons = new List<GameObject>();

    public void EnableWeapon(GameObject weapon)
    {
        if (weapon != null)
        {
            accessibleWeapons.Add(weapon);
            weapon.SetActive(true);
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