using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color damageColor = Color.red;
    private float colorChangeDuration = 0.2f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        StartCoroutine(DamageEffect());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //dodati nesto ovdje?
        Destroy(gameObject);
    }

    private IEnumerator DamageEffect()
    {
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(colorChangeDuration);
        spriteRenderer.color = originalColor;
    }
}
