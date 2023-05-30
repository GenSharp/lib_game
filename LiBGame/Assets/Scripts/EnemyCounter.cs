using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public int enemyCount = 0;
    public TextMeshProUGUI enemyCountText;

    private void Start()
    {
        UpdateEnemyCountText();
    }

    public void EnemyKilled()
    {
        enemyCount++;
        UpdateEnemyCountText();
    }

    private void UpdateEnemyCountText()
    {
        enemyCountText.text = "Enemies killed: " + enemyCount;
    }
}