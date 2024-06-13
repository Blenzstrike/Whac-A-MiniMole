using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private bool isRunning = false;
    private float elapsedtime = 0;
    private int TimeLeft;
    public UnityEvent OnGameStop;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (PlayerInformation.SelectedDifficulty == null) { return; }
        TimeLeft = PlayerInformation.SelectedDifficulty.GameTimeInSeconds;
        timeText.text = TimeLeft.ToString();
        isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning) { return; }
        elapsedtime += Time.deltaTime;
        if (elapsedtime > 1) { 
            TimeLeft -= 1;
            timeText.text = TimeLeft.ToString();
            elapsedtime = 0;
        }
        if (TimeLeft <=0 ) { OnGameStop.Invoke(); isRunning = false; }
    }

    private void OnDisable()
    {
        isRunning = false;
    }
}
