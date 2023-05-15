using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickup : MonoBehaviour
{

    public int manaAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ManaSystem manaSystem = other.GetComponent<ManaSystem>();
            if (manaSystem != null)
            {
                manaSystem.AddMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }
}
