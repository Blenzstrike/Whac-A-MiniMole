using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Script incharge of the timer in the game.
/// </summary>
public class TimeHandler : MonoBehaviour
{
    [SerializeField] private Text timeText;
    private bool isRunning = false;
    /// <summary>
    /// Time elapsed since the last second.
    /// </summary>
    private float elapsedtime = 0;
    private int TimeLeft;
    public UnityEvent OnGameStop;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (PlayerInformation.SelectedDifficulty == null) { return; }
        TimeLeft = PlayerInformation.SelectedDifficulty.GameTimeInSeconds;
        timeText.text = TimeLeft.ToString();
        elapsedtime = 0;
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
