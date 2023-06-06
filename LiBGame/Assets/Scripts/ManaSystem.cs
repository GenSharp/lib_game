using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaSystem : MonoBehaviour
{

    public int maxMana = 100;
    public int currentMana = 100;

    public TextMeshProUGUI manaText;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateManaText();
        Shop.OnManaUpgrade += UpgradeMaxMana;
    }

    private void OnDestroy()
    {
        Shop.OnManaUpgrade -= UpgradeMaxMana;
    }

    public bool UseMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            UpdateManaText();
            return true;
        }
        return false;
    }

    public void AddMana(int amount)
    {
        currentMana = Mathf.Clamp(currentMana + amount, 0, maxMana);
        UpdateManaText();
    }

    void UpdateManaText()
    {
        manaText.SetText(currentMana.ToString());
    }

    private void UpgradeMaxMana(int upgradeAmount)
    {
        maxMana += upgradeAmount;
    }
}