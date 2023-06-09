using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum CharacterClass
{
    Warrior,
    Mage,
    Cleric
}

public class CharacterClassSelection : MonoBehaviour
{

    public Button warriorButton;
    public Button mageButton;
    public Button clericButton;

    public TextMeshProUGUI selectedClassText;

    public GameObject warriorModel;
    public GameObject mageModel;
    public GameObject clericModel;

    private CharacterClass selectedClass;

    // Start is called before the first frame update
    private void Start()
    {
        warriorButton.onClick.AddListener(() => SelectClass(CharacterClass.Warrior));
        mageButton.onClick.AddListener(() => SelectClass(CharacterClass.Mage));
        clericButton.onClick.AddListener(() => SelectClass(CharacterClass.Cleric));

        selectedClass = CharacterClass.Warrior;
        UpdateSelectedClassText();
        UpdateCharacterModels();
    }

    private void UpdateSelectedClassText()
    {
        selectedClassText.text = selectedClass.ToString();
    }

    private void SelectClass(CharacterClass selectedClass)
    {
        this.selectedClass = selectedClass;
        ClassSelectionManager.Instance.SetSelectedClass(selectedClass);
        UpdateSelectedClassText();
        UpdateCharacterModels();
    }

    private void UpdateCharacterModels()
    {
        warriorModel.SetActive(selectedClass == CharacterClass.Warrior);
        mageModel.SetActive(selectedClass == CharacterClass.Mage);
        clericModel.SetActive(selectedClass == CharacterClass.Cleric);
    }
}