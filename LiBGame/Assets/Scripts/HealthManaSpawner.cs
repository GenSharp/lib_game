using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManaSpawner : MonoBehaviour
{

    public GameObject healthCrystal;
    public GameObject manaCrystal;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    private GameObject currentHealthCrystal;
    private GameObject currentManaCrystal;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (currentHealthCrystal == null)
            {
                currentHealthCrystal = Instantiate(healthCrystal, spawnPoint1.position, spawnPoint1.rotation);
            }

            if (currentManaCrystal == null)
            {
                currentManaCrystal = Instantiate(manaCrystal, spawnPoint2.position, spawnPoint2.rotation);
            }

            yield return new WaitForSeconds(20f);
        }
    }
}