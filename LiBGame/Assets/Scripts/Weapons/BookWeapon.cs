using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookWeapon : MonoBehaviour
{

    public int minManaCost = 5;
    public int maxManaCost = 15;
    public int minDamage = 5;
    public int maxDamage = 15;
    public float fireRate = 3f;

    private float nextFireTime;
    private ManaSystem manaSystem;

    // Start is called before the first frame update
    private void Start()
    {
        manaSystem = FindObjectOfType<ManaSystem>();
        nextFireTime = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            int manaCost = Random.Range(minManaCost, maxManaCost + 1);
            int damageAmount = Random.Range(minDamage, maxDamage + 1);

            if (manaSystem.UseMana(manaCost))
            {
                DealDamageToEnemies(damageAmount);
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    private void DealDamageToEnemies(int damageAmount)
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            enemy.TakeDamage(damageAmount);
        }
    }
}
