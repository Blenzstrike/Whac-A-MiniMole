using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that sets and dictates the highscore list.
/// </summary>
public class HighscoreList : MonoBehaviour
{
    /// <summary>
    /// Prefab of the highscore list items.
    /// </summary>
    [SerializeField] private GameObject highScoreListItem;
    /// <summary>
    /// Content object where the highscore list items need to be parented to.
    /// </summary>
    [SerializeField] private RectTransform contentZone;
    
    private List<GameObject> activeHighscoreList = new List<GameObject>();
    private RectTransform highscoreItemRectTransform;

    private void Awake()
    {
        highscoreItemRectTransform = highScoreListItem.GetComponent<RectTransform>();
    }

    /// <summary>
    /// Fill the highscore list based a provided list.
    /// </summary>
    /// <param name="pHighscoreList">A tuple list with the name and score of each highscore position. The order of the list dictates the order, first in the list should be highset score.</param>
    public void SetHighscoreLists(List<(string pName, string pScore)> pHighscoreList)
    {
        //If there are no highscores, add a template item.
        if(pHighscoreList == null ||  pHighscoreList.Count == 0)
        {
            activeHighscoreList.Add(Instantiate(highScoreListItem, contentZone));
        }
        else
        {
            foreach ((string pName, string pScore) _highScore in pHighscoreList)
            {
                GameObject _newHighscoreItem = Instantiate(highScoreListItem, contentZone);
                _newHighscoreItem.GetComponent<HighscoreListItem>().SetData(_highScore.pName, _highScore.pScore);
                activeHighscoreList.Add(_newHighscoreItem);
            }
        }

        contentZone.sizeDelta = new Vector2(contentZone.sizeDelta.x, activeHighscoreList.Count * highscoreItemRectTransform.sizeDelta.y);
    }

    /// <summary>
    /// Clears the highscore list and destroys all highscore list items.
    /// </summary>
    public void ClearHighscore()
    {
        foreach (GameObject _newHighscoreListItem in activeHighscoreList)
        {
            Destroy(_newHighscoreListItem);
        }
        activeHighscoreList.Clear();
    }
}
