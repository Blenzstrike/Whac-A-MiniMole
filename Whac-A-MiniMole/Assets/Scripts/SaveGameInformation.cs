using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveGameInformation 
{
    public string LastFilledInName;
    public string LastSelectedDifficultyName;
    [SerializeField] public List<SavedHighscoreItem> SavedHighscoreItems;

    public void AddItemToHighscore (string pName, int pScore, string pDifficultyName)
    {
        if(SavedHighscoreItems == null) { SavedHighscoreItems = new List<SavedHighscoreItem>(); }
        for (int i = 0; i < SavedHighscoreItems.Count; i++)
        {
            if (SavedHighscoreItems[i].Score < pScore)
            {
                SavedHighscoreItems.Insert (i, new SavedHighscoreItem (pName, pScore, pDifficultyName));
            }
        }
    }
}

[Serializable]
public struct SavedHighscoreItem
{
    public string Name;
    public int Score;
    public string DifficultyName;

    public SavedHighscoreItem (string name, int score, string difficultyName)
    {
        Name = name;
        Score = score;
        DifficultyName = difficultyName;
    }
}
