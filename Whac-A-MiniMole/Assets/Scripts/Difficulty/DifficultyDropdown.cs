using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TMP_Dropdown;

/// <summary>
/// Dropdown menu for difficulty in the Main Menu
/// </summary>
public class DifficultyDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown difficultyTMPDropdown;
    [SerializeField] private List<DifficultyClass> difficultyClasses;
    public DifficultyClass CurrentDifficultyClass { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the difficulty can be assinged.
        if(difficultyTMPDropdown == null) { Debug.LogError("No difficulty Dropdown selected"); return; }
        if (difficultyClasses == null || difficultyClasses.Count == 0) { Debug.LogError("No difficultyClasses assigned"); return; }

        //Clear already existing options
        difficultyTMPDropdown.ClearOptions();

        //Create a list of option data and add the difficulties to that list.
        List<OptionData> _newOptions = new List<OptionData>();        
        foreach (DifficultyClass difficultyClass in difficultyClasses) { 
            _newOptions.Add(new OptionData(difficultyClass.Name, difficultyClass.OptionImage));
        }

        //Add options to the dropdown and subscribe to the listener.
        difficultyTMPDropdown.AddOptions(_newOptions);
        difficultyTMPDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
       
        //Make sure the dropdown shows selected difficulty (or if there is no previously selected difficulty then show first difficulty)
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

    /// <summary>
    /// Function that is called on the value change of the dropdown. Makes sure the selected difficulty is saved. 
    /// </summary>
    /// <param name="pIndex"></param>
    private void OnDropdownValueChanged(int pIndex)
    {
        if(pIndex > difficultyClasses.Count) { Debug.LogError("Value selected bigger than difficulty classes list"); }
        CurrentDifficultyClass = difficultyClasses[pIndex];
    }

    /// <summary>
    /// Search through all difficulties and returns the difficulty class based on the name given. 
    /// </summary>
    /// <param name="pName">The name of the difficulty class that you look for</param>
    /// <returns>Either the difficulty class with the specific name or null if there is no difficulty class with specific name</returns>
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
