using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    private MeshRenderer meshRenderer;
    private Color originalColor;
    private Color damageColor = Color.red;
    private float colorChangeDuration = 0.1f;

    private EnemyCounter enemyCounter;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;

        enemyCounter = FindObjectOfType<EnemyCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        StartCoroutine(DamageEffect());
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        enemyCounter.EnemyKilled();

        Destroy(gameObject);
    }

    private IEnumerator DamageEffect()
    {
        meshRenderer.material.color = damageColor;
        yield return new WaitForSeconds(colorChangeDuration);
        meshRenderer.material.color = originalColor;
    }
}