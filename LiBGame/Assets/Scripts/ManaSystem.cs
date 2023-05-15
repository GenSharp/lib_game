using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaSystem : MonoBehaviour
{

    public int maxMana = 100;
    public int currentMana = 100;

    public float manaRegenRate = 0.5f;
    public float manaRegenDelay = 3f;
    private float lastManaUseTime;

    public TextMeshProUGUI manaText;

    // Start is called before the first frame update
    private void Start()
    {
        lastManaUseTime = Time.time;
        UpdateManaText();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMana < maxMana && Time.time - lastManaUseTime > manaRegenDelay)
        {
            currentMana = Mathf.Clamp(currentMana + (int)(manaRegenRate * Time.deltaTime * maxMana), 0, maxMana);
            UpdateManaText();
        }
    }

    public bool UseMana(int amount)
    {
        if (currentMana >= amount)
        {
            currentMana -= amount;
            lastManaUseTime = Time.time;
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
}