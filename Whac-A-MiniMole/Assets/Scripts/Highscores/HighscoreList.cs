using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreList : MonoBehaviour
{
    [SerializeField] private GameObject highScoreListItem;
    [SerializeField] private RectTransform contentZone;
    
    private List<GameObject> activeHighscoreList = new List<GameObject>();
    private RectTransform highscoreItemRectTransform;

    private void Awake()
    {
        highscoreItemRectTransform = highScoreListItem.GetComponent<RectTransform>();
    }

    public void SetHighscoreLists(List<(string pName, string pScore)> pHighscoreList)
    {
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

    public void ClearHighscore()
    {
        foreach (GameObject _newHighscoreListItem in activeHighscoreList)
        {
            Destroy(_newHighscoreListItem);
        }
        activeHighscoreList.Clear();
    }
}
