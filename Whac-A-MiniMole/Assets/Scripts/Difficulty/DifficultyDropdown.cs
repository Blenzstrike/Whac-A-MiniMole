using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TMP_Dropdown;

public class DifficultyDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyTMPDropdown;
    [SerializeField] private List<DifficultyClass> difficultyClasses;
    public DifficultyClass CurrentDifficultyClass { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
       if(difficultyTMPDropdown == null) { Debug.LogError("No difficulty Dropdown selected"); return; }
       if (difficultyClasses == null || difficultyClasses.Count == 0) { Debug.LogError("No difficultyClasses assigned"); return; }

        difficultyTMPDropdown.ClearOptions();

        List<OptionData> _newOptions = new List<OptionData>();
        foreach (DifficultyClass difficultyClass in difficultyClasses) { 
            _newOptions.Add(new OptionData(difficultyClass.Name, difficultyClass.OptionImage));
        }

        difficultyTMPDropdown.AddOptions(_newOptions);
        difficultyTMPDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        if (PlayerInformation.SelectedDifficulty != null)
        {
            for (int i = 0; i < difficultyClasses.Count; i++)
            {
                if (difficultyClasses[i] == PlayerInformation.SelectedDifficulty)
                {
                    CurrentDifficultyClass = difficultyClasses[i];
                    difficultyTMPDropdown.SetValueWithoutNotify(i);
                }
            }
        }
        else
        {
            CurrentDifficultyClass = difficultyClasses[0];
        }
    }

    private void OnDropdownValueChanged(int _index)
    {
        if(_index > difficultyClasses.Count) { Debug.LogError("Value selected bigger than difficulty classes list"); }
        CurrentDifficultyClass = difficultyClasses[_index];
    }

    public DifficultyClass GetDifficultyClassOnName(string pName)
    {
        foreach (DifficultyClass _difficultyClass in difficultyClasses)
        {
            if(_difficultyClass.name == pName)
            {
                return _difficultyClass;
            }
        }

        return null;
    }
}
