using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public CharacterClass characterClass;
    public int currentHealth;
    public int currentMana;
    public int currentGold;

    public void SaveGame()
    {
        PlayerPrefs.SetString("CharacterClass", characterClass.ToString());

        PlayerPrefs.SetInt("CurrentHealth", currentHealth);
        PlayerPrefs.SetInt("CurrentMana", currentMana);
        PlayerPrefs.SetInt("CurrentGold", currentGold);

        PlayerPrefs.Save();

        Debug.Log("Game data saved.");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("CharacterClass"))
        {
            string savedCharacterClass = PlayerPrefs.GetString("CharacterClass");
            characterClass = (CharacterClass)System.Enum.Parse(typeof(CharacterClass), savedCharacterClass);
        }

        if (PlayerPrefs.HasKey("CurrentHealth"))
        {
            currentHealth = PlayerPrefs.GetInt("CurrentHealth");
        }

        if (PlayerPrefs.HasKey("CurrentMana"))
        {
            currentMana = PlayerPrefs.GetInt("CurrentMana");
        }

        if (PlayerPrefs.HasKey("CurrentGold"))
        {
            currentGold = PlayerPrefs.GetInt("CurrentGold");
        }

        Debug.Log("Game data loaded.");
    }
}
