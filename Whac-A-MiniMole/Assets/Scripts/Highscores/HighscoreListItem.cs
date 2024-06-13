using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreListItem : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text scoreText;
    public void SetData(string pName, string pScore)
    {
        if (string.IsNullOrWhiteSpace(pName) && string.IsNullOrWhiteSpace(pScore)) { return; }
        nameText.text = pName;
        scoreText.text = pScore;
    }
}
