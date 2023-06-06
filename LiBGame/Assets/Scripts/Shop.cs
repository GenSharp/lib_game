using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public TextMeshProUGUI healthUpgradePriceText;
    public TextMeshProUGUI manaUpgradePriceText;

    public Button healthUpgradeButton;
    public Button manaUpgradeButton;

    private int healthUpgradePrice = 100;
    private int manaUpgradePrice = 100;

    private CoinsCurrency coinsCurrency;

    public static event Action<int> OnHealthUpgrade;
    public static event Action<int> OnManaUpgrade;

    // Start is called before the first frame update
    private void Start()
    {
        coinsCurrency = FindObjectOfType<CoinsCurrency>();
        UpdateUpgradePricesText();

        healthUpgradeButton.onClick.AddListener(BuyHealthUpgrade);
        manaUpgradeButton.onClick.AddListener(BuyManaUpgrade);
    }

    private void OnDestroy()
    {
        healthUpgradeButton.onClick.RemoveListener(BuyHealthUpgrade);
        manaUpgradeButton.onClick.RemoveListener(BuyManaUpgrade);
    }

    public void BuyHealthUpgrade()
    {
        if (coinsCurrency.coinCount >= healthUpgradePrice)
        {
            coinsCurrency.DeductCoins(healthUpgradePrice);
            healthUpgradePrice += 25;
            UpdateUpgradePricesText();
            OnHealthUpgrade?.Invoke(25);
        }
    }

    public void BuyManaUpgrade()
    {
        if (coinsCurrency.coinCount >= manaUpgradePrice)
        {
            coinsCurrency.DeductCoins(manaUpgradePrice);
            manaUpgradePrice += 25;
            UpdateUpgradePricesText();
            OnManaUpgrade?.Invoke(25);
        }
    }

    private void UpdateUpgradePricesText()
    {
        healthUpgradePriceText.text = "Health Upgrade: " + healthUpgradePrice + " coins";
        manaUpgradePriceText.text = "Mana Upgrade: " + manaUpgradePrice + " coins";
    }
}