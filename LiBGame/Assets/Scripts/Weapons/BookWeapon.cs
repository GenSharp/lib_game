using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookWeapon : MonoBehaviour
{
    public GameObject spherePrefab;
    public float sphereRadius = 5f;
    public float damageInterval = 1f;
    public int damageAmount = 5;
    public float manaDrainRate = 0.5f;

    private bool isBookActive = false;
    private float lastDamageTime = 0f;
    private GameObject sphere;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ManaSystem manaSystem = FindObjectOfType<ManaSystem>();
            if (!isBookActive && manaSystem.UseMana(1))
            {
                ActivateBook();
            }
            else
            {
                DeactivateBook();
            }
        }

        // Drain mana when book is active
        if (isBookActive)
        {
            ManaSystem manaSystem = FindObjectOfType<ManaSystem>();
            manaSystem.UseMana(Mathf.CeilToInt(manaDrainRate * Time.deltaTime));

            if (manaSystem.currentMana <= 0)
            {
                DeactivateBook();
            }
        }
    }

    void ActivateBook()
    {
        isBookActive = true;
        sphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);
        sphere.transform.localScale = new Vector3(sphereRadius, sphereRadius, sphereRadius);
        sphere.GetComponent<Renderer>().enabled = true;
    }

    void DeactivateBook()
    {
        isBookActive = false;
        Destroy(sphere);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isBookActive && other.CompareTag("Enemy") && Time.time - lastDamageTime > damageInterval)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, sphereRadius, LayerMask.GetMask("Enemy"));
            foreach (Collider collider in colliders)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damageAmount);
                }
            }

            lastDamageTime = Time.time;
        }
    }
}