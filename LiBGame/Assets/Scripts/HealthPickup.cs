using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public int healthAmount = 15;

    private void OnTriggerEnter(Collider other)
    {
        HealthManager healthManager = FindObjectOfType<HealthManager>();
        if (healthManager != null)
        {
            healthManager.AddHealth(healthAmount);
            gameObject.SetActive(false);
        }
    }
}
