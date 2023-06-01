using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;

    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateHealthText();
        Shop.OnHealthUpgrade += UpgradeMaxHealth;
    }

    private void OnDestroy()
    {
        Shop.OnHealthUpgrade -= UpgradeMaxHealth;
    }

    public bool TakeDamage(int damageAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        UpdateHealthText();
        if (currentHealth == 0)
        {
            Die();
            return true;
        }
        return false;
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        healthText.SetText(currentHealth.ToString());
    }

    private void UpgradeMaxHealth(int upgradeAmount)
    {
        maxHealth += upgradeAmount;
    }

    void Die()
    {
        //Dodati
    }
}