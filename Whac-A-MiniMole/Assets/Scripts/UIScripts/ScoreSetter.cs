using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour
{
    private Text scoreText;
    private int lastScore;
    private void OnEnable()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastScore != PlayerInformation.Score)
        {
            lastScore = PlayerInformation.Score;
            scoreText.text = lastScore.ToString();
        }
    }
}
