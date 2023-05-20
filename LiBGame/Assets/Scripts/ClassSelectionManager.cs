using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSelectionManager : MonoBehaviour
{

    private static ClassSelectionManager instance;

    public CharacterClass selectedClass;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static ClassSelectionManager Instance
    {
        get { return instance; }
    }

    public void SetSelectedClass(CharacterClass selectedClass)
    {
        this.selectedClass = selectedClass;
    }

    public CharacterClass GetSelectedClass()
    {
        return selectedClass;
    }
}