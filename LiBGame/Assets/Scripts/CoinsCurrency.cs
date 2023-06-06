using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCurrency : MonoBehaviour
{

    private EnemyCounter enemyCounter;
    public int coinsPerEnemy = 25;
    public TextMeshProUGUI coinCountText;

    public int coinCount = 0;

    private void Awake()
    {
        UpdateCoinCountText();
    }

    // Start is called before the first frame update
    private void Start()
    {
        enemyCounter = FindObjectOfType<EnemyCounter>();
        UpdateCoinCountText();
    }

    private void Update()
    {
        if (enemyCounter.enemyCount > coinCount / coinsPerEnemy)
        {
            coinCount = enemyCounter.enemyCount * coinsPerEnemy;
            UpdateCoinCountText();
        }
    }

    public void AddCoinsForEnemyKilled()
    {
        coinCount += coinsPerEnemy;
        UpdateCoinCountText();
    }

    public void DeductCoins(int amount)
    {
        coinCount -= amount;
        UpdateCoinCountText();
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = "Coins: " + coinCount;
    }
}