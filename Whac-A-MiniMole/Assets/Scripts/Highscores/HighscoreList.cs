using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreList : MonoBehaviour
{
    [SerializeField] private GameObject highScoreListItem;
    [SerializeField] private Transform contentZone;
    private List<GameObject> activeHighscoreList = new List<GameObject>();

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
