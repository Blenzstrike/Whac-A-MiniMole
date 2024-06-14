using UnityEngine;
using UnityEngine.UI;
using static StateHandler;

/// <summary>
/// State class for the endscreen.
/// </summary>
public class EndScreen : GameState
{
    /// <summary>
    /// Specific button that will dictate if the user wants to move on from this screen.
    /// </summary>
    [SerializeField] private Button ContinueButton;

    protected override void Awake()
    {
        //Set the specific state that this object referce to.
        SpecificGameState = GameStates.EndScreen;
        base.Awake();
    }
    protected override void OnEnterThisState()
    {
        gameObject.SetActive(true);
        ContinueButton.onClick.AddListener(OnContinuePress);
    }

    protected override void OnExitThisState()
    {
        ContinueButton.onClick.RemoveListener(OnContinuePress);
        //Set playerscore back to 0. At this point the score has been saved to the highscore list and this make sure the player cannot contine the game with the previous points.
        PlayerInformation.Score = 0;
        gameObject.SetActive(false);
    }

    private void OnContinuePress()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.EndScreen, GameStates.HighScore);
    }
}
