using UnityEngine;
using UnityEngine.UI;
using static StateHandler;

/// <summary>
/// State class for the Explenation screen.
/// </summary>
public class ExplenationScreen : GameState
{
    /// <summary>
    /// Specific button that will dictate if the user wants to move on from this screen.
    /// </summary>
    [SerializeField] private Button ContinueButton;

    protected override void Awake()
    {
        SpecificGameState = GameStates.ExplenationScreen;
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
        gameObject.SetActive(false);
    }

    private void OnContinuePress()
    {
        StateHandler.OnStateSwitch.Invoke(GameStates.ExplenationScreen, GameStates.GameScreen);
    }
}
