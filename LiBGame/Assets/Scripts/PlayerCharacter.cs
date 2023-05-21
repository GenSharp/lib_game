using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public GameObject swordWeapon;
    public GameObject staffWeapon;
    public GameObject handsWeapon;
    public GameObject bookWeapon;

    private CharacterClass selectedClass;
    private WeaponAccessibility weaponAccessibility;

    // Start is called before the first frame update
    private void Start()
    {
        ClassSelectionManager classSelectionManager = FindObjectOfType<ClassSelectionManager>();

        if (classSelectionManager != null)
        {
            selectedClass = classSelectionManager.GetSelectedClass();
            Debug.Log("Selected Class: " + selectedClass.ToString());
            weaponAccessibility = GetComponent<WeaponAccessibility>();
            if (weaponAccessibility == null)
            {
                weaponAccessibility = gameObject.AddComponent<WeaponAccessibility>();
            }
            ApplyClassAttributes();
        }
        else
        {
            Debug.LogError("ClassSelectionManager object not found in the scene!");
        }
    }

    private void ApplyClassAttributes()
    {
        bool firstWeaponEnabled = false;

        switch (selectedClass)
        {
            case CharacterClass.Warrior:
                weaponAccessibility.EnableWeapon(swordWeapon, ref firstWeaponEnabled);
                weaponAccessibility.DisableWeapon(staffWeapon);
                weaponAccessibility.DisableWeapon(handsWeapon);
                weaponAccessibility.DisableWeapon(bookWeapon);
                break;

            case CharacterClass.Mage:
                weaponAccessibility.DisableWeapon(swordWeapon);
                weaponAccessibility.EnableWeapon(staffWeapon, ref firstWeaponEnabled);
                weaponAccessibility.EnableWeapon(handsWeapon, ref firstWeaponEnabled);
                weaponAccessibility.DisableWeapon(bookWeapon);
                break;

            case CharacterClass.Cleric:
                weaponAccessibility.DisableWeapon(swordWeapon);
                weaponAccessibility.DisableWeapon(staffWeapon);
                weaponAccessibility.DisableWeapon(handsWeapon);
                weaponAccessibility.EnableWeapon(bookWeapon, ref firstWeaponEnabled);
                break;
        }
    }
}