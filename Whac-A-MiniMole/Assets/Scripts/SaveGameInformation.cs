using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Information saved between sessions
/// </summary>
[Serializable]
public class SaveGameInformation 
{
    [SerializeField] public string LastFilledInName = string.Empty;
    [SerializeField] public string LastSelectedDifficultyName = string.Empty;
    /// <summary>
    /// List of all highscore items. All difficulties are added in this list and this list is orderd in a way that the highest scores are earlier in the list.
    /// IF you want to add an item to the highscore list please use the function AddItemToHighscore. This is however still a public set due to serialization.
    /// </summary>
    [SerializeField] public List<SavedHighscoreItem> SavedHighscoreItems = null;

    /// <summary>
    /// Add a specific score to the highscore list.
    /// </summary>
    /// <param name="pName">Name of the user that got this score</param>
    /// <param name="pScore">Score the user got</param>
    /// <param name="pDifficultyName">Name of the Difficulty the user played</param>
    public void AddItemToHighscore (string pName, int pScore, string pDifficultyName)
    {
        //Make sure there is a list
        if(SavedHighscoreItems == null) 
        { 
            SavedHighscoreItems = new List<SavedHighscoreItem>();
        }

        //If there are no other highscores just add it to the list
        if (SavedHighscoreItems.Count == 0)
        {
            SavedHighscoreItems.Add(new SavedHighscoreItem(pName, pScore, pDifficultyName));
        }
        else
        {
            bool _hasBeenInserted = false;
            //Go through all the items in the list and check if the score at that position is higher that the score gotten. If it is not we put this score at that index.
            for (int i = 0; i < SavedHighscoreItems.Count; i++)
            {
                if (SavedHighscoreItems[i].Score < pScore)
                {
                    SavedHighscoreItems.Insert(i, new SavedHighscoreItem(pName, pScore, pDifficultyName));
                    _hasBeenInserted = true;
                    break;
                }
            }

            //If it is not inserted add it to the end
            if (_hasBeenInserted== false)
            {
                SavedHighscoreItems.Add(new SavedHighscoreItem(pName, pScore, pDifficultyName));
            }
        }
    }

}

/// <summary>
/// Struct of a seperate Highscore Item.
/// </summary>
[Serializable]
public struct SavedHighscoreItem
{
    [SerializeField] public string Name;
    [SerializeField] public int Score;
    [SerializeField] public string DifficultyName;

    public SavedHighscoreItem (string name, int score, string difficultyName)
    {
        Name = name;
        Score = score;
        DifficultyName = difficultyName;
    }
}
