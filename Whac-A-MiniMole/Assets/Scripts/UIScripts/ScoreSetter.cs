using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script that set the score on an object that has a text aswell. 
/// </summary>
public class ScoreSetter : MonoBehaviour
{
    private Text scoreText;
    private int lastScore = 0;
    private void OnEnable()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = lastScore.ToString();
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
